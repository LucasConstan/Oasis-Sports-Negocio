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
    public class BLL_Clase
    {
        DAL_Clase dalClase_348LC = new DAL_Clase();
        BLL_Profesor bllProfesor_348LC = new BLL_Profesor();

        public const int CANTIDAD_CANCHAS = 5;
        public const int DURACION_MINIMA_MINUTOS = 30;
        public const int DURACION_MAXIMA_MINUTOS = 180;
        public const int INTERVALO_DURACION_MINUTOS = 15;

        public void ValidarDatos_348LC(Clase clase_348LC)
        {
            if (string.IsNullOrWhiteSpace(clase_348LC.NombreClase))
                throw new Exception("El nombre de la clase es obligatorio.");

            clase_348LC.NombreClase = clase_348LC.NombreClase.Trim();
            clase_348LC.Descripcion = (clase_348LC.Descripcion ?? "").Trim();
            clase_348LC.Fecha = clase_348LC.Fecha.Date;
            clase_348LC.HoraInicio = new TimeSpan(clase_348LC.HoraInicio.Hours, clase_348LC.HoraInicio.Minutes, 0);

            if (clase_348LC.NombreClase.Length < 3)
                throw new Exception("El nombre de la clase debe tener al menos 3 caracteres.");

            if (clase_348LC.NombreClase.Length > 50)
                throw new Exception("El nombre de la clase no puede superar los 50 caracteres.");

            if (!clase_348LC.NombreClase.Any(char.IsLetter))
                throw new Exception("El nombre de la clase debe contener al menos una letra.");

            if (!clase_348LC.NombreClase.All(c_348LC => char.IsLetterOrDigit(c_348LC) || " -.,'()".Contains(c_348LC)))
                throw new Exception("El nombre de la clase solo puede contener letras, números, espacios y los signos - . , ' ( ).");

            if (clase_348LC.Descripcion.Length > 200)
                throw new Exception("La descripción no puede superar los 200 caracteres.");

            if (clase_348LC.Fecha < DateTime.Today)
                throw new Exception("La fecha de la clase no puede ser anterior a hoy.");

            if (clase_348LC.Fecha > DateTime.Today.AddYears(1))
                throw new Exception("La clase no puede programarse con más de un año de anticipación.");

            if (clase_348LC.Fecha + clase_348LC.HoraInicio <= DateTime.Now)
                throw new Exception("No se puede crear una clase en un horario que ya pasó.");

            if (clase_348LC.Duracion < DURACION_MINIMA_MINUTOS || clase_348LC.Duracion > DURACION_MAXIMA_MINUTOS)
                throw new Exception($"La duración debe estar entre {DURACION_MINIMA_MINUTOS} y {DURACION_MAXIMA_MINUTOS} minutos.");

            if (clase_348LC.Duracion % INTERVALO_DURACION_MINUTOS != 0)
                throw new Exception($"La duración debe ser múltiplo de {INTERVALO_DURACION_MINUTOS} minutos.");

            if (clase_348LC.HoraInicio.Add(TimeSpan.FromMinutes(clase_348LC.Duracion)) >= TimeSpan.FromHours(24))
                throw new Exception("La clase debe terminar antes de la medianoche.");

            if (clase_348LC.CupoMaximo <= 0)
                throw new Exception("El cupo máximo debe ser mayor a 0.");
        }

        public List<Profesor> ListarProfesoresDisponibles_348LC(Clase clase_348LC)
        {
            ValidarDatos_348LC(clase_348LC);
            return bllProfesor_348LC.ListarDisponibles_348LC(clase_348LC);
        }

        public void Alta_348LC(Clase clase_348LC)
        {
            ValidarDatos_348LC(clase_348LC);
            Validar_348LC(clase_348LC);

            if (dalClase_348LC.ExisteClaseDuplicada_348LC(clase_348LC))
                throw new Exception("Ya existe una clase con ese nombre en la misma fecha y hora.");

            if (dalClase_348LC.ExisteSuperposicion_348LC(clase_348LC))
                throw new Exception("El profesor o la cancha ya tienen otra clase en ese horario.");

            TimeSpan finClase_348LC = clase_348LC.HoraInicio.Add(TimeSpan.FromMinutes(clase_348LC.Duracion));
            bool canchaConPartido_348LC = new DAL_Partido().ListarPorFechaYCancha_348LC(clase_348LC.Fecha, clase_348LC.NumeroCancha).Any(p_348LC =>
                p_348LC.HoraInicio < finClase_348LC &&
                clase_348LC.HoraInicio < p_348LC.HoraInicio.Add(TimeSpan.FromMinutes(BLL_Partido.DURACION_PARTIDO_MINUTOS)));

            if (canchaConPartido_348LC)
                throw new Exception("La cancha tiene un partido de torneo programado en ese horario.");

            clase_348LC.Id = dalClase_348LC.AñadirClase_348LC(clase_348LC);
            RecalcularYGuardar_348LC(clase_348LC);
        }

        private void Validar_348LC(Clase clase_348LC)
        {
            if (clase_348LC.IdProfesor <= 0)
                throw new Exception("Seleccioná un profesor disponible.");

            Profesor profesor_348LC = bllProfesor_348LC.ObtenerPorId_348LC(clase_348LC.IdProfesor);
            if (profesor_348LC == null || profesor_348LC.Eliminado)
                throw new Exception("El profesor seleccionado no existe o fue eliminado.");

            if (clase_348LC.NumeroCancha <= 0)
                throw new Exception("Seleccioná una cancha.");

            if (clase_348LC.NumeroCancha > CANTIDAD_CANCHAS)
                throw new Exception($"La cancha seleccionada no existe. El predio tiene canchas del 1 al {CANTIDAD_CANCHAS}.");

            if (clase_348LC.CostoClase <= 0)
                throw new Exception("El costo de la clase debe ser mayor a 0.");

            if (clase_348LC.CostoClase > 999999.99m)
                throw new Exception("El costo de la clase no puede superar los $999.999,99.");

            clase_348LC.FechaInicioInscripcion = clase_348LC.FechaInicioInscripcion.Date;
            clase_348LC.FechaFinInscripcion = clase_348LC.FechaFinInscripcion.Date;

            if (clase_348LC.FechaInicioInscripcion < DateTime.Today)
                throw new Exception("El inicio de la inscripción no puede ser anterior a hoy.");

            if (clase_348LC.FechaInicioInscripcion > clase_348LC.FechaFinInscripcion)
                throw new Exception("El inicio de la inscripción no puede ser posterior al fin.");

            if (clase_348LC.FechaFinInscripcion > clase_348LC.Fecha)
                throw new Exception("La inscripción debe cerrar antes o el mismo día de la clase.");

            if (clase_348LC.FechaFinInscripcion < DateTime.Today)
                throw new Exception("El fin de la inscripción no puede ser anterior a hoy.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Clase> clases_348LC = dalClase_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = clases_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = clases_348LC.Select(c => c.DVH).ToList();
            int dvvGuardado_348LC = dalClase_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Clase clase_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(clase_348LC);
            dalClase_348LC.ActualizarDVH_348LC(clase_348LC.Id, dvh_348LC);

            List<Clase> todos_348LC = dalClase_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalClase_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Clase> todos_348LC = dalClase_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Clase clase_348LC in todos_348LC)
                dalClase_348LC.ActualizarDVH_348LC(clase_348LC.Id, validador_348LC.CalcularDV(clase_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalClase_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
