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
    public class BLL_Participante
    {
        DAL_Participante dalParticipante_348LC = new DAL_Participante();

        public List<Participante> Listar_348LC()
        {
            return dalParticipante_348LC.Listar_348LC();
        }

        public void Alta_348LC(Participante participante_348LC)
        {
            Validar_348LC(participante_348LC);
            participante_348LC.Id = dalParticipante_348LC.AñadirParticipante_348LC(participante_348LC);
            RecalcularYGuardar_348LC(participante_348LC);
        }

        public void Modificar_348LC(int idParticipante_348LC, Participante participante_348LC)
        {
            ObtenerParticipanteActivo_348LC(idParticipante_348LC);
            participante_348LC.Id = idParticipante_348LC;
            Validar_348LC(participante_348LC);
            dalParticipante_348LC.ModificarParticipante_348LC(idParticipante_348LC, participante_348LC);
            RecalcularYGuardar_348LC(participante_348LC);
        }

        public void Baja_348LC(int idParticipante_348LC)
        {
            ObtenerParticipanteActivo_348LC(idParticipante_348LC);
            dalParticipante_348LC.EliminarParticipante_348LC(idParticipante_348LC);
            Participante participanteActualizado_348LC = dalParticipante_348LC.ObtenerPorId_348LC(idParticipante_348LC);
            RecalcularYGuardar_348LC(participanteActualizado_348LC);
        }

        public Participante ObtenerPorId_348LC(int idParticipante_348LC)
        {
            return dalParticipante_348LC.ObtenerPorId_348LC(idParticipante_348LC);
        }
        private Participante ObtenerParticipanteActivo_348LC(int idParticipante_348LC)
        {
            Participante participante_348LC = dalParticipante_348LC.ObtenerPorId_348LC(idParticipante_348LC);

            if (participante_348LC == null || participante_348LC.Eliminado)
                throw new Exception("El participante no existe o fue eliminado.");

            return participante_348LC;
        }

        private bool SoloLetras_348LC(string texto_348LC)
        {
            return texto_348LC.All(c_348LC => char.IsLetter(c_348LC) || c_348LC == ' ' || c_348LC == '\'' || c_348LC == '-' || c_348LC == '.');
        }

        private void Validar_348LC(Participante participante_348LC)
        {
            if (string.IsNullOrWhiteSpace(participante_348LC.DNI))
                throw new Exception("El DNI es obligatorio.");

            if (string.IsNullOrWhiteSpace(participante_348LC.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(participante_348LC.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (participante_348LC.Edad <= 0)
                throw new Exception("La edad debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(participante_348LC.Telefono))
                throw new Exception("El teléfono es obligatorio.");

            participante_348LC.DNI = participante_348LC.DNI.Trim();
            participante_348LC.Nombre = participante_348LC.Nombre.Trim();
            participante_348LC.Apellido = participante_348LC.Apellido.Trim();
            participante_348LC.Telefono = participante_348LC.Telefono.Trim();
            participante_348LC.Direccion = (participante_348LC.Direccion ?? "").Trim();

            string dni_348LC = participante_348LC.DNI;

            if (!dni_348LC.All(char.IsDigit))
                throw new Exception("El DNI solo puede contener números.");

            if (dni_348LC.Length < 7 || dni_348LC.Length > 8)
                throw new Exception("El DNI debe tener 7 u 8 dígitos.");

            if (participante_348LC.Nombre.Length < 2 || participante_348LC.Nombre.Length > 50)
                throw new Exception("El nombre debe tener entre 2 y 50 caracteres.");

            if (participante_348LC.Apellido.Length < 2 || participante_348LC.Apellido.Length > 50)
                throw new Exception("El apellido debe tener entre 2 y 50 caracteres.");

            if (!SoloLetras_348LC(participante_348LC.Nombre) || !SoloLetras_348LC(participante_348LC.Apellido))
                throw new Exception("El nombre y el apellido solo pueden contener letras y espacios.");

            if (participante_348LC.Edad < 5 || participante_348LC.Edad > 100)
                throw new Exception("La edad debe estar entre 5 y 100 años.");

            string telefono_348LC = participante_348LC.Telefono;

            if (!telefono_348LC.All(c_348LC => char.IsDigit(c_348LC) || c_348LC == ' ' || c_348LC == '-' || c_348LC == '+'))
                throw new Exception("El teléfono solo puede contener números, espacios, guiones y el signo +.");

            int digitosTelefono_348LC = telefono_348LC.Count(char.IsDigit);
            if (digitosTelefono_348LC < 8 || digitosTelefono_348LC > 15)
                throw new Exception("El teléfono debe tener entre 8 y 15 dígitos.");

            if (telefono_348LC.Length > 20)
                throw new Exception("El teléfono no puede superar los 20 caracteres.");

            if (participante_348LC.Direccion.Length > 150)
                throw new Exception("La dirección no puede superar los 150 caracteres.");

            List<Participante> participantes_348LC = dalParticipante_348LC.Listar_348LC();

            if (participantes_348LC.Any(p_348LC => p_348LC.Id != participante_348LC.Id && p_348LC.DNI.Trim() == dni_348LC))
                throw new Exception("Ya existe un participante con ese DNI.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Participante> participantes_348LC = dalParticipante_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = participantes_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = participantes_348LC.Select(p => p.DVH).ToList();
            int dvvGuardado_348LC = dalParticipante_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Participante participante_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(participante_348LC);
            dalParticipante_348LC.ActualizarDVH_348LC(participante_348LC.Id, dvh_348LC);

            List<Participante> todos_348LC = dalParticipante_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalParticipante_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Participante> todos_348LC = dalParticipante_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Participante participante_348LC in todos_348LC)
                dalParticipante_348LC.ActualizarDVH_348LC(participante_348LC.Id, validador_348LC.CalcularDV(participante_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalParticipante_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
