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

        public void RegistrarResultado_348LC(int idPartido_348LC, int golesLocal_348LC, int golesVisitante_348LC)
        {
            if (golesLocal_348LC < 0 || golesVisitante_348LC < 0)
                throw new Exception("Los goles no pueden ser negativos.");

            dalResultado_348LC.ActualizarResultado_348LC(idPartido_348LC, golesLocal_348LC, golesVisitante_348LC);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }

        public void Suspender_348LC(int idPartido_348LC)
        {
            dalResultado_348LC.MarcarSuspendido_348LC(idPartido_348LC);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }

        public void Reprogramar_348LC(int idPartido_348LC, DateTime fechaPartido_348LC, TimeSpan horaInicio_348LC, int numeroCancha_348LC)
        {
            if (dalPartido_348LC.ObtenerCanchaOcupada_348LC(fechaPartido_348LC, horaInicio_348LC, numeroCancha_348LC, idPartido_348LC) != null)
                throw new Exception("La cancha ya está asignada a otro partido en ese horario.");

            dalResultado_348LC.Reprogramar_348LC(idPartido_348LC, fechaPartido_348LC, horaInicio_348LC, numeroCancha_348LC);
            bllPartido_348LC.RecalcularYGuardar_348LC(dalPartido_348LC.ObtenerPorId_348LC(idPartido_348LC));
        }
    }
}


