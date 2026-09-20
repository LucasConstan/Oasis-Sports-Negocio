using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Partido
    {
        DAL_Partido dalPartido_348LC = new DAL_Partido();
        DAL_Inscripcion dalInscripcion_348LC = new DAL_Inscripcion();

        public List<Partido> ListarPorTorneo_348LC(int idTorneo_348LC)
        {
            return dalPartido_348LC.ListarPorTorneo_348LC(idTorneo_348LC);
        }

        public void Organizar_348LC(Partido partido_348LC)
        {
            if (partido_348LC.IdEquipoLocal == partido_348LC.IdEquipoVisitante)
                throw new Exception("El equipo local y el visitante no pueden ser el mismo.");

            if (dalInscripcion_348LC.ObtenerInscripcion_348LC(partido_348LC.IdTorneo, partido_348LC.IdEquipoLocal) == null)
                throw new Exception("El equipo local no está inscripto en este torneo.");

            if (dalInscripcion_348LC.ObtenerInscripcion_348LC(partido_348LC.IdTorneo, partido_348LC.IdEquipoVisitante) == null)
                throw new Exception("El equipo visitante no está inscripto en este torneo.");

            if (dalPartido_348LC.ObtenerCanchaOcupada_348LC(partido_348LC.FechaPartido, partido_348LC.HoraInicio, partido_348LC.NumeroCancha) != null)
                throw new Exception("La cancha ya está asignada a otro partido en ese horario.");

            dalPartido_348LC.AñadirPartido_348LC(partido_348LC);
        }
    }
}
