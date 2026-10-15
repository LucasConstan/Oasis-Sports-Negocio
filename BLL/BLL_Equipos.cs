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
    public class BLL_Equipo
    {
        DAL_Equipo dalEquipo_348LC = new DAL_Equipo();

        public List<Equipo> Listar_348LC()
        {
            return dalEquipo_348LC.Listar_348LC();
        }

        public void Alta_348LC(Equipo equipo_348LC)
        {
            Validar_348LC(equipo_348LC);
            equipo_348LC.Id = dalEquipo_348LC.AñadirEquipo_348LC(equipo_348LC);
            RecalcularYGuardar_348LC(equipo_348LC);
        }

        public void Modificar_348LC(int idEquipo_348LC, Equipo equipo_348LC)
        {
            ObtenerEquipoActivo_348LC(idEquipo_348LC);
            equipo_348LC.Id = idEquipo_348LC;
            Validar_348LC(equipo_348LC);
            dalEquipo_348LC.ModificarEquipo_348LC(idEquipo_348LC, equipo_348LC);
            RecalcularYGuardar_348LC(equipo_348LC);
        }

        public void Baja_348LC(int idEquipo_348LC)
        {
            ObtenerEquipoActivo_348LC(idEquipo_348LC);

            int cantidadJugadores_348LC = new DAL_Jugador().ListarPorEquipo_348LC(idEquipo_348LC).Count;
            if (cantidadJugadores_348LC > 0)
                throw new Exception($"No se puede eliminar el equipo porque tiene {cantidadJugadores_348LC} jugador(es) asignado(s). Reasignalos primero.");

            if (new DAL_Inscripcion().ListarTorneosActivosDelEquipo_348LC(idEquipo_348LC).Count > 0)
                throw new Exception("No se puede eliminar el equipo porque está inscripto en un torneo. Quitalo del torneo primero.");

            dalEquipo_348LC.EliminarEquipo_348LC(idEquipo_348LC);
            Equipo equipoActualizado_348LC = dalEquipo_348LC.ObtenerPorId_348LC(idEquipo_348LC);
            RecalcularYGuardar_348LC(equipoActualizado_348LC);
        }

        public Equipo ObtenerPorId_348LC(int idEquipo_348LC)
        {
            return dalEquipo_348LC.ObtenerPorId_348LC(idEquipo_348LC);
        }

        private Equipo ObtenerEquipoActivo_348LC(int idEquipo_348LC)
        {
            if (idEquipo_348LC == BLL_Jugador.SIN_EQUIPO_ID)
                throw new Exception("El equipo 'Sin equipo' está reservado por el sistema y no puede modificarse ni eliminarse.");

            Equipo equipo_348LC = dalEquipo_348LC.ObtenerPorId_348LC(idEquipo_348LC);

            if (equipo_348LC == null || equipo_348LC.Eliminado)
                throw new Exception("El equipo no existe o fue eliminado.");

            return equipo_348LC;
        }

        private bool SoloLetras_348LC(string texto_348LC)
        {
            return texto_348LC.All(c_348LC => char.IsLetter(c_348LC) || c_348LC == ' ' || c_348LC == '\'' || c_348LC == '-' || c_348LC == '.');
        }

        private void Validar_348LC(Equipo equipo_348LC)
        {
            if (string.IsNullOrWhiteSpace(equipo_348LC.NombreEquipo))
                throw new Exception("El nombre del equipo es obligatorio.");

            if (string.IsNullOrWhiteSpace(equipo_348LC.NombreResponsable))
                throw new Exception("El nombre del responsable es obligatorio.");

            if (string.IsNullOrWhiteSpace(equipo_348LC.ColorPrincipal))
                throw new Exception("El color principal es obligatorio.");

            if (string.IsNullOrWhiteSpace(equipo_348LC.ColorSecundario))
                throw new Exception("El color secundario es obligatorio.");

            equipo_348LC.NombreEquipo = equipo_348LC.NombreEquipo.Trim();
            equipo_348LC.NombreResponsable = equipo_348LC.NombreResponsable.Trim();
            equipo_348LC.ColorPrincipal = equipo_348LC.ColorPrincipal.Trim();
            equipo_348LC.ColorSecundario = equipo_348LC.ColorSecundario.Trim();

            string nombreEquipo_348LC = equipo_348LC.NombreEquipo;
            string nombreResponsable_348LC = equipo_348LC.NombreResponsable;

            if (nombreEquipo_348LC.Length < 3)
                throw new Exception("El nombre del equipo debe tener al menos 3 caracteres.");

            if (nombreEquipo_348LC.Length > 50)
                throw new Exception("El nombre del equipo no puede superar los 50 caracteres.");

            if (nombreEquipo_348LC.Equals("Sin equipo", StringComparison.OrdinalIgnoreCase))
                throw new Exception("El nombre 'Sin equipo' está reservado por el sistema.");

            if (nombreResponsable_348LC.Length < 3)
                throw new Exception("El nombre del responsable debe tener al menos 3 caracteres.");

            if (nombreResponsable_348LC.Length > 50)
                throw new Exception("El nombre del responsable no puede superar los 50 caracteres.");

            if (!SoloLetras_348LC(nombreResponsable_348LC))
                throw new Exception("El nombre del responsable solo puede contener letras y espacios.");

            if (equipo_348LC.ColorPrincipal.Length > 20 || equipo_348LC.ColorSecundario.Length > 20)
                throw new Exception("Los colores no pueden superar los 20 caracteres.");

            if (!SoloLetras_348LC(equipo_348LC.ColorPrincipal) || !SoloLetras_348LC(equipo_348LC.ColorSecundario))
                throw new Exception("Los colores solo pueden contener letras y espacios.");

            if (equipo_348LC.ColorPrincipal.Equals(equipo_348LC.ColorSecundario, StringComparison.OrdinalIgnoreCase))
                throw new Exception("El color principal y el secundario deben ser distintos.");

            bool nombreDuplicado_348LC = dalEquipo_348LC.Listar_348LC().Any(e_348LC =>
                e_348LC.Id != equipo_348LC.Id &&
                e_348LC.NombreEquipo.Trim().Equals(nombreEquipo_348LC, StringComparison.OrdinalIgnoreCase));

            if (nombreDuplicado_348LC)
                throw new Exception("Ya existe un equipo con ese nombre.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Equipo> equipos_348LC = dalEquipo_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = equipos_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = equipos_348LC.Select(e => e.DVH).ToList();
            int dvvGuardado_348LC = dalEquipo_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Equipo equipo_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(equipo_348LC);
            dalEquipo_348LC.ActualizarDVH_348LC(equipo_348LC.Id, dvh_348LC);

            List<Equipo> todos_348LC = dalEquipo_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalEquipo_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Equipo> todos_348LC = dalEquipo_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Equipo equipo_348LC in todos_348LC)
                dalEquipo_348LC.ActualizarDVH_348LC(equipo_348LC.Id, validador_348LC.CalcularDV(equipo_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalEquipo_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
