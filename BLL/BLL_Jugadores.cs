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
            Jugador jugadorActual_348LC = ObtenerJugadorActivo_348LC(idJugador_348LC);
            jugador_348LC.Id = idJugador_348LC;
            ValidarJugador_348LC(jugador_348LC);
            ValidarCambioDeEquipo_348LC(jugadorActual_348LC.IdEquipo, jugador_348LC.IdEquipo);
            dalJugador_348LC.ModificarJugador_348LC(idJugador_348LC, jugador_348LC);
            RecalcularYGuardar_348LC(jugador_348LC);
        }

        public void Baja_348LC(int idJugador_348LC)
        {
            ObtenerJugadorActivo_348LC(idJugador_348LC);
            dalJugador_348LC.EliminarJugador_348LC(idJugador_348LC);
            Jugador jugadorActualizado_348LC = dalJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);
            RecalcularYGuardar_348LC(jugadorActualizado_348LC);
        }

        public Jugador ObtenerPorId_348LC(int idJugador_348LC)
        {
            return dalJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);
        }

        private Jugador ObtenerJugadorActivo_348LC(int idJugador_348LC)
        {
            Jugador jugador_348LC = dalJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);

            if (jugador_348LC == null || jugador_348LC.Eliminado)
                throw new Exception("El jugador no existe o fue eliminado.");

            return jugador_348LC;
        }

        private void ValidarCambioDeEquipo_348LC(int idEquipoActual_348LC, int idEquipoNuevo_348LC)
        {
            if (idEquipoActual_348LC == idEquipoNuevo_348LC || idEquipoActual_348LC == SIN_EQUIPO_ID || idEquipoNuevo_348LC == SIN_EQUIPO_ID)
                return;

            DAL_Inscripcion dalInscripcion_348LC = new DAL_Inscripcion();
            List<int> torneosActual_348LC = dalInscripcion_348LC.ListarTorneosActivosDelEquipo_348LC(idEquipoActual_348LC);
            List<int> torneosNuevo_348LC = dalInscripcion_348LC.ListarTorneosActivosDelEquipo_348LC(idEquipoNuevo_348LC);

            if (torneosActual_348LC.Intersect(torneosNuevo_348LC).Any())
                throw new Exception("No se puede cambiar al jugador de equipo: su equipo actual y el nuevo participan del mismo torneo.");
        }

        private bool SoloLetras_348LC(string texto_348LC)
        {
            return texto_348LC.All(c_348LC => char.IsLetter(c_348LC) || c_348LC == ' ' || c_348LC == '\'' || c_348LC == '-' || c_348LC == '.');
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

            Equipo equipo_348LC = dalEquipo_348LC.ObtenerPorId_348LC(jugador_348LC.IdEquipo);
            if (equipo_348LC == null || equipo_348LC.Eliminado)
                throw new Exception("El equipo indicado no existe o fue eliminado.");

            jugador_348LC.DNI = jugador_348LC.DNI.Trim();
            jugador_348LC.Nombre = jugador_348LC.Nombre.Trim();
            jugador_348LC.Apellido = jugador_348LC.Apellido.Trim();
            jugador_348LC.Posicion = jugador_348LC.Posicion.Trim();

            if (jugador_348LC.Posicion.Length > 30)
                throw new Exception("La posición no puede superar los 30 caracteres.");

            if (!SoloLetras_348LC(jugador_348LC.Posicion))
                throw new Exception("La posición solo puede contener letras y espacios.");

            string dni_348LC = jugador_348LC.DNI;

            if (!dni_348LC.All(char.IsDigit))
                throw new Exception("El DNI solo puede contener números.");

            if (dni_348LC.Length < 7 || dni_348LC.Length > 8)
                throw new Exception("El DNI debe tener 7 u 8 dígitos.");

            if (jugador_348LC.Nombre.Trim().Length < 2 || jugador_348LC.Nombre.Trim().Length > 50)
                throw new Exception("El nombre debe tener entre 2 y 50 caracteres.");

            if (jugador_348LC.Apellido.Trim().Length < 2 || jugador_348LC.Apellido.Trim().Length > 50)
                throw new Exception("El apellido debe tener entre 2 y 50 caracteres.");

            if (!SoloLetras_348LC(jugador_348LC.Nombre) || !SoloLetras_348LC(jugador_348LC.Apellido))
                throw new Exception("El nombre y el apellido solo pueden contener letras y espacios.");

            if (jugador_348LC.Edad < 10 || jugador_348LC.Edad > 60)
                throw new Exception("La edad debe estar entre 10 y 60 años.");

            if (jugador_348LC.Numero > 99)
                throw new Exception("El número de camiseta no puede ser mayor a 99.");

            List<Jugador> jugadores_348LC = dalJugador_348LC.Listar_348LC();

            if (jugadores_348LC.Any(j_348LC => j_348LC.Id != jugador_348LC.Id && j_348LC.DNI.Trim() == dni_348LC))
                throw new Exception("Ya existe un jugador con ese DNI.");

            bool numeroRepetido_348LC = jugador_348LC.IdEquipo != SIN_EQUIPO_ID && jugadores_348LC.Any(j_348LC =>
                j_348LC.Id != jugador_348LC.Id &&
                j_348LC.IdEquipo == jugador_348LC.IdEquipo &&
                j_348LC.Numero == jugador_348LC.Numero);

            if (numeroRepetido_348LC)
                throw new Exception($"Ya hay un jugador con el número {jugador_348LC.Numero} en ese equipo.");
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

        public void RecalcularTodos_348LC()
        {
            List<Jugador> todos_348LC = dalJugador_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Jugador jugador_348LC in todos_348LC)
                dalJugador_348LC.ActualizarDVH_348LC(jugador_348LC.Id, validador_348LC.CalcularDV(jugador_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalJugador_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }


}
