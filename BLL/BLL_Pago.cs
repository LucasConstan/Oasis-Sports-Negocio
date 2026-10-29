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
    public class BLL_Pago
    {
        DAL_Pago dalPago_348LC = new DAL_Pago();
        DAL_Matricula dalMatricula_348LC = new DAL_Matricula();
        DAL_Clase dalClase_348LC = new DAL_Clase();
        BLL_Participante bllParticipante_348LC = new BLL_Participante();

        public const string ESTADO_PENDIENTE = "Pendiente";
        public const string ESTADO_REGISTRADO = "Registrado";
        public const string ESTADO_CANCELADO = "Cancelado";
        public const string ESTADO_REINTEGRADO = "Reintegrado";

        public List<Pago> Listar_348LC()
        {
            return dalPago_348LC.Listar_348LC();
        }

        public void Alta_348LC(Pago pago_348LC)
        {
            pago_348LC.MedioPago = null;
            pago_348LC.FechaPago = null;
            pago_348LC.Estado = ESTADO_PENDIENTE;

            pago_348LC.Id = dalPago_348LC.AñadirPago_348LC(pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);
        }

        public void Registrar_348LC(Pago pago_348LC, Participante participante_348LC)
        {
            Pago pagoActual_348LC = ObtenerPagoPendiente_348LC(pago_348LC.Id);

            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(pagoActual_348LC.IdMatricula);
            if (matricula_348LC == null || matricula_348LC.Eliminado)
                throw new Exception("La inscripción del pago no existe o fue dada de baja.");

            pago_348LC.IdMatricula = pagoActual_348LC.IdMatricula;
            pago_348LC.Monto = pagoActual_348LC.Monto;

            Clase clase_348LC = dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            ValidarPago_348LC(pago_348LC, clase_348LC);

            if (participante_348LC == null || participante_348LC.Id != matricula_348LC.IdParticipante)
                throw new Exception("El participante no corresponde al pago seleccionado.");

            ValidarDatosFacturacion_348LC(participante_348LC);

            pago_348LC.Estado = ESTADO_REGISTRADO;
            dalPago_348LC.ModificarPago_348LC(pago_348LC.Id, pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);
        }

        public void Cancelar_348LC(int idPago_348LC)
        {
            Pago pago_348LC = ObtenerPagoPendiente_348LC(idPago_348LC);

            pago_348LC.Estado = ESTADO_CANCELADO;
            dalPago_348LC.ModificarPago_348LC(pago_348LC.Id, pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);

            new BLL_Matricula().Baja_348LC(pago_348LC.IdMatricula);
        }

        public void Reintegrar_348LC(int idPago_348LC)
        {
            Pago pago_348LC = dalPago_348LC.ObtenerPorId_348LC(idPago_348LC);
            if (pago_348LC == null || pago_348LC.Eliminado)
                throw new Exception("El pago no existe o fue eliminado.");

            if (pago_348LC.Estado != ESTADO_REGISTRADO)
                throw new Exception("Solo se puede reintegrar un pago registrado.");

            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(pago_348LC.IdMatricula);
            Clase clase_348LC = matricula_348LC == null ? null : dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            if (clase_348LC == null)
                throw new Exception("La clase de la inscripción no existe.");

            if (DateTime.Now >= clase_348LC.Fecha.Date + clase_348LC.HoraInicio)
                throw new Exception("La clase ya comenzó; no se puede desinscribir al participante ni reintegrar el pago.");

            pago_348LC.Estado = ESTADO_REINTEGRADO;
            dalPago_348LC.ModificarPago_348LC(pago_348LC.Id, pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);

            new BLL_Matricula().Baja_348LC(pago_348LC.IdMatricula);
        }

        private Pago ObtenerPagoPendiente_348LC(int idPago_348LC)
        {
            Pago pago_348LC = dalPago_348LC.ObtenerPorId_348LC(idPago_348LC);

            if (pago_348LC == null || pago_348LC.Eliminado)
                throw new Exception("El pago no existe o fue eliminado.");

            if (pago_348LC.Estado != ESTADO_PENDIENTE)
                throw new Exception($"El pago ya está {pago_348LC.Estado.ToLower()} y no se puede modificar.");

            return pago_348LC;
        }

        private void ValidarPago_348LC(Pago pago_348LC, Clase clase_348LC)
        {
            if (clase_348LC == null)
                throw new Exception("La clase de la inscripción no existe.");

            if (pago_348LC.Monto != clase_348LC.CostoClase)
                throw new Exception($"El monto debe ser igual al costo de la clase (${clase_348LC.CostoClase:N2}).");

            if (string.IsNullOrWhiteSpace(pago_348LC.MedioPago))
                throw new Exception("Seleccioná un medio de pago.");

            if (!pago_348LC.FechaPago.HasValue)
                throw new Exception("Ingresá la fecha de pago.");

            pago_348LC.FechaPago = pago_348LC.FechaPago.Value.Date;

            if (pago_348LC.FechaPago > DateTime.Today)
                throw new Exception("La fecha de pago no puede ser posterior a hoy.");
        }

        private void ValidarDatosFacturacion_348LC(Participante participante_348LC)
        {
            Participante participanteActual_348LC = bllParticipante_348LC.ObtenerPorId_348LC(participante_348LC.Id);
            if (participanteActual_348LC == null || participanteActual_348LC.Eliminado)
                throw new Exception("El participante no existe o fue eliminado.");

            string dni_348LC = (participanteActual_348LC.DNI ?? "").Trim();

            if (!dni_348LC.All(char.IsDigit) || dni_348LC.Length < 7 || dni_348LC.Length > 8)
                throw new Exception("El DNI del participante no es válido para emitir el comprobante.");
        }

        public string GenerarComprobante_348LC(Pago pago_348LC, Participante participante_348LC)
        {
            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(pago_348LC.IdMatricula);
            Clase clase_348LC = dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);

            StringBuilder comprobante_348LC = new StringBuilder();
            comprobante_348LC.AppendLine($"COMPROBANTE N° {pago_348LC.Id:D8}");
            comprobante_348LC.AppendLine($"Fecha: {pago_348LC.FechaPago:dd/MM/yyyy}");
            comprobante_348LC.AppendLine();
            comprobante_348LC.AppendLine($"DNI: {participante_348LC.DNI}");
            comprobante_348LC.AppendLine($"Nombre: {participante_348LC.Nombre} {participante_348LC.Apellido}");
            if (!string.IsNullOrWhiteSpace(participante_348LC.Direccion))
                comprobante_348LC.AppendLine($"Dirección: {participante_348LC.Direccion}");
            comprobante_348LC.AppendLine();
            comprobante_348LC.AppendLine($"Clase: {clase_348LC.NombreClase}");
            comprobante_348LC.AppendLine($"Fecha y hora: {clase_348LC.Fecha:dd/MM/yyyy} {clase_348LC.HoraInicio:hh\\:mm}");
            comprobante_348LC.AppendLine($"Medio de pago: {pago_348LC.MedioPago}");
            comprobante_348LC.AppendLine($"Total: ${pago_348LC.Monto:N2}");

            return comprobante_348LC.ToString();
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Pago> pagos_348LC = dalPago_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = pagos_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = pagos_348LC.Select(p => p.DVH).ToList();
            int dvvGuardado_348LC = dalPago_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Pago pago_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(pago_348LC);
            dalPago_348LC.ActualizarDVH_348LC(pago_348LC.Id, dvh_348LC);

            List<Pago> todos_348LC = dalPago_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalPago_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Pago> todos_348LC = dalPago_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Pago pago_348LC in todos_348LC)
                dalPago_348LC.ActualizarDVH_348LC(pago_348LC.Id, validador_348LC.CalcularDV(pago_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalPago_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
