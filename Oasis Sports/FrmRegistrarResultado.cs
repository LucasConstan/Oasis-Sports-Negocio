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
    public partial class FrmRegistrarResultado : BaseForm
    {
        public FrmRegistrarResultado()
        {
            InitializeComponent();
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Resultado bllResultado_348LC = new BLL_Resultado();
        int idPartidoSeleccionado_348LC = 0;

        private void FrmRegistrarResultado_Load(object sender, EventArgs e)
        {
            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();
        }

        private void CargarGrilla_348LC()
        {
            if (cmbTorneo.SelectedValue == null)
                return;

            int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
            dgvPartidosPendientes.DataSource = bllResultado_348LC.ListarPendientes_348LC(idTorneo_348LC);
            dgvPartidosPendientes.Columns["Eliminado"].Visible = false;
        }

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla_348LC();
        }

        private void dgvPartidosPendientes_SelectionChanged(object sender, EventArgs e)
        {
            {
                if (dgvPartidosPendientes.CurrentRow == null)
                    return;

                Partido partido_348LC = (Partido)dgvPartidosPendientes.CurrentRow.DataBoundItem;
                idPartidoSeleccionado_348LC = partido_348LC.Id;
            }
        }


        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (idPartidoSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un partido de la grilla.");
                return;
            }

            try
            {
                if (chkSuspendido.Checked)
                {
                    bllResultado_348LC.Suspender_348LC(idPartidoSeleccionado_348LC);
                    MessageBox.Show("Partido marcado como suspendido. El Organizador debe reprogramarlo.");
                }
                else
                {
                    int golesLocal_348LC = Convert.ToInt32(nudGolesLocal.Value);
                    int golesVisitante_348LC = Convert.ToInt32(nudGolesVisitante.Value);

                    bllResultado_348LC.RegistrarResultado_348LC(idPartidoSeleccionado_348LC, golesLocal_348LC, golesVisitante_348LC);
                    MessageBox.Show("Resultado registrado correctamente.");
                }

                CargarGrilla_348LC();
                idPartidoSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }
    }
}
