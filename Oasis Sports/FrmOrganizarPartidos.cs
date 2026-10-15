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
    public partial class FrmOrganizarPartidos : BaseForm, IObserverIdioma
    {
        public FrmOrganizarPartidos()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Inscripcion bllInscripcion_348LC = new BLL_Inscripcion();
        BLL_Partido bllPartido_348LC = new BLL_Partido();

        private void FrmOrganizarPartidos_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();
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

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTorneo.SelectedValue == null)
                return;

            int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);

            var equiposDelTorneo_348LC = bllInscripcion_348LC.ListarEquiposDelTorneo_348LC(idTorneo_348LC);

            cmbEquipoLocal.DisplayMember = "NombreEquipo";
            cmbEquipoLocal.ValueMember = "Id";
            cmbEquipoLocal.DataSource = equiposDelTorneo_348LC;

            cmbEquipoVisitante.DisplayMember = "NombreEquipo";
            cmbEquipoVisitante.ValueMember = "Id";
            cmbEquipoVisitante.DataSource = bllInscripcion_348LC.ListarEquiposDelTorneo_348LC(idTorneo_348LC);

            CargarFixture_348LC(idTorneo_348LC);
        }

        private void CargarFixture_348LC(int idTorneo_348LC)
        {
            dgvFixture.DataSource = bllPartido_348LC.ListarPorTorneo_348LC(idTorneo_348LC);
            dgvFixture.Columns["Eliminado"].Visible = false;
            dgvFixture.Columns["DVH"].Visible = false;
            dgvFixture.Columns["Id"].Visible = false;
            dgvFixture.Columns["IdEquipoLocal"].Visible = false;
            dgvFixture.Columns["IdEquipoVisitante"].Visible = false;
            dgvFixture.Columns["IdTorneo"].Visible = false;
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            if (cmbTorneo.SelectedValue == null || cmbEquipoLocal.SelectedValue == null || cmbEquipoVisitante.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná torneo, equipo local y equipo visitante.");
                return;
            }

            try
            {
                Partido partido_348LC = new Partido
                {
                    IdTorneo = Convert.ToInt32(cmbTorneo.SelectedValue),
                    IdEquipoLocal = Convert.ToInt32(cmbEquipoLocal.SelectedValue),
                    IdEquipoVisitante = Convert.ToInt32(cmbEquipoVisitante.SelectedValue),
                    FechaPartido = dtpFecha.Value.Date,
                    HoraInicio = dtpHora.Value.TimeOfDay,
                    NumeroCancha = Convert.ToInt32(nudCancha.Value)
                };

                bllPartido_348LC.Organizar_348LC(partido_348LC);
                CargarFixture_348LC(partido_348LC.IdTorneo);
                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Organizar Partidos",
                    Descripcion = "Nuevo partido",
                    Fecha = DateTime.Now,
                    Criticidad = 4
                });
                MessageBox.Show("Partido programado correctamente.");
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
