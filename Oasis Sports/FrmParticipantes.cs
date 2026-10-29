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
    public partial class FrmParticipantes : BaseForm, IObserverIdioma
    {
        BLL_Participante bllParticipante_348LC = new BLL_Participante();
        int idSeleccionado_348LC = 0;

        public FrmParticipantes()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmParticipantes_Load(object sender, EventArgs e)
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
            dgvParticipantes.DataSource = bllParticipante_348LC.Listar_348LC();
            dgvParticipantes.Columns["Eliminado"].Visible = false;
            dgvParticipantes.Columns["DVH"].Visible = false;
            dgvParticipantes.Columns["Id"].Visible = false;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                Participante participante_348LC = new Participante
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(nudEdad.Value),
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                bllParticipante_348LC.Alta_348LC(participante_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Participante agregado correctamente.");
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
                MessageBox.Show("Seleccioná un participante de la grilla.");
                return;
            }

            try
            {
                Participante participante_348LC = new Participante
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(nudEdad.Value),
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                bllParticipante_348LC.Modificar_348LC(idSeleccionado_348LC, participante_348LC);
                CargarGrilla_348LC();
                MessageBox.Show("Participante modificado correctamente.");
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
                MessageBox.Show("Seleccioná un participante de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("¿Eliminar el participante seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                bllParticipante_348LC.Baja_348LC(idSeleccionado_348LC);
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
            if (this.Modal)
            {
                this.Close();
                return;
            }

            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void dgvParticipantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvParticipantes.CurrentRow == null)
                return;

            Participante participante_348LC = (Participante)dgvParticipantes.CurrentRow.DataBoundItem;

            idSeleccionado_348LC = participante_348LC.Id;
            txtDNI.Text = participante_348LC.DNI;
            txtNombre.Text = participante_348LC.Nombre;
            txtApellido.Text = participante_348LC.Apellido;
            nudEdad.Value = participante_348LC.Edad;
            txtTelefono.Text = participante_348LC.Telefono;
            txtDireccion.Text = participante_348LC.Direccion;
        }
    }
}
