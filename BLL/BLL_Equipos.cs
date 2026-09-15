using DAL;
using Entidades;
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
            dalEquipo_348LC.AñadirEquipo_348LC(equipo_348LC);
        }

        public void Baja_348LC(int idEquipo_348LC)
        {
            dalEquipo_348LC.EliminarEquipo_348LC(idEquipo_348LC);
        }

        public void Modificar_348LC(int idEquipo_348LC, Equipo equipo_348LC)
        {
            Validar_348LC(equipo_348LC);
            dalEquipo_348LC.ModificarEquipo_348LC(idEquipo_348LC, equipo_348LC);
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
    }
}
