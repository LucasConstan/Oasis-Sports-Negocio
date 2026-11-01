using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using Servicios;

namespace Oasis_Sports
{
    public partial class FrmHistorialCambios : Form, IObserverIdioma
    {
        BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
        BLLUsuario bllUsuario = new BLLUsuario();

        public FrmHistorialCambios()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);
        }

        private void FrmHistorialCambios_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            cmbUsuario.DataSource = bllUsuario.Listar().OrderBy(u => u.Username).ToList();
            cmbUsuario.DisplayMember = "Username";
            cmbUsuario.ValueMember = "Id";
        }

        private void cmbUsuario_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Usuario u)
                e.Value = u.Eliminado ? u.Username + " (eliminado)" : u.Username;
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            if (!(cmbUsuario.SelectedItem is Usuario usuario))
            {
                dgvHistorial.DataSource = null;
                return;
            }

            List<HistorialCambio> versiones = bllHistorial.ListarHistorial(usuario.Id);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdHistorial", typeof(int));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Operación", typeof(string));
            tabla.Columns.Add("Realizado por", typeof(string));
            tabla.Columns.Add("Nombre de usuario", typeof(string));
            tabla.Columns.Add("Bloqueado", typeof(string));
            tabla.Columns.Add("Eliminado", typeof(string));
            tabla.Columns.Add("Cambios", typeof(string));

            for (int i = 0; i < versiones.Count; i++)
            {
                HistorialCambio version = versiones[i];
                HistorialCambio? anterior =i + 1 < versiones.Count ? versiones[i + 1] : null;

                tabla.Rows.Add(
                    version.IdHistorial,
                    version.Fecha,
                    version.Operacion,
                    version.UsuarioCambio,
                    version.Username,
                    version.Bloqueado ? "Sí" : "No",
                    version.Eliminado ? "Sí" : "No",
                    bllHistorial.DescribirCambios(version, anterior));
            }

            dgvHistorial.DataSource = tabla;
            dgvHistorial.Columns["IdHistorial"].Visible = false;
            dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvHistorial.Columns["Cambios"].FillWeight = 250;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (!(cmbUsuario.SelectedItem is Usuario usuario))
            {
                MessageBox.Show("Seleccioná un usuario.");
                return;
            }

            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una versión de la lista.");
                return;
            }

            int idHistorial = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["IdHistorial"].Value);
            DateTime fecha = Convert.ToDateTime(dgvHistorial.CurrentRow.Cells["Fecha"].Value);

            DialogResult confirmacion = MessageBox.Show(
                $"¿Restaurar el usuario '{usuario.Username}' al estado que tenía el {fecha:dd/MM/yyyy HH:mm:ss}?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                bllHistorial.RestaurarVersion(usuario.Id, idHistorial);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new BLL_Evento().RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Usuarios",
                Descripcion = $"Restauración del usuario {usuario.Username} a la versión del {fecha:dd/MM/yyyy HH:mm:ss}",
                Fecha = DateTime.Now,
                Criticidad = 3
            });

            MessageBox.Show("Usuario restaurado correctamente.");

            int idSeleccionado = usuario.Id;
            CargarUsuarios();
            cmbUsuario.SelectedValue = idSeleccionado;
            CargarHistorial();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHistorialCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
