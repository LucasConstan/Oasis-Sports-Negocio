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

        private void FrmGruposPermisos_Load(object sender, EventArgs e)
        {
            CargarPermisosDisponibles();
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
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

        private void CargarPermisosDisponibles()
        {
            lstPermisosDisponibles.DataSource = null;
            lstPermisosDisponibles.DataSource = permisoBLL.ObtenerTodos();
            lstPermisosDisponibles.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ComponentePermiso permiso = lstPermisosDisponibles.SelectedItem as ComponentePermiso;

            if (permiso == null)
                return;

            if (permisosSeleccionados.Any(p => p.Id == permiso.Id))
            {
                MessageBox.Show("Ese permiso ya fue agregado al grupo.");
                return;
            }

            permisosSeleccionados.Add(permiso);
            RefrescarPermisosDelGrupo();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ComponentePermiso permiso = lstPermisosDelGrupo.SelectedItem as ComponentePermiso;

            if (permiso == null)
                return;

            permisosSeleccionados.Remove(permiso);
            RefrescarPermisosDelGrupo();
        }

        private void RefrescarPermisosDelGrupo()
        {
            lstPermisosDelGrupo.DataSource = null;
            lstPermisosDelGrupo.DataSource = permisosSeleccionados.ToList();
            lstPermisosDelGrupo.DisplayMember = "Nombre";
        }

        private bool modoModificacion = false;
        private int grupoIdSeleccionado = -1;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreGrupo = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreGrupo))
            {
                MessageBox.Show("Debe ingresar un nombre para el grupo.");
                return;
            }

            if (permisosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un permiso al grupo.");
                return;
            }

            if (modoModificacion)
            {
                permisoBLL.ModificarGrupoPermiso(grupoIdSeleccionado, nombreGrupo, permisosSeleccionados);
                MessageBox.Show("Grupo modificado correctamente.");
            }
            else
            {
                List<ComponentePermiso> existentes = permisoBLL.ObtenerTodos();

                if (permisoBLL.ExisteGrupoConNombre(nombreGrupo, existentes))
                {
                    MessageBox.Show(
                        $"Ya existe un grupo con el nombre '{nombreGrupo}'.",
                        "Nombre duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int grupoId = permisoBLL.CrearGrupoPermiso(nombreGrupo);
                foreach (ComponentePermiso permiso in permisosSeleccionados)
                    permisoBLL.AgregarPermisoAGrupo(grupoId, permiso.Id);
                MessageBox.Show("Grupo creado correctamente.");
            }


            modoModificacion = false;
            grupoIdSeleccionado = -1;
            textBox1.Clear();
            permisosSeleccionados.Clear();
            RefrescarPermisosDelGrupo();
            CargarPermisosDisponibles();
            lblmodo.Text = "Modo: Nuevo grupo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestionPerfiles frmGestionPerfiles = new FrmGestionPerfiles();
            frmGestionPerfiles.Show();
            this.Hide();
        }


        private void lstPermisosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComponentePermiso seleccionado = lstPermisosDisponibles.SelectedItem as ComponentePermiso;
            btnModificar.Enabled = seleccionado is GrupoPermisos;
            btnEliminar.Enabled = seleccionado is GrupoPermisos;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            GrupoPermisos grupo = lstPermisosDisponibles.SelectedItem as GrupoPermisos;
            if (grupo == null) return;

            modoModificacion = true;
            grupoIdSeleccionado = grupo.Id;
            textBox1.Text = grupo.Nombre;
            permisosSeleccionados = permisoBLL.ObtenerPermisosGrupo(grupoIdSeleccionado);
            RefrescarPermisosDelGrupo();
            lblmodo.Text = "Modo: Modificando: " + grupo.Nombre;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            modoModificacion = false;
            grupoIdSeleccionado = -1;
            textBox1.Clear();
            permisosSeleccionados.Clear();
            RefrescarPermisosDelGrupo();
            lblmodo.Text = "Modo: Nuevo grupo";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GrupoPermisos grupo = lstPermisosDisponibles.SelectedItem as GrupoPermisos;
            if (grupo == null) return;

            if (permisoBLL.GrupoPoseeUsuarios(grupo.Id))
            {
                MessageBox.Show(
                    $"No se puede eliminar el grupo '{grupo.Nombre}' porque hay usuarios que lo tienen asignado.",
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro que querés eliminar el grupo '{grupo.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            if (grupo.Id == 6) 
            {
                MessageBox.Show(
                    "No se puede eliminar el perfil Admin","Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            permisoBLL.EliminarGrupoPermiso(grupo.Id);
            MessageBox.Show("Grupo eliminado correctamente.");
            CargarPermisosDisponibles();
        }
    }
}
