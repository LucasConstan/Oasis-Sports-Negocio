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
            equipo_348LC.Id = idEquipo_348LC;
            Validar_348LC(equipo_348LC);
            dalEquipo_348LC.ModificarEquipo_348LC(idEquipo_348LC, equipo_348LC);
            RecalcularYGuardar_348LC(equipo_348LC);
        }

        public void Baja_348LC(int idEquipo_348LC)
        {
            dalEquipo_348LC.EliminarEquipo_348LC(idEquipo_348LC);
            Equipo equipoActualizado_348LC = dalEquipo_348LC.ObtenerPorId_348LC(idEquipo_348LC);
            RecalcularYGuardar_348LC(equipoActualizado_348LC);
        }

        public Equipo ObtenerPorId_348LC(int idEquipo_348LC)
        {
            return dalEquipo_348LC.ObtenerPorId_348LC(idEquipo_348LC);
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
    }
}
