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
    public partial class FrmEquipos : BaseForm, IObserverIdioma
    {
        public FrmEquipos()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
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
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            CargarGrilla_348LC();
        }
    }
}
