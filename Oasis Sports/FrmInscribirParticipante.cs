using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class FrmInscribirParticipante : BaseForm, IObserverIdioma
    {
        BLL_Matricula bllMatricula_348LC = new BLL_Matricula();

        public FrmInscribirParticipante()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmInscribirParticipante_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            CargarClases_348LC();
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LanguageManager.GetInstance().TraducirControles(this)));
            else
                LanguageManager.GetInstance().TraducirControles(this);
        }

        private void RegistrarClaves()
        {
            int idIdioma = LanguageManager.GetInstance().IdIdiomaActual;
            BLL_Traduccion bll = new BLL_Traduccion();
            List<string> clavesExistentes = bll.ObtenerTodasLasClaves();

            foreach (Control c in this.Controls)
                RegistrarRecursivo(c, idIdioma, bll, clavesExistentes);
        }

        private void RegistrarRecursivo(Control c, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            if (!string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text)
                && !clavesExistentes.Contains(c.Name))
            {
                bll.GuardarOActualizar(new Traduccion
                {
                    IdIdioma = idIdioma,
                    Clave = c.Name,
                    Texto = c.Text
                });
                clavesExistentes.Add(c.Name);
            }

            foreach (Control hijo in c.Controls)
                RegistrarRecursivo(hijo, idIdioma, bll, clavesExistentes);
        }

        private void CargarClases_348LC()
        {
            List<Clase> clases_348LC = bllMatricula_348LC.ListarClasesVigentes_348LC();

            cmbClase.DisplayMember = "NombreClase";
            cmbClase.ValueMember = "Id";
            cmbClase.DataSource = clases_348LC;

            btnInscribir.Enabled = clases_348LC.Count > 0;

            if (clases_348LC.Count == 0)
            {
                lblDatosClase.Text = "";
                dgvParticipantes.DataSource = null;
                dgvMatriculados.DataSource = null;
                MessageBox.Show("No hay clases disponibles con inscripción abierta.");
            }
        }

        private void CargarParticipantes_348LC(Clase clase_348LC)
        {
            dgvParticipantes.DataSource = bllMatricula_348LC.ListarParticipantesDisponibles_348LC(clase_348LC.Id);
            dgvParticipantes.Columns["Id"].Visible = false;
            dgvParticipantes.Columns["Eliminado"].Visible = false;
            dgvParticipantes.Columns["DVH"].Visible = false;
        }

        private void CargarMatriculados_348LC(Clase clase_348LC)
        {
            List<Matricula> matriculados_348LC = bllMatricula_348LC.ListarMatriculados_348LC(clase_348LC.Id);

            dgvMatriculados.DataSource = matriculados_348LC;
            dgvMatriculados.Columns["Id"].Visible = false;
            dgvMatriculados.Columns["IdClase"].Visible = false;
            dgvMatriculados.Columns["IdParticipante"].Visible = false;
            dgvMatriculados.Columns["Eliminado"].Visible = false;
            dgvMatriculados.Columns["DVH"].Visible = false;
            dgvMatriculados.Columns["NombreClase"].Visible = false;
            dgvMatriculados.Columns["CostoClase"].Visible = false;

            lblDatosClase.Text = $"Profesor: {clase_348LC.NombreProfesor}   Cancha: {clase_348LC.NumeroCancha}   " +
                $"Fecha: {clase_348LC.Fecha:dd/MM/yyyy} {clase_348LC.HoraInicio:hh\\:mm} ({clase_348LC.Duracion} min)\n" +
                $"Costo: ${clase_348LC.CostoClase:N2}   Inscriptos: {matriculados_348LC.Count}/{clase_348LC.CupoMaximo}   " +
                $"Inscripción: {clase_348LC.FechaInicioInscripcion:dd/MM/yyyy} al {clase_348LC.FechaFinInscripcion:dd/MM/yyyy}";
        }

        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clase clase_348LC = cmbClase.SelectedItem as Clase;
            if (clase_348LC == null)
                return;

            CargarParticipantes_348LC(clase_348LC);
            CargarMatriculados_348LC(clase_348LC);
        }

        private void btnRegistrarParticipante_Click(object sender, EventArgs e)
        {
            FrmParticipantes frmParticipantes = new FrmParticipantes();
            frmParticipantes.ShowDialog();

            Clase clase_348LC = cmbClase.SelectedItem as Clase;
            if (clase_348LC != null)
                CargarParticipantes_348LC(clase_348LC);
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            Clase clase_348LC = cmbClase.SelectedItem as Clase;

            if (clase_348LC == null)
            {
                MessageBox.Show("Seleccioná una clase.");
                return;
            }

            if (dgvParticipantes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un participante de la grilla.");
                return;
            }

            try
            {
                Participante participante_348LC = (Participante)dgvParticipantes.CurrentRow.DataBoundItem;

                Matricula matricula_348LC = new Matricula
                {
                    IdClase = clase_348LC.Id,
                    IdParticipante = participante_348LC.Id
                };

                bllMatricula_348LC.Alta_348LC(matricula_348LC);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Clases",
                    Descripcion = "Inscripción a clase",
                    Fecha = DateTime.Now,
                    Criticidad = 3
                });

                CargarParticipantes_348LC(clase_348LC);
                CargarMatriculados_348LC(clase_348LC);
                MessageBox.Show($"Participante inscripto correctamente. Se generó un pago pendiente de ${clase_348LC.CostoClase:N2}.");
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnDesinscribir_Click(object sender, EventArgs e)
        {
            Clase clase_348LC = cmbClase.SelectedItem as Clase;

            if (clase_348LC == null || dgvMatriculados.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un participante de la grilla de inscriptos.");
                return;
            }

            Matricula matricula_348LC = (Matricula)dgvMatriculados.CurrentRow.DataBoundItem;

            DialogResult confirmacion_348LC = MessageBox.Show($"¿Desinscribir a {matricula_348LC.Nombre} {matricula_348LC.Apellido} de la clase?\n\n" +
                "Si el pago está pendiente, se cancelará.\n" +
                "Si el pago ya está registrado, quedará como reintegrado y corresponde devolverle el importe.", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllMatricula_348LC.Desinscribir_348LC(matricula_348LC.Id);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Clases",
                    Descripcion = "Desinscripción de clase",
                    Fecha = DateTime.Now,
                    Criticidad = 3
                });

                CargarParticipantes_348LC(clase_348LC);
                CargarMatriculados_348LC(clase_348LC);
                MessageBox.Show("Participante desinscripto correctamente.");
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }
    }
}
