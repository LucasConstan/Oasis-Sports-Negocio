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



        private void CargarPermisosAsignados(int usuarioId)
        {
            treeView1.Nodes.Clear();

            List<ComponentePermiso> permisos = permisoBLL.ObtenerPermisosUsuario(usuarioId);

            foreach (ComponentePermiso permiso in permisos)
            {
                treeView1.Nodes.Add(CrearNodoPermiso(permiso));
            }

            treeView1.ExpandAll();
        }

        private TreeNode CrearNodoPermiso(ComponentePermiso permiso)
        {
            TreeNode nodo = new TreeNode();

            if (permiso is GrupoPermisos)
                nodo.Text = "[Grupo] " + permiso.Nombre;
            else
                nodo.Text = "[Permiso] " + permiso.Nombre;

            nodo.Tag = permiso;

            foreach (ComponentePermiso hijo in permiso.ObtenerHijos())
            {
                TreeNode nodoHijo = CrearNodoPermiso(hijo);

                nodo.Nodes.Add(nodoHijo);
            }

            return nodo;
        }

        private void CargarUsuarios()
        {
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DisplayMember = "Username";
            cmbUsuarios.ValueMember = "Id";
            cmbUsuarios.DataSource = usuarioBLL.Listar();
        }

        private void CargarLista()
        {
            lstDisponibles.DataSource = null;
            lstDisponibles.DisplayMember = "Nombre";
            lstDisponibles.ValueMember = "Id";
            lstDisponibles.DataSource = permisoBLL.ObtenerTodos();
        }

        private void FrmGestionPerfiles_Load(object sender, EventArgs e)
        {

            CargarUsuarios();
            CargarLista();
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

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;

            if (usuario == null)
                return;

            CargarPermisosAsignados(usuario.Id);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;
            ComponentePermiso permiso = lstDisponibles.SelectedItem as ComponentePermiso;

            if (usuario == null || permiso == null)
            {
                MessageBox.Show("Seleccione un usuario y un permiso");
                return;
            }


            permisoBLL.AsignarPermiso(usuario.Id, permiso.Id);
            CargarPermisosAsignados(usuario.Id);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Usuario usuario = cmbUsuarios.SelectedItem as Usuario;

            if (usuario == null || treeView1.SelectedNode == null)
                return;

            if (treeView1.SelectedNode.Parent != null)
            {
                MessageBox.Show("No se puede quitar un permiso heredado. Debe quitarse el grupo que lo contiene.");
                return;
            }

            ComponentePermiso permiso = treeView1.SelectedNode.Tag as ComponentePermiso;

            if (permiso == null)
            {
                MessageBox.Show("Seleccione un usuario y un permiso");
                return;
            }


            permisoBLL.QuitarPermisoAUsuario(usuario.Id, permiso.Id);

            CargarPermisosAsignados(usuario.Id);
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
