using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Resultado
    {
        DAL_Resultado dalResultado_348LC = new DAL_Resultado();
        DAL_Partido dalPartido_348LC = new DAL_Partido();
        BLL_Partido bllPartido_348LC = new BLL_Partido();

        public List<Partido> ListarPendientes_348LC(int idTorneo_348LC)
        {
            return dalResultado_348LC.ListarPendientes_348LC(idTorneo_348LC);
        }

        private Partido ObtenerPartidoSinResultado_348LC(int idPartido_348LC)
        {
            Partido partido_348LC = dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC);

            if (partido_348LC == null || partido_348LC.Eliminado)
                throw new Exception("El partido no existe o fue eliminado.");

            if (partido_348LC.GolesEquipoLocal != null || partido_348LC.GolesEquipoVisitante != null)
                throw new Exception("El partido ya tiene un resultado cargado.");

            return partido_348LC;
        }

        public void RegistrarResultado_348LC(int idPartido_348LC, int golesLocal_348LC, int golesVisitante_348LC)
        {
            if (golesLocal_348LC < 0 || golesVisitante_348LC < 0)
                throw new Exception("Los goles no pueden ser negativos.");

            Partido partido_348LC = ObtenerPartidoSinResultado_348LC(idPartido_348LC);

            if (partido_348LC.Suspendido)
                throw new Exception("El partido está suspendido: debe reprogramarse antes de cargar el resultado.");

            if (partido_348LC.FechaPartido.Date + partido_348LC.HoraInicio > DateTime.Now)
                throw new Exception("No se puede cargar el resultado de un partido que todavía no comenzó.");

            dalResultado_348LC.ActualizarResultado_348LC(idPartido_348LC, golesLocal_348LC, golesVisitante_348LC);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }

        public void Suspender_348LC(int idPartido_348LC)
        {
            Partido partido_348LC = ObtenerPartidoSinResultado_348LC(idPartido_348LC);

            if (partido_348LC.Suspendido)
                throw new Exception("El partido ya está suspendido.");

            dalResultado_348LC.MarcarSuspendido_348LC(idPartido_348LC);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }

        public void Reprogramar_348LC(int idPartido_348LC, DateTime fechaPartido_348LC, TimeSpan horaInicio_348LC, int numeroCancha_348LC)
        {
            Partido partido_348LC = ObtenerPartidoSinResultado_348LC(idPartido_348LC);

            if (!partido_348LC.Suspendido)
                throw new Exception("Solo se pueden reprogramar partidos suspendidos.");

            partido_348LC.FechaPartido = fechaPartido_348LC;
            partido_348LC.HoraInicio = horaInicio_348LC;
            partido_348LC.NumeroCancha = numeroCancha_348LC;
            bllPartido_348LC.ValidarProgramacion_348LC(partido_348LC, idPartido_348LC);

            dalResultado_348LC.Reprogramar_348LC(idPartido_348LC, partido_348LC.FechaPartido, partido_348LC.HoraInicio, partido_348LC.NumeroCancha);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }
    }
}


