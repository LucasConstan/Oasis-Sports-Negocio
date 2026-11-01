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

        private int idUsuarioSeleccionado;
        private string nombreUsuarioSeleccionado = "";
        private bool usuarioSeleccionadoBloqueado;

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarIdioma));
                return;
            }

            LanguageManager.GetInstance().TraducirControles(this);
            ActualizarBotonBloqueo();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
                ActualizarIdioma();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            dataGridView1.DataBindingComplete += (s, ev) => dataGridView1.ClearSelection();
            CargarGrilla();
            LimpiarFormulario();
        }

        private void CargarGrilla()
        {
            dataGridView1.DataSource = bllUsuario.ListarActivos();

            foreach (string columna in new[] { "Password", "DVH", "Eliminado" })
            {
                if (dataGridView1.Columns.Contains(columna))
                    dataGridView1.Columns[columna].Visible = false;
            }
        }

        private void LimpiarFormulario()
        {
            idUsuarioSeleccionado = 0;
            nombreUsuarioSeleccionado = "";
            usuarioSeleccionadoBloqueado = false;
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtContraseñaRepetida.Clear();
            dataGridView1.ClearSelection();
            ActualizarBotonBloqueo();
        }

        private void ActualizarBotonBloqueo()
        {
            btnBloqueo.Enabled = idUsuarioSeleccionado != 0;
            btnBloqueo.Text = usuarioSeleccionadoBloqueado
                ? LanguageManager.GetInstance().ObtenerTexto("DESBLOQUEAR")
                : LanguageManager.GetInstance().ObtenerTexto("BLOQUEAR");
        }

        private void RegistrarEventoUsuarios(string descripcion, int criticidad)
        {
            new BLL_Evento().RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario.Username,
                Modulo = "Usuarios",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Usuario usuario = (Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            idUsuarioSeleccionado = usuario.Id;
            nombreUsuarioSeleccionado = usuario.Username;
            usuarioSeleccionadoBloqueado = usuario.Bloqueado;

            txtUsuario.Text = usuario.Username;
            txtContraseña.Clear();
            txtContraseñaRepetida.Clear();
            ActualizarBotonBloqueo();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("El usuario y la contraseña no pueden estar vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != txtContraseñaRepetida.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario()
            {
                Username = username,
                Password = password
            };

            try
            {
                bllUsuario.AñadirUsuario(usuario);
                RegistrarEventoUsuarios("Alta de usuario: " + usuario.Username, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarGrilla();
            LimpiarFormulario();
            MessageBox.Show("Usuario añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != txtContraseñaRepetida.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario()
            {
                Username = username,
                Password = password
            };

            string nombreAnterior = nombreUsuarioSeleccionado;

            try
            {
                bllUsuario.ModificarUsuario(idUsuarioSeleccionado, usuario);

                string descripcion = nombreAnterior == usuario.Username
                    ? "Modificación de usuario: " + usuario.Username
                    : $"Modificación de usuario: {nombreAnterior} → {usuario.Username}";

                if (!string.IsNullOrEmpty(password))
                    descripcion += " (con cambio de contraseña)";

                RegistrarEventoUsuarios(descripcion, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarGrilla();
            LimpiarFormulario();
            MessageBox.Show("El usuario fue modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al usuario {nombreUsuarioSeleccionado}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                bllUsuario.EliminarUsuario(idUsuarioSeleccionado);
                RegistrarEventoUsuarios("Eliminación de usuario: " + nombreUsuarioSeleccionado, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarGrilla();
            LimpiarFormulario();
            MessageBox.Show("El usuario fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBloqueo_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool desbloquear = usuarioSeleccionadoBloqueado;
            string accion = desbloquear ? "desbloquear" : "bloquear";

            DialogResult result = MessageBox.Show($"¿Está seguro que desea {accion} al usuario {nombreUsuarioSeleccionado}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                if (desbloquear)
                {
                    bllUsuario.DesbloquearUsuario(idUsuarioSeleccionado);
                    RegistrarEventoUsuarios("Desbloqueo de usuario: " + nombreUsuarioSeleccionado, 2);
                }
                else
                {
                    bllUsuario.BloquearUsuario(idUsuarioSeleccionado);
                    RegistrarEventoUsuarios("Bloqueo manual de usuario: " + nombreUsuarioSeleccionado, 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarGrilla();
            LimpiarFormulario();
            MessageBox.Show(desbloquear ? "El usuario fue desbloqueado con éxito." : "El usuario fue bloqueado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void FrmGestionUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
