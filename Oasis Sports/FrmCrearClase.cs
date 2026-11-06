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
    public partial class FrmCrearClase : BaseForm, IObserverIdioma
    {
        BLL_Clase bllClase_348LC = new BLL_Clase();

        public FrmCrearClase()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmCrearClase_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            nudDuracion.Minimum = BLL_Clase.DURACION_MINIMA_MINUTOS;
            nudDuracion.Maximum = BLL_Clase.DURACION_MAXIMA_MINUTOS;
            nudDuracion.Increment = BLL_Clase.INTERVALO_DURACION_MINUTOS;

            cmbCancha.Items.Clear();
            for (int cancha_348LC = 1; cancha_348LC <= BLL_Clase.CANTIDAD_CANCHAS; cancha_348LC++)
                cmbCancha.Items.Add(cancha_348LC.ToString());

            LimpiarCampos_348LC();

            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            dtpFecha.ValueChanged += DatosDisponibilidad_Changed;
            dtpHoraInicio.ValueChanged += DatosDisponibilidad_Changed;
            nudDuracion.ValueChanged += DatosDisponibilidad_Changed;
        }

        private void LimpiarCampos_348LC()
        {
            txtNombreClase.Clear();
            txtDescripcion.Clear();

            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.MaxDate = DateTime.Today.AddYears(1);
            dtpFecha.Value = DateTime.Today;

            DateTime proximaHora_348LC = DateTime.Today.AddHours(DateTime.Now.Hour + 1);
            dtpHoraInicio.Value = proximaHora_348LC;

            nudDuracion.Value = 60;
            nudCupoMaximo.Value = 10;
            nudCostoClase.Value = nudCostoClase.Minimum;
            cmbCancha.SelectedIndex = -1;

            dtpInicioInscripcion.MinDate = DateTime.Today;
            dtpFinInscripcion.MinDate = DateTime.Today;
            AjustarFechasInscripcion_348LC();
            dtpInicioInscripcion.Value = DateTime.Today;

            dgvProfesores.DataSource = null;
        }

        private void AjustarFechasInscripcion_348LC()
        {
            DateTime fechaClase_348LC = dtpFecha.Value.Date;

            dtpInicioInscripcion.MaxDate = fechaClase_348LC;
            dtpFinInscripcion.MaxDate = fechaClase_348LC;
            dtpFinInscripcion.Value = fechaClase_348LC;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            AjustarFechasInscripcion_348LC();
        }

        private void DatosDisponibilidad_Changed(object sender, EventArgs e)
        {
            dgvProfesores.DataSource = null;
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(ActualizarIdioma));
            else
            {
                LanguageManager.GetInstance().TraducirControles(this);
                TitularColumnas_348LC();
            }
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

        private void CargarProfesores_348LC(Clase clase_348LC)
        {
            dgvProfesores.DataSource = bllClase_348LC.ListarProfesoresDisponibles_348LC(clase_348LC);
            dgvProfesores.Columns["Eliminado"].Visible = false;
            dgvProfesores.Columns["DVH"].Visible = false;
            dgvProfesores.Columns["Id"].Visible = false;
            TitularColumnas_348LC();
        }

        private void TitularColumnas_348LC()
        {
            if (dgvProfesores.DataSource == null)
                return;

            dgvProfesores.Columns["DNI"].HeaderText = Texto_348LC("colDNI", "DNI");
            dgvProfesores.Columns["Nombre"].HeaderText = Texto_348LC("colNombre", "Nombre");
            dgvProfesores.Columns["Apellido"].HeaderText = Texto_348LC("colApellido", "Apellido");
            dgvProfesores.Columns["Especialidad"].HeaderText = Texto_348LC("colEspecialidad", "Especialidad");
        }

        private string Texto_348LC(string clave_348LC, string porDefecto_348LC)
        {
            string texto_348LC = LanguageManager.GetInstance().ObtenerTexto(clave_348LC);
            return texto_348LC == clave_348LC ? porDefecto_348LC : texto_348LC;
        }

        private void btnBuscarDisponibilidad_Click(object sender, EventArgs e)
        {
            try
            {
                Clase clase_348LC = new Clase
                {
                    NombreClase = txtNombreClase.Text,
                    Descripcion = txtDescripcion.Text,
                    Fecha = dtpFecha.Value.Date,
                    HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                    Duracion = Convert.ToInt32(nudDuracion.Value),
                    CupoMaximo = Convert.ToInt32(nudCupoMaximo.Value)
                };

                CargarProfesores_348LC(clase_348LC);

                if (dgvProfesores.Rows.Count == 0)
                    MessageBox.Show("No hay profesores disponibles en ese horario.");
            }
            catch (Exception ex_348LC)
            {
                dgvProfesores.DataSource = null;
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnRegistrarClase_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow == null)
            {
                MessageBox.Show("Buscá disponibilidad y seleccioná un profesor de la grilla.");
                return;
            }

            try
            {
                Profesor profesor_348LC = (Profesor)dgvProfesores.CurrentRow.DataBoundItem;

                Clase clase_348LC = new Clase
                {
                    NombreClase = txtNombreClase.Text,
                    Descripcion = txtDescripcion.Text,
                    Fecha = dtpFecha.Value.Date,
                    HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                    Duracion = Convert.ToInt32(nudDuracion.Value),
                    CupoMaximo = Convert.ToInt32(nudCupoMaximo.Value),
                    IdProfesor = profesor_348LC.Id,
                    NumeroCancha = cmbCancha.SelectedItem == null ? 0 : Convert.ToInt32(cmbCancha.SelectedItem),
                    CostoClase = nudCostoClase.Value,
                    FechaInicioInscripcion = dtpInicioInscripcion.Value.Date,
                    FechaFinInscripcion = dtpFinInscripcion.Value.Date
                };

                bllClase_348LC.Alta_348LC(clase_348LC);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Clases",
                    Descripcion = "Nueva clase",
                    Fecha = DateTime.Now,
                    Criticidad = 3
                });

                LimpiarCampos_348LC();
                MessageBox.Show("Clase creada correctamente.");
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
