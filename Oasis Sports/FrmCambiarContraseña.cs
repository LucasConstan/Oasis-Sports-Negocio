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
    public partial class FrmCambiarContraseña : BaseForm, IObserverIdioma
    {
        BLLUsuario bllUsuario = new BLLUsuario();

        public FrmCambiarContraseña()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmCambiarContraseña_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
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

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (!SessionManager.GetInstance().IsLogged())
            {
                MessageBox.Show("No existe una sesion activa");
                return;
            }

            Usuario usuario = SessionManager.GetInstance().Usuario;

            try
            {
                bllUsuario.CambiarContraseña(usuario.Id, txtContraseñaActual.Text, txtContraseñaNueva.Text, txtConfirmarContraseña.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            BLL_Evento bllEvento = new BLL_Evento();

            bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = usuario.Username,
                Modulo = "Usuarios",
                Descripcion = "Cambio de contraseña",
                Fecha = DateTime.Now,
                Criticidad = 2
            });

            bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = usuario.Username,
                Modulo = "Login",
                Descripcion = "Cierre de sesión",
                Fecha = DateTime.Now,
                Criticidad = 1
            });

            SessionManager.GetInstance().Logout();

            MessageBox.Show("Contraseña cambiada correctamente. Inicie sesión nuevamente con su nueva contraseña.");

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }

        private void FrmCambiarContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
