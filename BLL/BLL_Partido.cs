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

            bool partidoRepetido_348LC = dalPartido_348LC.ListarPorTorneo_348LC(partido_348LC.IdTorneo).Any(p_348LC =>
                p_348LC.IdEquipoLocal == partido_348LC.IdEquipoLocal &&
                p_348LC.IdEquipoVisitante == partido_348LC.IdEquipoVisitante);

            if (partidoRepetido_348LC)
                throw new Exception("Ese partido (mismo local y visitante) ya está programado en el torneo.");

            ValidarProgramacion_348LC(partido_348LC, 0);

            partido_348LC.Id = dalPartido_348LC.AñadirPartido_348LC(partido_348LC);
            RecalcularYGuardar_348LC(partido_348LC);
        }

        public void ValidarProgramacion_348LC(Partido partido_348LC, int idPartidoExcluir_348LC)
        {
            Torneo torneo_348LC = new DAL_Torneo().ObtenerPorId_348LC(partido_348LC.IdTorneo);
            if (torneo_348LC == null || torneo_348LC.Eliminado)
                throw new Exception("El torneo no existe o fue eliminado.");

            partido_348LC.FechaPartido = partido_348LC.FechaPartido.Date;
            partido_348LC.HoraInicio = new TimeSpan(partido_348LC.HoraInicio.Hours, partido_348LC.HoraInicio.Minutes, 0);

            if (partido_348LC.FechaPartido < torneo_348LC.FechaInicio.Date || partido_348LC.FechaPartido > torneo_348LC.FechaFin.Date)
                throw new Exception($"La fecha del partido debe estar entre el {torneo_348LC.FechaInicio:dd/MM/yyyy} y el {torneo_348LC.FechaFin:dd/MM/yyyy}.");

            if (partido_348LC.FechaPartido + partido_348LC.HoraInicio <= DateTime.Now)
                throw new Exception("No se puede programar un partido en una fecha y hora pasadas.");

            if (partido_348LC.NumeroCancha <= 0)
                throw new Exception("El número de cancha debe ser mayor a 0.");

            if (dalPartido_348LC.ObtenerCanchaOcupada_348LC(partido_348LC.FechaPartido, partido_348LC.HoraInicio, partido_348LC.NumeroCancha, idPartidoExcluir_348LC) != null)
                throw new Exception("La cancha ya está asignada a otro partido en ese horario.");

            bool equipoOcupado_348LC = dalPartido_348LC.ListarPorFechaHora_348LC(partido_348LC.FechaPartido, partido_348LC.HoraInicio, idPartidoExcluir_348LC).Any(p_348LC =>
                p_348LC.IdEquipoLocal == partido_348LC.IdEquipoLocal || p_348LC.IdEquipoVisitante == partido_348LC.IdEquipoLocal ||
                p_348LC.IdEquipoLocal == partido_348LC.IdEquipoVisitante || p_348LC.IdEquipoVisitante == partido_348LC.IdEquipoVisitante);

            if (equipoOcupado_348LC)
                throw new Exception("Uno de los equipos ya tiene otro partido en esa fecha y horario.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Partido> partidos_348LC = dalPartido_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = partidos_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = partidos_348LC.Select(p => p.DVH).ToList();
            int dvvGuardado_348LC = dalPartido_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Partido partido_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(partido_348LC);
            dalPartido_348LC.ActualizarDVH_348LC(partido_348LC.Id, dvh_348LC);

            List<Partido> todos_348LC = dalPartido_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalPartido_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Partido> todos_348LC = dalPartido_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Partido partido_348LC in todos_348LC)
                dalPartido_348LC.ActualizarDVH_348LC(partido_348LC.Id, validador_348LC.CalcularDV(partido_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalPartido_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
