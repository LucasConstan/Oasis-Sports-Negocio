using DAL;
using Entidades;
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
            dalTorneo_348LC.AñadirTorneo_348LC(torneo_348LC);
        }

        public void Modificar_348LC(int idTorneo_348LC, Torneo torneo_348LC)
        {
            Validar_348LC(torneo_348LC);
            dalTorneo_348LC.ModificarTorneo_348LC(idTorneo_348LC, torneo_348LC);
        }

        public void Baja_348LC(int idTorneo_348LC)
        {
            dalTorneo_348LC.EliminarTorneo_348LC(idTorneo_348LC);
        }

        public Torneo ObtenerPorId_348LC(int idTorneo_348LC)
        {
            return dalTorneo_348LC.ObtenerPorId_348LC(idTorneo_348LC);
        }

        private void Validar_348LC(Torneo torneo_348LC)
        {
            if (string.IsNullOrWhiteSpace(torneo_348LC.NombreTorneo))
                throw new Exception("El nombre del torneo es obligatorio.");

            if (string.IsNullOrWhiteSpace(torneo_348LC.Categoria))
                throw new Exception("La categoría es obligatoria.");

            Torneo torneoExistente_348LC = dalTorneo_348LC.ObtenerPorNombre_348LC(torneo_348LC.NombreTorneo);
            if (torneoExistente_348LC != null && torneoExistente_348LC.Id != torneo_348LC.Id)
                throw new Exception("Ya existe un torneo con ese nombre.");

            if (torneo_348LC.FechaInicio.Date < DateTime.Now.Date)
                throw new Exception("La fecha de inicio no puede ser anterior a hoy.");

            if (torneo_348LC.FechaFin.Date <= torneo_348LC.FechaInicio.Date)
                throw new Exception("La fecha de fin debe ser posterior a la de inicio.");

            if (torneo_348LC.CantidadMaximaEquipos <= 0 || torneo_348LC.CantidadMaximaEquipos % 2 != 0)
                throw new Exception("La cantidad de equipos debe ser un número par mayor a cero.");
        }
    }
}
