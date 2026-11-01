using DAL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Torneo
    {
        DAL_Torneo dalTorneo_348LC = new DAL_Torneo();

        public List<Torneo> Listar_348LC()
        {
            return dalTorneo_348LC.Listar_348LC();
        }

        public void Alta_348LC(Torneo torneo_348LC)
        {
            Validar_348LC(torneo_348LC);

            if (torneo_348LC.FechaInicio < DateTime.Today)
                throw new Exception("La fecha de inicio no puede ser anterior a hoy.");

            torneo_348LC.Id = dalTorneo_348LC.AñadirTorneo_348LC(torneo_348LC);
            RecalcularYGuardar_348LC(torneo_348LC);
        }

        public void Modificar_348LC(int idTorneo_348LC, Torneo torneo_348LC)
        {
            Torneo torneoActual_348LC = ObtenerTorneoActivo_348LC(idTorneo_348LC);
            torneo_348LC.Id = idTorneo_348LC;
            Validar_348LC(torneo_348LC);

            if (DateTime.Today > torneoActual_348LC.FechaFin.Date)
                throw new Exception("El torneo ya finalizó y no puede modificarse.");

            bool yaComenzo_348LC = DateTime.Today > torneoActual_348LC.FechaInicio.Date;

            if (yaComenzo_348LC && torneo_348LC.FechaInicio != torneoActual_348LC.FechaInicio.Date)
                throw new Exception("El torneo ya comenzó: no se puede cambiar la fecha de inicio.");

            if (!yaComenzo_348LC && torneo_348LC.FechaInicio < DateTime.Today)
                throw new Exception("La fecha de inicio no puede ser anterior a hoy.");

            if (torneo_348LC.FechaFin < DateTime.Today)
                throw new Exception("La fecha de fin no puede ser anterior a hoy.");

            int inscriptos_348LC = new DAL_Inscripcion().ListarEquiposDelTorneo_348LC(idTorneo_348LC).Count;
            if (torneo_348LC.CantidadMaximaEquipos < inscriptos_348LC)
                throw new Exception($"El torneo ya tiene {inscriptos_348LC} equipos inscriptos: la cantidad máxima no puede ser menor.");

            bool partidoFueraDeRango_348LC = new DAL_Partido().ListarPorTorneo_348LC(idTorneo_348LC).Any(p_348LC =>
                p_348LC.FechaPartido.Date < torneo_348LC.FechaInicio || p_348LC.FechaPartido.Date > torneo_348LC.FechaFin);

            if (partidoFueraDeRango_348LC)
                throw new Exception("Hay partidos programados fuera de las nuevas fechas del torneo.");

            dalTorneo_348LC.ModificarTorneo_348LC(idTorneo_348LC, torneo_348LC);
            RecalcularYGuardar_348LC(torneo_348LC);
        }

        public void Baja_348LC(int idTorneo_348LC)
        {
            ObtenerTorneoActivo_348LC(idTorneo_348LC);

            if (new DAL_Inscripcion().ListarEquiposDelTorneo_348LC(idTorneo_348LC).Count > 0)
                throw new Exception("No se puede eliminar el torneo porque tiene equipos inscriptos. Quitalos primero.");

            dalTorneo_348LC.EliminarTorneo_348LC(idTorneo_348LC);
            Torneo torneoActualizado_348LC = dalTorneo_348LC.ObtenerPorId_348LC(idTorneo_348LC);
            RecalcularYGuardar_348LC(torneoActualizado_348LC);
        }

        public Torneo ObtenerPorId_348LC(int idTorneo_348LC)
        {
            return dalTorneo_348LC.ObtenerPorId_348LC(idTorneo_348LC);
        }

        public string GenerarReporte_348LC(int idTorneo_348LC)
        {
            Torneo torneo_348LC = ObtenerTorneoActivo_348LC(idTorneo_348LC);
            List<Equipo> equipos_348LC = new DAL_Inscripcion().ListarEquiposDelTorneo_348LC(idTorneo_348LC);
            List<Partido> partidos_348LC = new DAL_Partido().ListarPorTorneo_348LC(idTorneo_348LC)
                .OrderBy(p_348LC => p_348LC.FechaPartido.Date)
                .ThenBy(p_348LC => p_348LC.HoraInicio)
                .ThenBy(p_348LC => p_348LC.NumeroCancha)
                .ToList();

            if (partidos_348LC.Count == 0)
                throw new Exception("El torneo no tiene partidos programados para generar el reporte.");

            Func<string, int, string> ajustar_348LC = (texto_348LC, largo_348LC) =>
            {
                texto_348LC = texto_348LC ?? "";
                return texto_348LC.Length > largo_348LC ? texto_348LC.Substring(0, largo_348LC) : texto_348LC.PadRight(largo_348LC);
            };

            List<Partido> jugados_348LC = partidos_348LC
                .Where(p_348LC => !p_348LC.Suspendido && p_348LC.GolesEquipoLocal.HasValue && p_348LC.GolesEquipoVisitante.HasValue)
                .ToList();

            var posiciones_348LC = equipos_348LC.Select(e_348LC =>
            {
                List<Partido> delEquipo_348LC = jugados_348LC
                    .Where(p_348LC => p_348LC.IdEquipoLocal == e_348LC.Id || p_348LC.IdEquipoVisitante == e_348LC.Id)
                    .ToList();

                int ganados_348LC = 0, empatados_348LC = 0, perdidos_348LC = 0, golesFavor_348LC = 0, golesContra_348LC = 0;

                foreach (Partido p_348LC in delEquipo_348LC)
                {
                    bool esLocal_348LC = p_348LC.IdEquipoLocal == e_348LC.Id;
                    int propios_348LC = esLocal_348LC ? p_348LC.GolesEquipoLocal.Value : p_348LC.GolesEquipoVisitante.Value;
                    int rivales_348LC = esLocal_348LC ? p_348LC.GolesEquipoVisitante.Value : p_348LC.GolesEquipoLocal.Value;

                    golesFavor_348LC += propios_348LC;
                    golesContra_348LC += rivales_348LC;

                    if (propios_348LC > rivales_348LC) ganados_348LC++;
                    else if (propios_348LC == rivales_348LC) empatados_348LC++;
                    else perdidos_348LC++;
                }

                return new
                {
                    Equipo = e_348LC.NombreEquipo,
                    PJ = delEquipo_348LC.Count,
                    PG = ganados_348LC,
                    PE = empatados_348LC,
                    PP = perdidos_348LC,
                    GF = golesFavor_348LC,
                    GC = golesContra_348LC,
                    DG = golesFavor_348LC - golesContra_348LC,
                    Pts = ganados_348LC * 3 + empatados_348LC
                };
            })
            .OrderByDescending(x_348LC => x_348LC.Pts)
            .ThenByDescending(x_348LC => x_348LC.DG)
            .ThenByDescending(x_348LC => x_348LC.GF)
            .ThenBy(x_348LC => x_348LC.Equipo)
            .ToList();

            StringBuilder reporte_348LC = new StringBuilder();
            string separador_348LC = new string('-', 80);

            Action<string, string> agregarConAjuste_348LC = (etiqueta_348LC, texto_348LC) =>
            {
                string sangria_348LC = new string(' ', etiqueta_348LC.Length);
                string linea_348LC = etiqueta_348LC;
                bool lineaConTexto_348LC = false;

                foreach (string palabra_348LC in texto_348LC.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string resto_348LC = palabra_348LC;

                    if (lineaConTexto_348LC && linea_348LC.Length + resto_348LC.Length > 80)
                    {
                        reporte_348LC.AppendLine(linea_348LC.TrimEnd());
                        linea_348LC = sangria_348LC;
                    }

                    while (linea_348LC.Length + resto_348LC.Length > 80)
                    {
                        int corte_348LC = 80 - linea_348LC.Length;
                        reporte_348LC.AppendLine(linea_348LC + resto_348LC.Substring(0, corte_348LC));
                        resto_348LC = resto_348LC.Substring(corte_348LC);
                        linea_348LC = sangria_348LC;
                    }

                    linea_348LC += resto_348LC + " ";
                    lineaConTexto_348LC = true;
                }

                reporte_348LC.AppendLine(linea_348LC.TrimEnd());
            };

            agregarConAjuste_348LC("Torneo:      ", torneo_348LC.NombreTorneo);
            reporte_348LC.AppendLine($"Categoría:   {torneo_348LC.Categoria}");
            reporte_348LC.AppendLine($"Período:     {torneo_348LC.FechaInicio:dd/MM/yyyy} al {torneo_348LC.FechaFin:dd/MM/yyyy}");
            reporte_348LC.AppendLine($"Equipos:     {equipos_348LC.Count} de {torneo_348LC.CantidadMaximaEquipos}");
            if (!string.IsNullOrWhiteSpace(torneo_348LC.Descripcion))
                agregarConAjuste_348LC("Descripción: ", torneo_348LC.Descripcion.Replace("\r", " ").Replace("\n", " "));
            reporte_348LC.AppendLine($"Emitido:     {DateTime.Now:dd/MM/yyyy HH:mm}");
            reporte_348LC.AppendLine();

            reporte_348LC.AppendLine("EQUIPOS INSCRIPTOS");
            reporte_348LC.AppendLine(separador_348LC);
            reporte_348LC.AppendLine($"{ajustar_348LC("Equipo", 30)}  {ajustar_348LC("Responsable", 26)}  Colores");
            reporte_348LC.AppendLine(separador_348LC);
            foreach (Equipo e_348LC in equipos_348LC.OrderBy(x_348LC => x_348LC.NombreEquipo))
            {
                string colores_348LC = string.IsNullOrWhiteSpace(e_348LC.ColorSecundario)
                    ? e_348LC.ColorPrincipal
                    : $"{e_348LC.ColorPrincipal}/{e_348LC.ColorSecundario}";
                reporte_348LC.AppendLine($"{ajustar_348LC(e_348LC.NombreEquipo, 30)}  {ajustar_348LC(e_348LC.NombreResponsable, 26)}  {ajustar_348LC(colores_348LC, 20).TrimEnd()}");
            }
            reporte_348LC.AppendLine();

            reporte_348LC.AppendLine("FIXTURE Y RESULTADOS");
            reporte_348LC.AppendLine(separador_348LC);
            reporte_348LC.AppendLine($"{ajustar_348LC("Fecha", 10)}  Hora   Cancha  {ajustar_348LC("Local", 20)}  {ajustar_348LC("Resultado", 11)}  Visitante");
            reporte_348LC.AppendLine(separador_348LC);
            foreach (Partido p_348LC in partidos_348LC)
            {
                string resultado_348LC;
                if (p_348LC.Suspendido)
                    resultado_348LC = "Suspendido";
                else if (p_348LC.GolesEquipoLocal.HasValue && p_348LC.GolesEquipoVisitante.HasValue)
                    resultado_348LC = $"{p_348LC.GolesEquipoLocal} - {p_348LC.GolesEquipoVisitante}";
                else
                    resultado_348LC = "Pendiente";

                reporte_348LC.AppendLine($"{p_348LC.FechaPartido:dd/MM/yyyy}  {p_348LC.HoraInicio:hh\\:mm}  {p_348LC.NumeroCancha,6}  {ajustar_348LC(p_348LC.EquipoLocal, 20)}  {ajustar_348LC(resultado_348LC, 11)}  {ajustar_348LC(p_348LC.EquipoVisitante, 20).TrimEnd()}");
            }
            reporte_348LC.AppendLine();
            reporte_348LC.AppendLine($"Jugados: {jugados_348LC.Count}   Suspendidos: {partidos_348LC.Count(p_348LC => p_348LC.Suspendido)}   Pendientes: {partidos_348LC.Count - jugados_348LC.Count - partidos_348LC.Count(p_348LC => p_348LC.Suspendido)}");
            reporte_348LC.AppendLine();

            reporte_348LC.AppendLine("TABLA DE POSICIONES");
            reporte_348LC.AppendLine(separador_348LC);
            reporte_348LC.AppendLine($"Pos  {ajustar_348LC("Equipo", 26)}{"PJ",5}{"PG",5}{"PE",5}{"PP",5}{"GF",5}{"GC",5}{"DG",5}{"Pts",6}");
            reporte_348LC.AppendLine(separador_348LC);
            int posicion_348LC = 1;
            foreach (var fila_348LC in posiciones_348LC)
            {
                reporte_348LC.AppendLine($"{posicion_348LC,3}  {ajustar_348LC(fila_348LC.Equipo, 26)}{fila_348LC.PJ,5}{fila_348LC.PG,5}{fila_348LC.PE,5}{fila_348LC.PP,5}{fila_348LC.GF,5}{fila_348LC.GC,5}{fila_348LC.DG,5}{fila_348LC.Pts,6}");
                posicion_348LC++;
            }
            reporte_348LC.AppendLine();
            reporte_348LC.AppendLine("Puntos: 3 por victoria, 1 por empate. Desempate: dif. de gol y goles a favor.");

            return reporte_348LC.ToString();
        }

        private Torneo ObtenerTorneoActivo_348LC(int idTorneo_348LC)
        {
            Torneo torneo_348LC = dalTorneo_348LC.ObtenerPorId_348LC(idTorneo_348LC);

            if (torneo_348LC == null || torneo_348LC.Eliminado)
                throw new Exception("El torneo no existe o fue eliminado.");

            return torneo_348LC;
        }

        private void Validar_348LC(Torneo torneo_348LC)
        {
            if (string.IsNullOrWhiteSpace(torneo_348LC.NombreTorneo))
                throw new Exception("El nombre del torneo es obligatorio.");

            if (string.IsNullOrWhiteSpace(torneo_348LC.Categoria))
                throw new Exception("La categoría es obligatoria.");

            torneo_348LC.NombreTorneo = torneo_348LC.NombreTorneo.Trim();
            torneo_348LC.Categoria = torneo_348LC.Categoria.Trim().ToUpper();
            torneo_348LC.Descripcion = string.IsNullOrWhiteSpace(torneo_348LC.Descripcion) ? null : torneo_348LC.Descripcion.Trim();
            torneo_348LC.FechaInicio = torneo_348LC.FechaInicio.Date;
            torneo_348LC.FechaFin = torneo_348LC.FechaFin.Date;

            if (torneo_348LC.NombreTorneo.Length < 3 || torneo_348LC.NombreTorneo.Length > 100)
                throw new Exception("El nombre del torneo debe tener entre 3 y 100 caracteres.");

            string[] categoriasValidas_348LC = { "FUTBOL 5", "FUTBOL 7", "FUTBOL 11" };
            if (!categoriasValidas_348LC.Contains(torneo_348LC.Categoria))
                throw new Exception("La categoría debe ser FUTBOL 5, FUTBOL 7 o FUTBOL 11.");

            if (torneo_348LC.Descripcion != null && torneo_348LC.Descripcion.Length > 255)
                throw new Exception("La descripción no puede superar los 255 caracteres.");

            Torneo torneoExistente_348LC = dalTorneo_348LC.ObtenerPorNombre_348LC(torneo_348LC.NombreTorneo);
            if (torneoExistente_348LC != null && torneoExistente_348LC.Id != torneo_348LC.Id)
                throw new Exception("Ya existe un torneo con ese nombre.");

            if (torneo_348LC.FechaFin.Date <= torneo_348LC.FechaInicio.Date)
                throw new Exception("La fecha de fin debe ser posterior a la de inicio.");

            if (torneo_348LC.CantidadMaximaEquipos <= 0 || torneo_348LC.CantidadMaximaEquipos % 2 != 0)
                throw new Exception("La cantidad de equipos debe ser un número par mayor a cero.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Torneo> torneos_348LC = dalTorneo_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = torneos_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = torneos_348LC.Select(t => t.DVH).ToList();
            int dvvGuardado_348LC = dalTorneo_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Torneo torneo_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(torneo_348LC);
            dalTorneo_348LC.ActualizarDVH_348LC(torneo_348LC.Id, dvh_348LC);

            List<Torneo> todos_348LC = dalTorneo_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalTorneo_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Torneo> todos_348LC = dalTorneo_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Torneo torneo_348LC in todos_348LC)
                dalTorneo_348LC.ActualizarDVH_348LC(torneo_348LC.Id, validador_348LC.CalcularDV(torneo_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalTorneo_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
