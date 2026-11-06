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
    public class BLL_Matricula
    {
        DAL_Matricula dalMatricula_348LC = new DAL_Matricula();
        DAL_Clase dalClase_348LC = new DAL_Clase();
        DAL_Participante dalParticipante_348LC = new DAL_Participante();
        BLL_Pago bllPago_348LC = new BLL_Pago();

        public List<Clase> ListarClasesVigentes_348LC()
        {
            return dalClase_348LC.ListarConInscripcionVigente_348LC();
        }

        public List<Participante> ListarParticipantesDisponibles_348LC(int idClase_348LC)
        {
            List<Matricula> matriculados_348LC = dalMatricula_348LC.ListarPorClase_348LC(idClase_348LC);

            return dalParticipante_348LC.Listar_348LC()
                .Where(p_348LC => !matriculados_348LC.Any(m_348LC => m_348LC.IdParticipante == p_348LC.Id))
                .ToList();
        }

        public List<Matricula> ListarMatriculados_348LC(int idClase_348LC)
        {
            return dalMatricula_348LC.ListarPorClase_348LC(idClase_348LC);
        }

        public Matricula ObtenerPorId_348LC(int idMatricula_348LC)
        {
            return dalMatricula_348LC.ObtenerPorId_348LC(idMatricula_348LC);
        }

        public void Alta_348LC(Matricula matricula_348LC)
        {
            Clase clase_348LC = dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            if (clase_348LC == null || clase_348LC.Eliminado)
                throw new Exception("La clase no existe o fue eliminada.");

            Profesor profesor_348LC = new DAL_Profesor().ObtenerPorId_348LC(clase_348LC.IdProfesor);
            if (profesor_348LC == null || profesor_348LC.Eliminado)
                throw new Exception("El profesor de la clase fue dado de baja; no se pueden inscribir participantes.");

            matricula_348LC.FechaMatricula = DateTime.Today;
            Validar_348LC(matricula_348LC, clase_348LC);

            matricula_348LC.Id = dalMatricula_348LC.AñadirMatricula_348LC(matricula_348LC);
            RecalcularYGuardar_348LC(matricula_348LC);

            try
            {
                bllPago_348LC.Alta_348LC(new Pago
                {
                    IdMatricula = matricula_348LC.Id,
                    Monto = clase_348LC.CostoClase
                });
            }
            catch (Exception ex_348LC)
            {
                Baja_348LC(matricula_348LC.Id);
                throw new Exception("No se pudo generar el pago de la inscripción, por lo que se deshizo la inscripción. " + ex_348LC.Message);
            }
        }

        public void Desinscribir_348LC(int idMatricula_348LC, int idClase_348LC)
        {
            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(idMatricula_348LC);
            if (matricula_348LC == null || matricula_348LC.Eliminado)
                throw new Exception("La inscripción no existe o ya fue dada de baja.");

            if (matricula_348LC.IdClase != idClase_348LC)
                throw new Exception("La inscripción seleccionada no pertenece a la clase elegida.");

            Clase clase_348LC = dalClase_348LC.ObtenerPorId_348LC(matricula_348LC.IdClase);
            if (clase_348LC == null)
                throw new Exception("La clase de la inscripción no existe.");

            if (DateTime.Now >= clase_348LC.Fecha.Date + clase_348LC.HoraInicio)
                throw new Exception("La clase ya comenzó; no se puede desinscribir al participante.");

            Pago pago_348LC =bllPago_348LC.Listar_348LC().FirstOrDefault(p_348LC => p_348LC.IdMatricula == idMatricula_348LC);

            if (pago_348LC != null && pago_348LC.Estado == BLL_Pago.ESTADO_REGISTRADO)
                bllPago_348LC.Reintegrar_348LC(pago_348LC.Id);
            else if (pago_348LC != null && pago_348LC.Estado == BLL_Pago.ESTADO_PENDIENTE)
                bllPago_348LC.Cancelar_348LC(pago_348LC.Id);
            else
                Baja_348LC(idMatricula_348LC);
        }

        public void Baja_348LC(int idMatricula_348LC)
        {
            Matricula matricula_348LC = dalMatricula_348LC.ObtenerPorId_348LC(idMatricula_348LC);
            if (matricula_348LC == null || matricula_348LC.Eliminado)
                throw new Exception("La inscripción no existe o ya fue dada de baja.");

            dalMatricula_348LC.EliminarMatricula_348LC(idMatricula_348LC);
            Matricula matriculaActualizada_348LC = dalMatricula_348LC.ObtenerPorId_348LC(idMatricula_348LC);
            RecalcularYGuardar_348LC(matriculaActualizada_348LC);
        }

        private void Validar_348LC(Matricula matricula_348LC, Clase clase_348LC)
        {
            if (matricula_348LC.IdParticipante <= 0)
                throw new Exception("Seleccioná un participante de la grilla.");

            Participante participante_348LC = dalParticipante_348LC.ObtenerPorId_348LC(matricula_348LC.IdParticipante);
            if (participante_348LC == null || participante_348LC.Eliminado)
                throw new Exception("El participante no existe o fue eliminado.");

            int pagosVencidos_348LC = new DAL_Pago().ContarPendientesVencidosPorParticipante_348LC(matricula_348LC.IdParticipante);
            if (pagosVencidos_348LC > 0)
                throw new Exception($"El participante tiene {pagosVencidos_348LC} pago(s) pendiente(s) de clases que ya se dictaron. Debe regularizarlos antes de inscribirse.");

            if (DateTime.Today < clase_348LC.FechaInicioInscripcion.Date || DateTime.Today > clase_348LC.FechaFinInscripcion.Date)
                throw new Exception($"La inscripción a esta clase está abierta del {clase_348LC.FechaInicioInscripcion:dd/MM/yyyy} al {clase_348LC.FechaFinInscripcion:dd/MM/yyyy}.");

            if (DateTime.Now >= clase_348LC.Fecha.Date + clase_348LC.HoraInicio)
                throw new Exception("La clase ya comenzó; no se pueden inscribir participantes.");

            if (dalMatricula_348LC.ExisteMatricula_348LC(clase_348LC.Id, matricula_348LC.IdParticipante))
                throw new Exception("El participante ya está inscripto en esta clase.");

            if (dalMatricula_348LC.ExisteSuperposicionParticipante_348LC(matricula_348LC.IdParticipante, clase_348LC))
                throw new Exception("El participante ya está inscripto en otra clase que se superpone con ese horario.");

            if (dalMatricula_348LC.ContarMatriculados_348LC(clase_348LC.Id) >= clase_348LC.CupoMaximo)
                throw new Exception("La clase tiene el cupo completo. Ofrecele al participante otra clase.");
        }

        private ValidadorDeIntegridad validador_348LC = new ValidadorDeIntegridad();

        public bool VerificarIntegridad_348LC()
        {
            List<Matricula> matriculas_348LC = dalMatricula_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = matriculas_348LC.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados_348LC = matriculas_348LC.Select(m => m.DVH).ToList();
            int dvvGuardado_348LC = dalMatricula_348LC.ObtenerDVV_348LC();

            return validador_348LC.VerificarIntegridad(objetos_348LC, dvhsGuardados_348LC, dvvGuardado_348LC);
        }

        public void RecalcularYGuardar_348LC(Matricula matricula_348LC)
        {
            int dvh_348LC = validador_348LC.CalcularDV(matricula_348LC);
            dalMatricula_348LC.ActualizarDVH_348LC(matricula_348LC.Id, dvh_348LC);

            List<Matricula> todos_348LC = dalMatricula_348LC.ObtenerTodosParaVerificar_348LC();
            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            int dvv_348LC = validador_348LC.CalcularDVV(objetos_348LC);
            dalMatricula_348LC.ActualizarDVV_348LC(dvv_348LC);
        }

        public void RecalcularTodos_348LC()
        {
            List<Matricula> todos_348LC = dalMatricula_348LC.ObtenerTodosParaVerificar_348LC();
            foreach (Matricula matricula_348LC in todos_348LC)
                dalMatricula_348LC.ActualizarDVH_348LC(matricula_348LC.Id, validador_348LC.CalcularDV(matricula_348LC));

            List<IVerificable> objetos_348LC = todos_348LC.Cast<IVerificable>().ToList();
            dalMatricula_348LC.ActualizarDVV_348LC(validador_348LC.CalcularDVV(objetos_348LC));
        }
    }
}
