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
    public partial class FrmTorneo : BaseForm
    {
        public FrmTorneo()
        {
            InitializeComponent();
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        int idSeleccionado_348LC = 0;

        private void FrmTorneo_Load(object sender, EventArgs e)
        {
            CargarGrilla_348LC();
        }

        private void CargarGrilla_348LC()
        {
            dgvTorneos.DataSource = bllTorneo_348LC.Listar_348LC();
            dgvTorneos.Columns["Eliminado"].Visible = false;
        }

        private void dgvTorneos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTorneos.CurrentRow == null)
                return;

            Torneo torneo_348LC = (Torneo)dgvTorneos.CurrentRow.DataBoundItem;

            idSeleccionado_348LC = torneo_348LC.Id;
            txtNombreTorneo.Text = torneo_348LC.NombreTorneo;
            txtDescripcion.Text = torneo_348LC.Descripcion;
            cmbCategoria.Text = torneo_348LC.Categoria;
            dtpFechaInicio.Value = torneo_348LC.FechaInicio;
            dtpFechaFin.Value = torneo_348LC.FechaFin;
            nudCantidadMaximaEquipos.Value = torneo_348LC.CantidadMaximaEquipos;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos_348LC()
        {
            idSeleccionado_348LC = 0;
            txtNombreTorneo.Clear();
            txtDescripcion.Clear();
            cmbCategoria.Text = string.Empty;
        }

        private Torneo ArmarTorneoDesdeCampos_348LC()
        {
            return new Torneo
            {
                NombreTorneo = txtNombreTorneo.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = cmbCategoria.Text,
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                CantidadMaximaEquipos = Convert.ToInt32(nudCantidadMaximaEquipos.Value)
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bllTorneo_348LC.Alta_348LC(ArmarTorneoDesdeCampos_348LC());
                CargarGrilla_348LC();
                LimpiarCampos_348LC();
                MessageBox.Show("Torneo creado correctamente.");
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un torneo de la grilla.");
                return;
            }

            try
            {
                bllTorneo_348LC.Modificar_348LC(idSeleccionado_348LC, ArmarTorneoDesdeCampos_348LC());
                CargarGrilla_348LC();
                MessageBox.Show("Torneo modificado correctamente.");
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un torneo de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("¿Eliminar el torneo seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllTorneo_348LC.Baja_348LC(idSeleccionado_348LC);
                CargarGrilla_348LC();
                LimpiarCampos_348LC();
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
            this.Hide();
        }
    }

}
