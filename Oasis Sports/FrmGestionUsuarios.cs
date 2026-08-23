using BLL;
using DAL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class FrmGestionUsuarios : BaseForm, IObserverIdioma
    {
        public FrmGestionUsuarios()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
            
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
            if (c is MenuStrip ms)
            {
                RegistrarMenuItems(ms.Items, idIdioma, bll, clavesExistentes);
                return;
            }


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

        private void RegistrarMenuItems(ToolStripItemCollection items, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            foreach (ToolStripItem item in items)
            {
                if (!string.IsNullOrWhiteSpace(item.Name) && !string.IsNullOrWhiteSpace(item.Text)
                    && !clavesExistentes.Contains(item.Name))
                {
                    bll.GuardarOActualizar(new Traduccion
                    {
                        IdIdioma = idIdioma,
                        Clave = item.Name,
                        Texto = item.Text
                    });
                    clavesExistentes.Add(item.Name);
                }

                if (item is ToolStripMenuItem mi && mi.DropDownItems.Count > 0)
                    RegistrarMenuItems(mi.DropDownItems, idIdioma, bll, clavesExistentes);
            }
        }

        BLLUsuario bllUsuario = new BLLUsuario();
        ValidadorDeIntegridad Validador = new ValidadorDeIntegridad();
        BLL_DV bLL_DV = new BLL_DV();

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LanguageManager.GetInstance().TraducirControles(this)));
            else
                LanguageManager.GetInstance().TraducirControles(this);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
                ActualizarIdioma();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {

            string username = txtUsuario.Text.Trim();
            string password = txtContraseña.Text;
            string passwordRepetida = txtContraseñaRepetida.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("El usuario y la contraseña no pueden estar vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != passwordRepetida)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario()
            {
                Username = username,
                Password = password 
            };

            bllUsuario.AñadirUsuario(usuario);
            BLL_Evento bllEvento = new BLL_Evento();
            
            
            bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario.Username,
                Modulo = "Usuarios",
                Descripcion = "Alta de usuario: " + usuario.Username,
                Fecha = DateTime.Now,
                Criticidad = 2
            });
            dataGridView1.DataSource = bllUsuario.Listar();
            
            MessageBox.Show("Usuario añadido correctamente");

            bLL_DV.InicializarDVs();
            


        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            dataGridView1.DataSource = bllUsuario.Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private int idUsuarioSeleccionado;

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
            string usuarioLogueado = SessionManager.GetInstance().Usuario.Username;
            if (txtUsuario.Text.Trim().Equals(usuarioLogueado, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No puedes eliminar al usuario con el que estás logueado actualmente.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al usuario {txtUsuario.Text}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bllUsuario.EliminarUsuario(idUsuarioSeleccionado);
              
                MessageBox.Show("El Usuario fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bLL_DV.InicializarDVs();
            }

            BLL_Evento bllEvento = new BLL_Evento();

            bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario.Username,
                Modulo = "Usuarios",
                Descripcion = "Eliminación de usuario",
                Fecha = DateTime.Now,
                Criticidad = 3
            });
            dataGridView1.DataSource = bllUsuario.Listar();

            txtUsuario.Clear();
            txtContraseña.Clear();

            bLL_DV.InicializarDVs();
            idUsuarioSeleccionado = 0;
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);

                txtUsuario.Text = fila.Cells["Username"].Value.ToString();
                txtContraseña.Text = "";
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsuario.Text.Trim();
            string password = txtContraseña.Text;
            string passwordRepetida = txtContraseñaRepetida.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Para modificar, debe ingresar un nombre de usuario y una nueva contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != passwordRepetida)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario()
            {
                Username = username,
                Password = password
            };

            bllUsuario.ModificarUsuario(idUsuarioSeleccionado, usuario);

            BLL_Evento bllEvento = new BLL_Evento();
            bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario.Username,
                Modulo = "Usuarios",
                Descripcion = "Modificación de usuario: " + usuario.Username,
                Fecha = DateTime.Now,
                Criticidad = 2
            });

            dataGridView1.DataSource = bllUsuario.Listar();
            MessageBox.Show("El Usuario fue modificado con éxito");
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtContraseñaRepetida.Clear();

            bLL_DV.InicializarDVs();

            FrmHistorialCambios frm = new FrmHistorialCambios(idUsuarioSeleccionado, usuario.Username);
            frm.ShowDialog();
            
        }

        private void FrmGestionUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);

        }
    }
}
