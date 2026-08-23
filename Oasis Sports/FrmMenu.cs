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
    public partial class FrmMenu : BaseForm, IObserverIdioma
    {
        public FrmMenu()
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


        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);

        }


        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }



        private void lOGINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();

            frmLogin.Show();
            this.Hide();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de cerrar sesion?", "Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (SessionManager.GetInstance().IsLogged())
                {
                    BLL_Evento bllEvento = new BLL_Evento();

                    bllEvento.RegistrarEvento(new Evento()
                    {
                        Usuario = SessionManager.GetInstance().Usuario.Username,
                        Modulo = "Login",
                        Descripcion = "Cierre de sesión",
                        Fecha = DateTime.Now,
                        Criticidad = 1
                    });

                    SessionManager.GetInstance().Logout();
                    MessageBox.Show("Sesion cerrada con exito");
                    OcultarControles();
                }
                else
                {
                    MessageBox.Show("No existe una sesion activa");
                }
            }
        }

        BLL_Permisos permisosBLL = new BLL_Permisos();

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            OcultarControles();
            if (!SessionManager.GetInstance().IsLogged())
                return;

            AplicarPermisos();
            LanguageManager.GetInstance().TraducirControles(this);
            RegistrarClaves();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void bITACORAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBitacora frm = new FrmBitacora();
            frm.ShowDialog();
        }

        private void bitacoraToolStripMenuItem_VisibleChanged(object sender, EventArgs e) { }

        private void OcultarControles()
        {
            bitacoraToolStripMenuItem.Visible = false;
            bITACORAToolStripMenuItem1.Visible = false;
            gESTIONDEUSUARIOSToolStripMenuItem.Visible = false;
            gESTIONDEPERFILESToolStripMenuItem.Visible = false;
            gESTIONDERESERVASToolStripMenuItem.Visible = false;
            gESTIONDEIDIOMASToolStripMenuItem.Visible = false;
            bITACORADECAMBIOSToolStripMenuItem.Visible = false;

        }

        private void AplicarPermisos()
        {
            if (SessionManager.GetInstance().IsLogged())
            {
                bITACORAToolStripMenuItem1.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "BTE");
                gESTIONDEUSUARIOSToolStripMenuItem.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "GUS");
                gESTIONDERESERVASToolStripMenuItem.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "GRE");
                gESTIONDEPERFILESToolStripMenuItem.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "GPE");
                gESTIONDEIDIOMASToolStripMenuItem.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "GID");
                bITACORADECAMBIOSToolStripMenuItem.Visible = permisoBLL.UsuarioTienePermiso(SessionManager.GetInstance().Usuario.Id, "BDC");


                bitacoraToolStripMenuItem.Visible = true;
            }
        }

        private void gESTIONDEUSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frmGestionUsuarios = new FrmGestionUsuarios();
            frmGestionUsuarios.Show();
            this.Hide();
        }

        private void gESTIONDEPERFILESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionPerfiles frmGestionPerfiles = new FrmGestionPerfiles();
            frmGestionPerfiles.Show();
            this.Hide();
        }

        private void gESTIONDEIDIOMASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private BLL_Permisos permisoBLL = new BLL_Permisos();

        private void bITACORADECAMBIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialCambios frm = new FrmHistorialCambios(
           SessionManager.GetInstance().Usuario.Id,
           SessionManager.GetInstance().Usuario.Username);

            frm.ShowDialog();
        }

        private void sELECCIONARIDIOMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionIdioma frmSeleccionIdioma = new FrmSeleccionIdioma();
            frmSeleccionIdioma.ShowDialog();
        }

        private void cREARIDIOMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIdiomas frmIdiomas = new FrmIdiomas();
            frmIdiomas.Show();
            this.Hide();
        }
    }
}
