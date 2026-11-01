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
    public partial class FrmGruposPermisos : BaseForm, IObserverIdioma
    {
        public FrmGruposPermisos()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private BLL_Permisos permisoBLL = new BLL_Permisos();
        private List<ComponentePermiso> permisosSeleccionados = new List<ComponentePermiso>();
        private int grupoIdSeleccionado = -1;
        private bool hayCambiosSinGuardar = false;

        private void FrmGruposPermisos_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            CargarPermisosDisponibles();
            LimpiarFormulario();
        }

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

        private string Texto(string clave)
        {
            return LanguageManager.GetInstance().ObtenerTexto(clave);
        }

        private void CargarPermisosDisponibles()
        {
            List<ComponentePermiso> arboles = permisoBLL.ObtenerArbolesCompletos();
            Dictionary<int, int> usuariosPorPerfil = permisoBLL.ObtenerCantidadUsuariosPorPerfil();

            TreeNode nodoGrupos = new TreeNode();
            TreeNode nodoPermisos = new TreeNode();

            foreach (ComponentePermiso permiso in arboles)
            {
                if (permiso is GrupoPermisos)
                {
                    TreeNode nodoGrupo = CrearNodoPermiso(permiso);

                    if (usuariosPorPerfil.TryGetValue(permiso.Id, out int cantidad))
                    {
                        nodoGrupo.ForeColor = Color.DarkBlue;
                        nodoGrupo.ToolTipText = $"{Texto("Perfil de")} {cantidad} {Texto(cantidad == 1 ? "usuario" : "usuarios")}";
                    }

                    nodoGrupos.Nodes.Add(nodoGrupo);
                }
                else
                    nodoPermisos.Nodes.Add(CrearNodoPermiso(permiso));
            }

            nodoGrupos.Text = $"{Texto("Grupos")} ({nodoGrupos.Nodes.Count})";
            nodoPermisos.Text = $"{Texto("Permisos individuales")} ({nodoPermisos.Nodes.Count})";

            treePermisosDisponibles.BeginUpdate();
            treePermisosDisponibles.Nodes.Clear();
            treePermisosDisponibles.Nodes.Add(nodoGrupos);
            treePermisosDisponibles.Nodes.Add(nodoPermisos);
            nodoGrupos.Expand();
            nodoPermisos.Expand();
            treePermisosDisponibles.EndUpdate();
            treePermisosDisponibles.TopNode = nodoGrupos;

            ActualizarBotones();
        }

        private void RefrescarPermisosDelGrupo()
        {
            treePermisosDelGrupo.BeginUpdate();
            treePermisosDelGrupo.Nodes.Clear();

            foreach (ComponentePermiso permiso in permisosSeleccionados)
                treePermisosDelGrupo.Nodes.Add(CrearNodoPermiso(permiso));

            treePermisosDelGrupo.ExpandAll();
            treePermisosDelGrupo.EndUpdate();

            if (treePermisosDelGrupo.Nodes.Count > 0)
                treePermisosDelGrupo.TopNode = treePermisosDelGrupo.Nodes[0];

            ActualizarBotones();
        }

        private TreeNode CrearNodoPermiso(ComponentePermiso permiso)
        {
            bool esGrupo = permiso is GrupoPermisos;

            TreeNode nodo = new TreeNode($"{Texto(esGrupo ? "Grupo" : "Permiso")}: {permiso}");
            nodo.Tag = permiso;

            if (!esGrupo)
                nodo.NodeFont = this.Font;

            foreach (ComponentePermiso hijo in permiso.ObtenerHijos())
                nodo.Nodes.Add(CrearNodoPermiso(hijo));

            return nodo;
        }

        private void ActualizarBotones()
        {
            ComponentePermiso disponible = treePermisosDisponibles.SelectedNode?.Tag as ComponentePermiso;
            TreeNode nodoDelGrupo = treePermisosDelGrupo.SelectedNode;

            btnAgregarAlGrupo.Enabled = disponible != null;
            btnEditarGrupo.Enabled = disponible is GrupoPermisos;
            btnEliminarGrupo.Enabled = disponible is GrupoPermisos;
            btnQuitarDelGrupo.Enabled = nodoDelGrupo != null;
        }

        private void LimpiarFormulario()
        {
            grupoIdSeleccionado = -1;
            txtCodigo.Clear();
            txtNombreGrupo.Clear();
            permisosSeleccionados = new List<ComponentePermiso>();
            RefrescarPermisosDelGrupo();
            lblEstadoGrupo.Text = Texto("Creando un grupo nuevo");
            hayCambiosSinGuardar = false;
        }

        private bool ConfirmarDescartarCambios()
        {
            if (!hayCambiosSinGuardar)
                return true;

            DialogResult resultado = MessageBox.Show(
                "Hay cambios sin guardar en el grupo. ¿Desea descartarlos?",
                "Cambios sin guardar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
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

        private void AgregarSeleccionado()
        {
            ComponentePermiso permiso = treePermisosDisponibles.SelectedNode?.Tag as ComponentePermiso;

            if (permiso == null)
            {
                MessageBox.Show("Seleccione en la lista de la izquierda el grupo o permiso que desea agregar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                permisoBLL.ValidarPermisoParaGrupo(grupoIdSeleccionado, permiso, permisosSeleccionados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            permisosSeleccionados.Add(permiso);
            hayCambiosSinGuardar = true;
            RefrescarPermisosDelGrupo();
        }

        private void QuitarSeleccionado()
        {
            TreeNode nodo = treePermisosDelGrupo.SelectedNode;

            if (nodo == null)
            {
                MessageBox.Show("Seleccione en 'Contenido del grupo' lo que desea quitar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nodo.Parent != null)
            {
                TreeNode raiz = nodo;
                while (raiz.Parent != null)
                    raiz = raiz.Parent;

                MessageBox.Show(
                    $"'{nodo.Tag}' viene incluido dentro de '{raiz.Tag}'. Para quitarlo, quite '{raiz.Tag}' completo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ComponentePermiso permiso = nodo.Tag as ComponentePermiso;

            if (permiso == null)
                return;

            permisosSeleccionados.RemoveAll(p => p.Id == permiso.Id);
            hayCambiosSinGuardar = true;
            RefrescarPermisosDelGrupo();
        }

        private void treePermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ActualizarBotones();
        }

        private void treePermisosDisponibles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is ComponentePermiso)
            {
                treePermisosDisponibles.SelectedNode = e.Node;
                AgregarSeleccionado();
            }
        }

        private void treePermisosDelGrupo_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treePermisosDelGrupo.SelectedNode = e.Node;
            QuitarSeleccionado();
        }

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {
            hayCambiosSinGuardar = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarSeleccionado();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarSeleccionado();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grupoIdSeleccionado != -1)
                {
                    permisoBLL.ModificarGrupoPermiso(grupoIdSeleccionado, txtCodigo.Text, txtNombreGrupo.Text, permisosSeleccionados);
                    RegistrarEventoPerfiles("Modificación de grupo de permisos: " + txtCodigo.Text.Trim(), 2);
                    MessageBox.Show("Grupo modificado correctamente.");
                }
                else
                {
                    permisoBLL.CrearGrupoPermiso(txtCodigo.Text, txtNombreGrupo.Text, permisosSeleccionados);
                    RegistrarEventoPerfiles("Alta de grupo de permisos: " + txtCodigo.Text.Trim(), 2);
                    MessageBox.Show("Grupo creado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarFormulario();
            CargarPermisosDisponibles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            GrupoPermisos grupo = treePermisosDisponibles.SelectedNode?.Tag as GrupoPermisos;
            if (grupo == null) return;

            if (!ConfirmarDescartarCambios()) return;

            grupoIdSeleccionado = grupo.Id;
            txtCodigo.Text = grupo.Codigo;
            txtNombreGrupo.Text = grupo.Nombre;
            permisosSeleccionados = grupo.ObtenerHijos().ToList();
            RefrescarPermisosDelGrupo();
            lblEstadoGrupo.Text = $"{Texto("Editando el grupo")} {grupo}";
            hayCambiosSinGuardar = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ConfirmarDescartarCambios()) return;

            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GrupoPermisos grupo = treePermisosDisponibles.SelectedNode?.Tag as GrupoPermisos;
            if (grupo == null) return;

            if (grupo.Codigo == BLL_Permisos.CODIGO_PERFIL_ADMIN)
            {
                MessageBox.Show("No se puede eliminar el perfil Administrador.", "Operación no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (permisoBLL.GrupoPoseeUsuarios(grupo.Id))
            {
                MessageBox.Show(
                    $"No se puede eliminar el grupo '{grupo}' porque es el perfil de al menos un usuario.",
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar el grupo '{grupo}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                permisoBLL.EliminarGrupoPermiso(grupo.Id);
                RegistrarEventoPerfiles("Baja de grupo de permisos: " + grupo.Codigo, 3);
                MessageBox.Show("Grupo eliminado correctamente.");

                if (grupoIdSeleccionado == grupo.Id)
                    LimpiarFormulario();

                CargarPermisosDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (!ConfirmarDescartarCambios()) return;

            FrmGestionPerfiles frmGestionPerfiles = new FrmGestionPerfiles();
            frmGestionPerfiles.Show();
            this.Hide();
        }
    }
}
