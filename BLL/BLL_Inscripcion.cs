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
    public class BLL_Inscripcion
    {
        DAL_Inscripcion dalInscripcion_348LC = new DAL_Inscripcion();
        DAL_Torneo dalTorneo_348LC = new DAL_Torneo();

        public List<Equipo> ListarEquiposDelTorneo_348LC(int idTorneo_348LC)
        {
            return dalInscripcion_348LC.ListarEquiposDelTorneo_348LC(idTorneo_348LC);
        }

        public void AltaEquipo_348LC(int idTorneo_348LC, int idEquipo_348LC)
        {
            if (dalInscripcion_348LC.ObtenerInscripcion_348LC(idTorneo_348LC, idEquipo_348LC) != null)
                throw new Exception("El equipo ya está inscripto en este torneo.");

            Torneo torneo_348LC = dalTorneo_348LC.ObtenerPorId_348LC(idTorneo_348LC);
            int cantidadActual_348LC = dalInscripcion_348LC.ListarEquiposDelTorneo_348LC(idTorneo_348LC).Count;

            if (cantidadActual_348LC >= torneo_348LC.CantidadMaximaEquipos)
                throw new Exception("Se alcanzó la cantidad máxima de equipos del torneo.");

            Inscripcion inscripcion_348LC = new Inscripcion
            {
                IdTorneo = idTorneo_348LC,
                IdEquipo = idEquipo_348LC,
                FechaInscripcion = DateTime.Now
            };

            inscripcion_348LC.Id = dalInscripcion_348LC.AñadirInscripcion_348LC(inscripcion_348LC);
            RecalcularYGuardar_348LC(inscripcion_348LC);
        }

        public void BajaEquipo_348LC(int idTorneo_348LC, int idEquipo_348LC)
        {
            Inscripcion inscripcion_348LC = dalInscripcion_348LC.ObtenerInscripcion_348LC(idTorneo_348LC, idEquipo_348LC);

            if (inscripcion_348LC == null)
                throw new Exception("El equipo no está inscripto en este torneo.");

            dalInscripcion_348LC.EliminarInscripcion_348LC(inscripcion_348LC.Id);
            inscripcion_348LC.Eliminado = true;
            RecalcularYGuardar_348LC(inscripcion_348LC);
        }

        public void ValidarJugadorEnTorneo_348LC(int idTorneo_348LC, string dni_348LC, int idEquipoDestino_348LC)
        {
            Jugador jugadorExistente_348LC = dalInscripcion_348LC.ObtenerJugadorEnTorneo_348LC(idTorneo_348LC, dni_348LC);

            if (jugadorExistente_348LC == null)
                return;

            if (jugadorExistente_348LC.IdEquipo == idEquipoDestino_348LC)
                throw new Exception("El jugador ya está registrado en este equipo. Verificá su información en la grilla.");

            throw new Exception("El jugador ya pertenece a otro equipo de este torneo. Verificá la situación antes de asociarlo nuevamente.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Inscripcion> inscripciones_348LC = dalInscripcion_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = inscripciones_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = inscripciones_348LC.Select(i => i.DVH).ToList();
            int dvvGuardado_348LC = dalInscripcion_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Inscripcion inscripcion_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(inscripcion_348LC);
            dalInscripcion_348LC.ActualizarDVH_348LC(inscripcion_348LC.Id, dvh_348LC);

            List<Inscripcion> todos_348LC = dalInscripcion_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalInscripcion_348LC.ActualizarDVV_348LC(dvv_348LC);
        }
    }
}
