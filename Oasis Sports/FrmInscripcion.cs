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
    public partial class FrmInscripcion : BaseForm
    {
        public FrmInscripcion()
        {
            InitializeComponent();
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Equipo bllEquipo_348LC = new BLL_Equipo();
        BLL_Jugador bllJugador_348LC = new BLL_Jugador();
        BLL_Inscripcion bllInscripcion_348LC = new BLL_Inscripcion();

        int idEquipoSeleccionado_348LC = 0;
        int idJugadorSeleccionado_348LC = 0;

        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();

            cmbEquipoExistente.DisplayMember = "NombreEquipo";
            cmbEquipoExistente.ValueMember = "Id";
            cmbEquipoExistente.DataSource = bllEquipo_348LC.Listar_348LC();

            CargarComboJugadores_348LC();
        }

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaEquipos_348LC();
            dgvJugadoresEquipo.DataSource = null;
        }

        private void CargarComboJugadores_348LC()
        {
            cmbJugadorExistente.DataSource = bllJugador_348LC.Listar_348LC();
            cmbJugadorExistente.DisplayMember = "Apellido";
            cmbJugadorExistente.ValueMember = "Id";
        }

        private void CargarGrillaEquipos_348LC()
        {
            if (cmbTorneo.SelectedValue == null)
                return;

            int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
            dgvEquiposInscriptos.DataSource = bllInscripcion_348LC.ListarEquiposDelTorneo_348LC(idTorneo_348LC);
            dgvEquiposInscriptos.Columns["Eliminado"].Visible = false;
        }



        private void CargarGrillaJugadores_348LC()
        {
            dgvJugadoresEquipo.DataSource = bllJugador_348LC.ListarPorEquipo_348LC(idEquipoSeleccionado_348LC);
            dgvJugadoresEquipo.Columns["Eliminado"].Visible = false;
        }

        private void dgvEquiposInscriptos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquiposInscriptos.CurrentRow == null)
                return;

            Equipo equipo_348LC = (Equipo)dgvEquiposInscriptos.CurrentRow.DataBoundItem;
            idEquipoSeleccionado_348LC = equipo_348LC.Id;
            CargarGrillaJugadores_348LC();
        }

        private void dgvJugadoresEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJugadoresEquipo.CurrentRow == null)
                return;

            Jugador jugador_348LC = (Jugador)dgvJugadoresEquipo.CurrentRow.DataBoundItem;
            idJugadorSeleccionado_348LC = jugador_348LC.Id;
        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            if (cmbTorneo.SelectedValue == null || cmbEquipoExistente.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un torneo y un equipo.");
                return;
            }

            try
            {
                int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
                int idEquipo_348LC = Convert.ToInt32(cmbEquipoExistente.SelectedValue);

                bllInscripcion_348LC.AltaEquipo_348LC(idTorneo_348LC, idEquipo_348LC);
                CargarGrillaEquipos_348LC();
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnQuitarEquipo_Click(object sender, EventArgs e)
        {
            if (idEquipoSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un equipo de la grilla.");
                return;
            }

            try
            {
                int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
                bllInscripcion_348LC.BajaEquipo_348LC(idTorneo_348LC, idEquipoSeleccionado_348LC);
                CargarGrillaEquipos_348LC();
                dgvJugadoresEquipo.DataSource = null;
                idEquipoSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            if (idEquipoSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un equipo inscripto en la grilla.");
                return;
            }

            if (cmbJugadorExistente.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un jugador.");
                return;
            }

            try
            {
                int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
                int idJugador_348LC = Convert.ToInt32(cmbJugadorExistente.SelectedValue);

                Jugador jugador_348LC = bllJugador_348LC.ObtenerPorId_348LC(idJugador_348LC);

                bllInscripcion_348LC.ValidarJugadorEnTorneo_348LC(idTorneo_348LC, jugador_348LC.DNI, idEquipoSeleccionado_348LC);

                jugador_348LC.IdEquipo = idEquipoSeleccionado_348LC;
                bllJugador_348LC.Modificar_348LC(idJugador_348LC, jugador_348LC);

                CargarGrillaJugadores_348LC();
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

        private void btnQuitarJugador_Click(object sender, EventArgs e)
        {
            if (idJugadorSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un jugador de la grilla.");
                return;
            }

            try
            {
                Jugador jugador_348LC = bllJugador_348LC.ObtenerPorId_348LC(idJugadorSeleccionado_348LC);
                jugador_348LC.IdEquipo = BLL_Jugador.SIN_EQUIPO_ID;
                bllJugador_348LC.Modificar_348LC(idJugadorSeleccionado_348LC, jugador_348LC);

                CargarGrillaJugadores_348LC();
                idJugadorSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }
    }
}
