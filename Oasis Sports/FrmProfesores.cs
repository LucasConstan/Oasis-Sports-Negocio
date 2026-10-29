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
    public partial class FrmProfesores : BaseForm, IObserverIdioma
    {
        BLL_Profesor bllProfesor_348LC = new BLL_Profesor();
        int idSeleccionado_348LC = 0;

        public FrmProfesores()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmProfesores_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            CargarGrilla_348LC();
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

        private void CargarGrilla_348LC()
        {
            dgvProfesores.DataSource = bllProfesor_348LC.Listar_348LC();
            dgvProfesores.Columns["Eliminado"].Visible = false;
            dgvProfesores.Columns["DVH"].Visible = false;
            dgvProfesores.Columns["Id"].Visible = false;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                Profesor profesor_348LC = new Profesor
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Especialidad = txtEspecialidad.Text
                };

                bllProfesor_348LC.Alta_348LC(profesor_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Profesor agregado correctamente.");
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
                MessageBox.Show("Seleccioná un profesor de la grilla.");
                return;
            }

            try
            {
                Profesor profesor_348LC = new Profesor
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Especialidad = txtEspecialidad.Text
                };

                bllProfesor_348LC.Modificar_348LC(idSeleccionado_348LC, profesor_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Profesor modificado correctamente.");
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
                MessageBox.Show("Seleccioná un profesor de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("¿Eliminar el profesor seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllProfesor_348LC.Baja_348LC(idSeleccionado_348LC);
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

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow == null)
                return;

            Profesor profesor_348LC = (Profesor)dgvProfesores.CurrentRow.DataBoundItem;

            idSeleccionado_348LC = profesor_348LC.Id;
            txtDNI.Text = profesor_348LC.DNI;
            txtNombre.Text = profesor_348LC.Nombre;
            txtApellido.Text = profesor_348LC.Apellido;
            txtEspecialidad.Text = profesor_348LC.Especialidad;
        }
    }
}
