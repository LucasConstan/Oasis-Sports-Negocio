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
    public class BLL_Profesor
    {
        DAL_Profesor dalProfesor_348LC = new DAL_Profesor();

        public List<Profesor> Listar_348LC()
        {
            return dalProfesor_348LC.Listar_348LC();
        }

        public void Alta_348LC(Profesor profesor_348LC)
        {
            Validar_348LC(profesor_348LC);
            profesor_348LC.Id = dalProfesor_348LC.AñadirProfesor_348LC(profesor_348LC);
            RecalcularYGuardar_348LC(profesor_348LC);
        }

        public void Modificar_348LC(int idProfesor_348LC, Profesor profesor_348LC)
        {
            ObtenerProfesorActivo_348LC(idProfesor_348LC);
            profesor_348LC.Id = idProfesor_348LC;
            Validar_348LC(profesor_348LC);
            dalProfesor_348LC.ModificarProfesor_348LC(idProfesor_348LC, profesor_348LC);
            RecalcularYGuardar_348LC(profesor_348LC);
        }

        public void Baja_348LC(int idProfesor_348LC)
        {
            ObtenerProfesorActivo_348LC(idProfesor_348LC);
            dalProfesor_348LC.EliminarProfesor_348LC(idProfesor_348LC);
            Profesor profesorActualizado_348LC = dalProfesor_348LC.ObtenerPorId_348LC(idProfesor_348LC);
            RecalcularYGuardar_348LC(profesorActualizado_348LC);
        }

        public Profesor ObtenerPorId_348LC(int idProfesor_348LC)
        {
            return dalProfesor_348LC.ObtenerPorId_348LC(idProfesor_348LC);
        }

        public List<Profesor> ListarDisponibles_348LC(Clase clase_348LC)
        {
            return dalProfesor_348LC.ListarDisponibles_348LC(clase_348LC);
        }

        private Profesor ObtenerProfesorActivo_348LC(int idProfesor_348LC)
        {
            Profesor profesor_348LC = dalProfesor_348LC.ObtenerPorId_348LC(idProfesor_348LC);

            if (profesor_348LC == null || profesor_348LC.Eliminado)
                throw new Exception("El profesor no existe o fue eliminado.");

            return profesor_348LC;
        }

        private bool SoloLetras_348LC(string texto_348LC)
        {
            return texto_348LC.All(c_348LC => char.IsLetter(c_348LC) || c_348LC == ' ' || c_348LC == '\'' || c_348LC == '-' || c_348LC == '.');
        }

        private void Validar_348LC(Profesor profesor_348LC)
        {
            if (string.IsNullOrWhiteSpace(profesor_348LC.DNI))
                throw new Exception("El DNI es obligatorio.");

            if (string.IsNullOrWhiteSpace(profesor_348LC.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(profesor_348LC.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(profesor_348LC.Especialidad))
                throw new Exception("La especialidad es obligatoria.");

            profesor_348LC.DNI = profesor_348LC.DNI.Trim();
            profesor_348LC.Nombre = profesor_348LC.Nombre.Trim();
            profesor_348LC.Apellido = profesor_348LC.Apellido.Trim();
            profesor_348LC.Especialidad = profesor_348LC.Especialidad.Trim();

            string dni_348LC = profesor_348LC.DNI;

            if (!dni_348LC.All(char.IsDigit))
                throw new Exception("El DNI solo puede contener números.");

            if (dni_348LC.Length < 7 || dni_348LC.Length > 8)
                throw new Exception("El DNI debe tener 7 u 8 dígitos.");

            if (profesor_348LC.Nombre.Length < 2 || profesor_348LC.Nombre.Length > 50)
                throw new Exception("El nombre debe tener entre 2 y 50 caracteres.");

            if (profesor_348LC.Apellido.Length < 2 || profesor_348LC.Apellido.Length > 50)
                throw new Exception("El apellido debe tener entre 2 y 50 caracteres.");

            if (!SoloLetras_348LC(profesor_348LC.Nombre) || !SoloLetras_348LC(profesor_348LC.Apellido))
                throw new Exception("El nombre y el apellido solo pueden contener letras y espacios.");

            if (profesor_348LC.Especialidad.Length < 3 || profesor_348LC.Especialidad.Length > 50)
                throw new Exception("La especialidad debe tener entre 3 y 50 caracteres.");

            if (!profesor_348LC.Especialidad.All(c_348LC => char.IsLetterOrDigit(c_348LC) || c_348LC == ' ' || c_348LC == '-' || c_348LC == '.'))
                throw new Exception("La especialidad solo puede contener letras, números y espacios.");

            bool dniDuplicado_348LC = dalProfesor_348LC.Listar_348LC().Any(p_348LC =>
                p_348LC.Id != profesor_348LC.Id && p_348LC.DNI.Trim() == dni_348LC);

            if (dniDuplicado_348LC)
                throw new Exception("Ya existe un profesor con ese DNI.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Profesor> profesores_348LC = dalProfesor_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = profesores_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = profesores_348LC.Select(p => p.DVH).ToList();
            int dvvGuardado_348LC = dalProfesor_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Profesor profesor_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(profesor_348LC);
            dalProfesor_348LC.ActualizarDVH_348LC(profesor_348LC.Id, dvh_348LC);

            List<Profesor> todos_348LC = dalProfesor_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalProfesor_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Profesor> todos_348LC = dalProfesor_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Profesor profesor_348LC in todos_348LC)
                dalProfesor_348LC.ActualizarDVH_348LC(profesor_348LC.Id, validador_348LC.CalcularDV(profesor_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalProfesor_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
