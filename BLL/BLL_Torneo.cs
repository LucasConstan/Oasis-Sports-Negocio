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
