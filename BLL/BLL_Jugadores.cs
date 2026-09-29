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
    public class BLL_Jugador
    {
        DAL_Jugador dalJugador_348LC = new DAL_Jugador();
        DAL_Equipo dalEquipo_348LC = new DAL_Equipo();

        public const int SIN_EQUIPO_ID = 0;

        public List<Jugador> Listar_348LC()
        {
            return dalJugador_348LC.Listar_348LC();
        }

        public void Alta_348LC(Jugador jugador_348LC)
        {
            ValidarJugador_348LC(jugador_348LC);
            jugador_348LC.Id = dalJugador_348LC.AñadirJugador_348LC(jugador_348LC);
            RecalcularYGuardar_348LC(jugador_348LC);
        }

        public void Modificar_348LC(int idJugador_348LC, Jugador jugador_348LC)
        {
            jugador_348LC.Id = idJugador_348LC;
            ValidarJugador_348LC(jugador_348LC);
            dalJugador_348LC.ModificarJugador_348LC(idJugador_348LC, jugador_348LC);
            RecalcularYGuardar_348LC(jugador_348LC);
        }

        public void Baja_348LC(int idJugador_348LC)
        {
            dalJugador_348LC.EliminarJugador_348LC(idJugador_348LC);
            Jugador jugadorActualizado_348LC = dalJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);
            RecalcularYGuardar_348LC(jugadorActualizado_348LC);
        }

        public Jugador ObtenerPorId_348LC(int idJugador_348LC)
        {
            return dalJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);
        }

        private void ValidarJugador_348LC(Jugador jugador_348LC)
        {
            if (string.IsNullOrWhiteSpace(jugador_348LC.DNI))
                throw new Exception("El DNI es obligatorio.");

            if (string.IsNullOrWhiteSpace(jugador_348LC.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(jugador_348LC.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (jugador_348LC.Edad <= 0)
                throw new Exception("La edad debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(jugador_348LC.Posicion))
                throw new Exception("La posición es obligatoria.");

            if (jugador_348LC.Numero <= 0)
                throw new Exception("El número de camiseta debe ser mayor a 0.");

            if (dalEquipo_348LC.ObtenerPorId_348LC(jugador_348LC.IdEquipo) == null)
                throw new Exception("El equipo indicado no existe.");
        }

        public List<Jugador> ListarPorEquipo_348LC(int idEquipo_348LC)
        {
            return dalJugador_348LC.ListarPorEquipo_348LC(idEquipo_348LC);
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Jugador> jugadores_348LC = dalJugador_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = jugadores_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = jugadores_348LC.Select(j => j.DVH).ToList();
            int dvvGuardado_348LC = dalJugador_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Jugador jugador_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(jugador_348LC);
            dalJugador_348LC.ActualizarDVH_348LC(jugador_348LC.Id, dvh_348LC);

            List<Jugador> todos_348LC = dalJugador_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalJugador_348LC.ActualizarDVV_348LC(dvv_348LC);
        }
    }


}
