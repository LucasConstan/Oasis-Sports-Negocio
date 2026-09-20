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
    public partial class FrmJugadores : BaseForm
    {
        BLL_Jugador bllJugador_348LC = new BLL_Jugador();
        BLL_Equipo bllEquipo_348LC = new BLL_Equipo();
        int idSeleccionado_348LC = 0;

        public FrmJugadores()
        {
            InitializeComponent();
        }

        private void FrmJugadores_Load(object sender, EventArgs e)
        {
            CargarComboEquipos_348LC();
            CargarGrilla_348LC();
        }

        private void CargarComboEquipos_348LC()
        {
            cmbEquipo.DataSource = bllEquipo_348LC.Listar_348LC();
            cmbEquipo.DisplayMember = "NombreEquipo";
            cmbEquipo.ValueMember = "Id";
        }

        private void CargarGrilla_348LC()
        {
            dgvJugadores.DataSource = bllJugador_348LC.Listar_348LC();
            dgvJugadores.Columns["Eliminado"].Visible = false;
            dgvJugadores.Columns["IdEquipo"].Visible = false;
        }

        private void dgvJugadores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJugadores.CurrentRow == null)
                return;

            Jugador jugador_348LC = (Jugador)dgvJugadores.CurrentRow.DataBoundItem;

            idSeleccionado_348LC = jugador_348LC.Id;
            txtDNI.Text = jugador_348LC.DNI;
            txtNombre.Text = jugador_348LC.Nombre;
            txtApellido.Text = jugador_348LC.Apellido;
            nudEdad.Value = jugador_348LC.Edad;
            txtPosicion.Text = jugador_348LC.Posicion;
            nudNumero.Value = jugador_348LC.Numero;
            cmbEquipo.SelectedValue = jugador_348LC.IdEquipo;
        }







        private void btnAñadir_Click_1(object sender, EventArgs e)
        {
            try
            {
                Jugador jugador_348LC = new Jugador
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(nudEdad.Value),
                    Posicion = txtPosicion.Text,
                    Numero = Convert.ToInt32(nudNumero.Value),
                    IdEquipo = Convert.ToInt32(cmbEquipo.SelectedValue)
                };

                bllJugador_348LC.Alta_348LC(jugador_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Jugador agregado correctamente.");
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
                MessageBox.Show("Seleccioná un jugador de la grilla.");
                return;
            }

            try
            {
                Jugador jugador_348LC = new Jugador
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(nudEdad.Value),
                    Posicion = txtPosicion.Text,
                    Numero = Convert.ToInt32(nudNumero.Value),
                    IdEquipo = Convert.ToInt32(cmbEquipo.SelectedValue)
                };

                bllJugador_348LC.Modificar_348LC(idSeleccionado_348LC, jugador_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Jugador modificado correctamente.");
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
                MessageBox.Show("Seleccioná un jugador de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("¿Eliminar el jugador seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllJugador_348LC.Baja_348LC(idSeleccionado_348LC);
                CargarGrilla_348LC();
                idSeleccionado_348LC = 0;
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
