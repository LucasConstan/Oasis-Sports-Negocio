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

            cmbClase.Format += cmbClase_Format;
            CargarClases_348LC();
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(ActualizarIdioma));
            else
            {
                LanguageManager.GetInstance().TraducirControles(this);

                if (cmbClase.SelectedItem is Clase clase_348LC)
                {
                    CargarParticipantes_348LC(clase_348LC);
                    CargarMatriculados_348LC(clase_348LC);
                }
            }
        }

        private string Texto_348LC(string clave_348LC, string porDefecto_348LC)
        {
            string texto_348LC = LanguageManager.GetInstance().ObtenerTexto(clave_348LC);
            return texto_348LC == clave_348LC ? porDefecto_348LC : texto_348LC;
        }

        private void cmbClase_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Clase clase_348LC)
                e.Value = $"{clase_348LC.NombreClase} – {clase_348LC.Fecha:dd/MM} {clase_348LC.HoraInicio:hh\\:mm}";
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
                && !clavesExistentes.Contains(c.Name)
                && LanguageManager.GetInstance().EsTraducible(c))
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

            if (clases_348LC.Count == 0)
            {
                btnInscribir.Enabled = false;
                lblDatosClase.Text = "";
                dgvParticipantes.DataSource = null;
                dgvMatriculados.DataSource = null;
                lblDatosClase.Text = Texto_348LC("msgSinClasesAbiertas", "No hay clases disponibles con inscripción abierta.");
            }
        }

        private void CargarParticipantes_348LC(Clase clase_348LC)
        {
            dgvParticipantes.DataSource = bllMatricula_348LC.ListarParticipantesDisponibles_348LC(clase_348LC.Id);
            dgvParticipantes.Columns["Id"].Visible = false;
            dgvParticipantes.Columns["Eliminado"].Visible = false;
            dgvParticipantes.Columns["DVH"].Visible = false;
            dgvParticipantes.Columns["DNI"].HeaderText = Texto_348LC("colDNI", "DNI");
            dgvParticipantes.Columns["Nombre"].HeaderText = Texto_348LC("colNombre", "Nombre");
            dgvParticipantes.Columns["Apellido"].HeaderText = Texto_348LC("colApellido", "Apellido");
            dgvParticipantes.Columns["Edad"].HeaderText = Texto_348LC("colEdad", "Edad");
            dgvParticipantes.Columns["Telefono"].HeaderText = Texto_348LC("colTelefono", "Teléfono");
            dgvParticipantes.Columns["Direccion"].HeaderText = Texto_348LC("colDireccion", "Dirección");
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

            dgvMatriculados.Columns["DNI"].DisplayIndex = 0;
            dgvMatriculados.Columns["Nombre"].DisplayIndex = 1;
            dgvMatriculados.Columns["Apellido"].DisplayIndex = 2;
            dgvMatriculados.Columns["FechaMatricula"].DisplayIndex = 3;

            dgvMatriculados.Columns["DNI"].HeaderText = Texto_348LC("colDNI", "DNI");
            dgvMatriculados.Columns["Nombre"].HeaderText = Texto_348LC("colNombre", "Nombre");
            dgvMatriculados.Columns["Apellido"].HeaderText = Texto_348LC("colApellido", "Apellido");
            dgvMatriculados.Columns["FechaMatricula"].HeaderText = Texto_348LC("colFechaInscripcion", "Fecha de inscripción");
            dgvMatriculados.Columns["FechaMatricula"].DefaultCellStyle.Format = "dd/MM/yyyy";

            lblDatosClase.Text = $"{Texto_348LC("msgProfesor", "Profesor")}: {clase_348LC.NombreProfesor}   " +
                $"{Texto_348LC("msgCancha", "Cancha")}: {clase_348LC.NumeroCancha}   " +
                $"{Texto_348LC("msgFecha", "Fecha")}: {clase_348LC.Fecha:dd/MM/yyyy} {clase_348LC.HoraInicio:hh\\:mm} ({clase_348LC.Duracion} min)\n" +
                $"{Texto_348LC("msgCosto", "Costo")}: ${clase_348LC.CostoClase:N2}   " +
                $"{Texto_348LC("msgInscriptos", "Inscriptos")}: {matriculados_348LC.Count}/{clase_348LC.CupoMaximo}   " +
                $"{Texto_348LC("msgInscripcion", "Inscripción")}: {clase_348LC.FechaInicioInscripcion:dd/MM/yyyy} {Texto_348LC("msgAl", "al")} {clase_348LC.FechaFinInscripcion:dd/MM/yyyy}";

            bool cupoCompleto_348LC = matriculados_348LC.Count >= clase_348LC.CupoMaximo;
            btnInscribir.Enabled = !cupoCompleto_348LC;

            if (cupoCompleto_348LC)
                lblDatosClase.Text += "   " + Texto_348LC("msgCupoCompleto", "CUPO COMPLETO");
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
                bllMatricula_348LC.Desinscribir_348LC(matricula_348LC.Id, clase_348LC.Id);

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
