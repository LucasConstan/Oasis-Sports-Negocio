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
    public partial class FrmGestionPerfiles : BaseForm, IObserverIdioma
    {
        public FrmGestionPerfiles()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private BLL_Permisos permisoBLL = new BLL_Permisos();
        private BLLUsuario usuarioBLL = new BLLUsuario();

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



        private void CargarPerfilUsuario(int usuarioId)
        {
            treeView1.Nodes.Clear();

            GrupoPermisos perfil = permisoBLL.ObtenerPerfilUsuario(usuarioId);

            if (perfil != null)
            {
                TreeNode nodoPerfil = CrearNodoPermiso(perfil);
                nodoPerfil.Text = $"{LanguageManager.GetInstance().ObtenerTexto("Perfil")}: {perfil}";
                treeView1.Nodes.Add(nodoPerfil);
            }

            treeView1.ExpandAll();

            if (treeView1.Nodes.Count > 0)
                treeView1.TopNode = treeView1.Nodes[0];
        }

        private TreeNode CrearNodoPermiso(ComponentePermiso permiso)
        {
            bool esGrupo = permiso is GrupoPermisos;

            TreeNode nodo = new TreeNode($"{LanguageManager.GetInstance().ObtenerTexto(esGrupo ? "Grupo" : "Permiso")}: {permiso}");
            nodo.Tag = permiso;

            if (!esGrupo)
                nodo.NodeFont = this.Font;

            foreach (ComponentePermiso hijo in permiso.ObtenerHijos())
                nodo.Nodes.Add(CrearNodoPermiso(hijo));

            return nodo;
        }

        private void CargarUsuarios()
        {
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DisplayMember = "Username";
            cmbUsuarios.ValueMember = "Id";
            cmbUsuarios.DataSource = usuarioBLL.ListarActivos();
        }

        private void CargarPerfiles()
        {
            lstPerfiles.DataSource = null;
            lstPerfiles.DataSource = permisoBLL.ObtenerPerfiles();
        }

        private void FrmGestionPerfiles_Load(object sender, EventArgs e)
        {

            CargarUsuarios();
            CargarPerfiles();
            RegistrarClaves();

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

        private void RegistrarEventoPerfiles(string descripcion, int criticidad)
        {
            new BLL_Evento().RegistrarEvento(new Evento()
            {
                Usuario = SessionManager.GetInstance().Usuario.Username,
                Modulo = "Perfiles",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;

            if (usuario == null)
                return;

            CargarPerfilUsuario(usuario.Id);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;
            GrupoPermisos perfil = lstPerfiles.SelectedItem as GrupoPermisos;

            if (usuario == null || perfil == null)
            {
                MessageBox.Show("Seleccione un usuario y un perfil.");
                return;
            }

            GrupoPermisos perfilActual = permisoBLL.ObtenerPerfilUsuario(usuario.Id);

            if (perfilActual != null && perfilActual.Id != perfil.Id)
            {
                DialogResult confirmacion = MessageBox.Show(
                    $"El usuario {usuario.Username} tiene el perfil '{perfilActual}'. ¿Desea reemplazarlo por '{perfil}'?",
                    "Confirmar cambio de perfil",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;
            }

            try
            {
                permisoBLL.AsignarPerfil(usuario.Id, perfil);
                RegistrarEventoPerfiles($"Asignación del perfil {perfil.Codigo} al usuario {usuario.Username}", 2);
                CargarPerfilUsuario(usuario.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;

            if (usuario == null)
                return;

            GrupoPermisos perfilActual = permisoBLL.ObtenerPerfilUsuario(usuario.Id);

            if (perfilActual == null)
            {
                MessageBox.Show("El usuario no tiene un perfil asignado.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea quitar el perfil '{perfilActual}' al usuario {usuario.Username}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                permisoBLL.QuitarPerfil(usuario.Id);
                RegistrarEventoPerfiles($"Se quitó el perfil {perfilActual.Codigo} al usuario {usuario.Username}", 3);
                CargarPerfilUsuario(usuario.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void FrmGestionPerfiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmGruposPermisos frmGruposPermisos = new FrmGruposPermisos();
            frmGruposPermisos.Show();
            this.Close();
        }
    }


}
