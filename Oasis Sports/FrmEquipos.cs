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
    public partial class FrmEquipos : BaseForm
    {
        public FrmEquipos()
        {
            InitializeComponent();
        }

        BLL_Equipo bllEquipo_348LC = new BLL_Equipo();
        int idSeleccionado_348LC = 0;

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                Equipo equipo_348LC = new Equipo
                {
                    NombreEquipo = txtNombreEquipo.Text,
                    NombreResponsable = txtNombreResponsable.Text,
                    ColorPrincipal = txtColorPrincipal.Text,
                    ColorSecundario = txtColorSecundario.Text
                };

                bllEquipo_348LC.Alta_348LC(equipo_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Equipo agregado correctamente.");
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
                MessageBox.Show("Seleccioná un equipo de la grilla.");
                return;
            }

            try
            {
                Equipo equipo_348LC = new Equipo
                {
                    NombreEquipo = txtNombreEquipo.Text,
                    NombreResponsable = txtNombreResponsable.Text,
                    ColorPrincipal = txtColorPrincipal.Text,
                    ColorSecundario = txtColorSecundario.Text
                };

                bllEquipo_348LC.Modificar_348LC(idSeleccionado_348LC, equipo_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Equipo modificado correctamente.");
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
                MessageBox.Show("Seleccioná un equipo de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("¿Eliminar el equipo seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllEquipo_348LC.Baja_348LC(idSeleccionado_348LC);
                CargarGrilla_348LC();
                idSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }


        private void CargarGrilla_348LC()
        {
            dgvEquipos.DataSource = bllEquipo_348LC.Listar_348LC();
            dgvEquipos.Columns["Eliminado"].Visible = false;
            dgvEquipos.Columns["DVH"].Visible = false;
            dgvEquipos.Columns["Id"].Visible = false;
        }

        private void dgvEquipos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquipos.CurrentRow == null)
                return;

            Equipo equipo_348LC = (Equipo)dgvEquipos.CurrentRow.DataBoundItem;

            idSeleccionado_348LC = equipo_348LC.Id;
            txtNombreEquipo.Text = equipo_348LC.NombreEquipo;
            txtNombreResponsable.Text = equipo_348LC.NombreResponsable;
            txtColorPrincipal.Text = equipo_348LC.ColorPrincipal;
            txtColorSecundario.Text = equipo_348LC.ColorSecundario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void FrmEquipos_Load(object sender, EventArgs e)
        {
            CargarGrilla_348LC();
        }
    }
}
