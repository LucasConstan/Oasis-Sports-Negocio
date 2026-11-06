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

        public const string MEDIO_EFECTIVO = "Efectivo";
        public const string MEDIO_DEBITO = "Tarjeta de débito";
        public const string MEDIO_CREDITO = "Tarjeta de crédito";
        public const string MEDIO_TRANSFERENCIA = "Transferencia";

        public static readonly string[] MEDIOS_PAGO = { MEDIO_EFECTIVO, MEDIO_DEBITO, MEDIO_CREDITO, MEDIO_TRANSFERENCIA };
        public static readonly string[] MARCAS_TARJETA = { "Visa", "Mastercard", "American Express", "Cabal", "Naranja", "Maestro" };
        public static readonly string[] BANCOS_SUGERIDOS = { "Mercado Pago", "Ualá", "Naranja X", "Brubank", "Banco Galicia", "Banco Nación", "Banco Provincia", "Banco Santander", "BBVA", "Banco Macro", "ICBC" };

        public static bool EsTarjeta_348LC(string medioPago_348LC)
        {
            return medioPago_348LC == MEDIO_DEBITO || medioPago_348LC == MEDIO_CREDITO;
        }

        public List<Pago> Listar_348LC()
        {
            return dalPago_348LC.Listar_348LC();
        }

        public void Alta_348LC(Pago pago_348LC)
        {
            if (dalPago_348LC.Listar_348LC().Any(p_348LC => p_348LC.IdMatricula == pago_348LC.IdMatricula))
                throw new Exception("La inscripción ya tiene un pago generado.");

            pago_348LC.MedioPago = null;
            pago_348LC.FechaPago = null;
            pago_348LC.Estado = ESTADO_PENDIENTE;

            pago_348LC.Id = dalPago_348LC.AñadirPago_348LC(pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);
        }

        public void Registrar_348LC(Pago pago_348LC, Participante participante_348LC)
        {
            ValidarRegistro_348LC(pago_348LC, participante_348LC);

            pago_348LC.Estado = ESTADO_REGISTRADO;
            dalPago_348LC.ModificarPago_348LC(pago_348LC.Id, pago_348LC);
            RecalcularYGuardar_348LC(pago_348LC);
        }

        public void ValidarRegistro_348LC(Pago pago_348LC, Participante participante_348LC)
        {
            Pago pagoActual_348LC = ObtenerPagoPendiente_348LC(pago_348LC.Id);

            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(pagoActual_348LC.IdMatricula);
            if (matricula_348LC == null || matricula_348LC.Eliminado)
                throw new Exception("La inscripción del pago no existe o fue dada de baja.");

            pago_348LC.IdMatricula = pagoActual_348LC.IdMatricula;
            pago_348LC.Monto = pagoActual_348LC.Monto;

            Clase clase_348LC = dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            ValidarPago_348LC(pago_348LC, clase_348LC);

            if (pago_348LC.FechaPago.Value < matricula_348LC.FechaMatricula.Date)
                throw new Exception($"La fecha de pago no puede ser anterior a la fecha de inscripción ({matricula_348LC.FechaMatricula:dd/MM/yyyy}).");

            if (participante_348LC == null || participante_348LC.Id != matricula_348LC.IdParticipante)
                throw new Exception("El participante no corresponde al pago seleccionado.");

            ValidarDatosFacturacion_348LC(participante_348LC);
        }

        public void Cancelar_348LC(int idPago_348LC)
        {
            Pago pago_348LC = ObtenerPagoPendiente_348LC(idPago_348LC);

            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(pago_348LC.IdMatricula);
            Clase clase_348LC = matricula_348LC == null ? null : dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            if (clase_348LC == null)
                throw new Exception("La clase de la inscripción no existe.");

            if (DateTime.Now >= clase_348LC.Fecha.Date + clase_348LC.HoraInicio)
                throw new Exception("La clase ya comenzó; no se puede cancelar el pago ni dar de baja la inscripción.");

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
            if (clase_348LC == null || clase_348LC.Eliminado)
                throw new Exception("La clase de la inscripción no existe o fue eliminada.");

            if (pago_348LC.Monto != clase_348LC.CostoClase)
                throw new Exception($"El monto debe ser igual al costo de la clase (${clase_348LC.CostoClase:N2}).");

            if (string.IsNullOrWhiteSpace(pago_348LC.MedioPago))
                throw new Exception("Seleccioná un medio de pago.");

            if (!MEDIOS_PAGO.Contains(pago_348LC.MedioPago))
                throw new Exception("El medio de pago seleccionado no es válido.");

            ValidarDetalleMedioPago_348LC(pago_348LC);

            if (!pago_348LC.FechaPago.HasValue)
                throw new Exception("Ingresá la fecha de pago.");

            pago_348LC.FechaPago = pago_348LC.FechaPago.Value.Date;

            if (pago_348LC.FechaPago > DateTime.Today)
                throw new Exception("La fecha de pago no puede ser posterior a hoy.");
        }

        private void ValidarDetalleMedioPago_348LC(Pago pago_348LC)
        {
            pago_348LC.MarcaTarjeta = (pago_348LC.MarcaTarjeta ?? "").Trim();
            pago_348LC.UltimosDigitos = (pago_348LC.UltimosDigitos ?? "").Trim();
            pago_348LC.BancoOrigen = (pago_348LC.BancoOrigen ?? "").Trim();

            if (EsTarjeta_348LC(pago_348LC.MedioPago))
            {
                if (pago_348LC.MarcaTarjeta == "")
                    throw new Exception("Seleccioná la marca de la tarjeta.");

                if (!MARCAS_TARJETA.Contains(pago_348LC.MarcaTarjeta))
                    throw new Exception("La marca de tarjeta seleccionada no es válida.");

                if (pago_348LC.UltimosDigitos == "")
                    throw new Exception("Ingresá los últimos 4 dígitos de la tarjeta.");

                if (pago_348LC.UltimosDigitos.Length != 4 || !pago_348LC.UltimosDigitos.All(char.IsDigit))
                    throw new Exception("Los últimos dígitos de la tarjeta deben ser exactamente 4 números.");

                pago_348LC.BancoOrigen = null;
            }
            else if (pago_348LC.MedioPago == MEDIO_TRANSFERENCIA)
            {
                if (pago_348LC.BancoOrigen == "")
                    throw new Exception("Ingresá el banco o la billetera virtual desde donde se hizo la transferencia.");

                if (pago_348LC.BancoOrigen.Length < 2 || pago_348LC.BancoOrigen.Length > 50)
                    throw new Exception("El banco o billetera debe tener entre 2 y 50 caracteres.");

                if (!pago_348LC.BancoOrigen.Any(char.IsLetter))
                    throw new Exception("El banco o billetera debe contener al menos una letra.");

                if (!pago_348LC.BancoOrigen.All(c_348LC => char.IsLetterOrDigit(c_348LC) || " .-&".Contains(c_348LC)))
                    throw new Exception("El banco o billetera solo puede contener letras, números, espacios y los signos . - &.");

                pago_348LC.MarcaTarjeta = null;
                pago_348LC.UltimosDigitos = null;
            }
            else
            {
                pago_348LC.MarcaTarjeta = null;
                pago_348LC.UltimosDigitos = null;
                pago_348LC.BancoOrigen = null;
            }
        }

        public static string ObtenerDetalleMedioPago_348LC(Pago pago_348LC)
        {
            if (EsTarjeta_348LC(pago_348LC.MedioPago) && !string.IsNullOrEmpty(pago_348LC.MarcaTarjeta))
                return $"{pago_348LC.MedioPago} ({pago_348LC.MarcaTarjeta} terminada en {pago_348LC.UltimosDigitos})";

            if (pago_348LC.MedioPago == MEDIO_TRANSFERENCIA && !string.IsNullOrEmpty(pago_348LC.BancoOrigen))
                return $"{pago_348LC.MedioPago} ({pago_348LC.BancoOrigen})";

            return pago_348LC.MedioPago;
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
            comprobante_348LC.AppendLine($"Medio de pago: {ObtenerDetalleMedioPago_348LC(pago_348LC)}");
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
