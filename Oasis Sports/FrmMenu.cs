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

        private void cAMBIARCONTRASEÑAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambiarContraseña frmCambiarContraseña = new FrmCambiarContraseña();
            frmCambiarContraseña.Show();
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

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            OcultarControles();
            LanguageManager.GetInstance().TraducirControles(this);
            if (!SessionManager.GetInstance().IsLogged())
                return;

            AplicarPermisos();
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
            mAESTROSToolStripMenuItem.Visible = false;
            gESTIONDECLASESToolStripMenuItem.Visible = false;
            cAMBIARCONTRASEÑAToolStripMenuItem.Visible = false;

        }

        private void AplicarPermisos()
        {
            if (!SessionManager.GetInstance().IsLogged())
                return;

            AplicarPermiso(gESTIONDEUSUARIOSToolStripMenuItem, "SE001");
            AplicarPermiso(gESTIONDEPERFILESToolStripMenuItem, "SE002");
            AplicarPermiso(bITACORAToolStripMenuItem1, "SE003");
            AplicarPermiso(bITACORADECAMBIOSToolStripMenuItem, "SE004");

            AplicarPermiso(sELECCIONARIDIOMAToolStripMenuItem, "ID001");
            AplicarPermiso(cREARIDIOMAToolStripMenuItem, "ID002");

            AplicarPermiso(eQUIPOSToolStripMenuItem, "MA001");
            AplicarPermiso(jUGADORESToolStripMenuItem, "MA002");
            AplicarPermiso(pROFESORESToolStripMenuItem, "MA003");
            AplicarPermiso(pARTICIPANTESToolStripMenuItem, "MA004");

            AplicarPermiso(tORNEOSToolStripMenuItem, "TO001");
            AplicarPermiso(aSIGNAREQUIPOSToolStripMenuItem, "TO002");
            AplicarPermiso(oRGANIZARPARTIDOSToolStripMenuItem, "TO003");
            AplicarPermiso(rEGISTRARRESULTADOSToolStripMenuItem, "TO004");

            AplicarPermiso(cREARCLASEToolStripMenuItem, "CL001");
            AplicarPermiso(iNSCRIBIRPARTICIPANTEToolStripMenuItem, "CL002");
            AplicarPermiso(rEGISTRARPAGOToolStripMenuItem, "CL003");

            MostrarSiTieneOpciones(bitacoraToolStripMenuItem);
            MostrarSiTieneOpciones(gESTIONDEIDIOMASToolStripMenuItem);
            MostrarSiTieneOpciones(mAESTROSToolStripMenuItem);
            MostrarSiTieneOpciones(gESTIONDERESERVASToolStripMenuItem);
            MostrarSiTieneOpciones(gESTIONDECLASESToolStripMenuItem);

            cAMBIARCONTRASEÑAToolStripMenuItem.Visible = true;
        }

        private void AplicarPermiso(ToolStripMenuItem item, string codigoPermiso)
        {
            item.Visible = permisoBLL.TienePermiso(codigoPermiso);
        }

        private void MostrarSiTieneOpciones(ToolStripMenuItem menu)
        {
            menu.Visible = menu.DropDownItems.Cast<ToolStripItem>().Any(i => i.Available);
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
            FrmHistorialCambios frm = new FrmHistorialCambios();
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

        private void eQUIPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipos frmEquipos = new FrmEquipos();
            frmEquipos.Show();
            this.Hide();
        }

        private void jUGADORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmJugadores frmJugadores = new FrmJugadores();
            frmJugadores.Show();
            this.Hide();
        }

        private void pROFESORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfesores frmProfesores = new FrmProfesores();
            frmProfesores.Show();
            this.Hide();
        }

        private void pARTICIPANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParticipantes frmParticipantes = new FrmParticipantes();
            frmParticipantes.Show();
            this.Hide();
        }

        private void gESTIONDERESERVASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tORNEOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTorneo frmTorneo = new FrmTorneo();
            frmTorneo.Show();
            this.Close();
        }

        private void aSIGNAREQUIPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInscripcion frmInscripcion = new FrmInscripcion();
            frmInscripcion.Show();
            this.Close();
        }

        private void oRGANIZARPARTIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrganizarPartidos frmOrganizarPartidos = new FrmOrganizarPartidos();
            frmOrganizarPartidos.Show();
            this.Close();
        }

        private void rEGISTRARRESULTADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarResultado frmRegistrarResultado = new FrmRegistrarResultado();
            frmRegistrarResultado.Show();
            this.Close();
        }

        private void cREARCLASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrearClase frmCrearClase = new FrmCrearClase();
            frmCrearClase.Show();
            this.Close();
        }

        private void iNSCRIBIRPARTICIPANTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInscribirParticipante frmInscribirParticipante = new FrmInscribirParticipante();
            frmInscribirParticipante.Show();
            this.Close();
        }

        private void rEGISTRARPAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarPago frmRegistrarPago = new FrmRegistrarPago();
            frmRegistrarPago.Show();
            this.Close();
        }
    }
}
