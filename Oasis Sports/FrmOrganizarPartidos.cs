using BLL;
using Entidades;
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
    public partial class FrmOrganizarPartidos : BaseForm
    {
        public FrmOrganizarPartidos()
        {
            InitializeComponent();
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Inscripcion bllInscripcion_348LC = new BLL_Inscripcion();
        BLL_Partido bllPartido_348LC = new BLL_Partido();

        private void FrmOrganizarPartidos_Load(object sender, EventArgs e)
        {
            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();
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
