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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Oasis_Sports
{
    public partial class FrmLogin : BaseForm, IObserverIdioma
    {
        BLLUsuario bllUsuario = new BLLUsuario();

        public FrmLogin()
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

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = frmMenu = new FrmMenu();

            frmMenu.Show();
            this.Hide();
        }

        Encriptacion encriptador = new Encriptacion();
        BLL_DV bLL_DV = new BLL_DV();

        private void button1_Click(object sender, EventArgs e)
        {
            if (SessionManager.GetInstance().IsLogged())
            {
                MessageBox.Show("Ya hay una sesión activa");
                return;
            }

            //bllUsuario.InicializarDVs();  //Solo para la primera vez que se usa


            try
            {
                Usuario user = bllUsuario.ValidarUsuario(textBox1.Text, textBox2.Text);

                

                BLL_Evento bllEvento = new BLL_Evento();
                BLL_Permisos bllPermisos = new BLL_Permisos();


                if (!bLL_DV.VerificarIntegridad() && bllPermisos.EsAdministrador(user.Id))
                {
                    DialogResult resultado = MessageBox.Show(
                        "Se detectó una alteración en los datos.\n¿Desea recalcular los dígitos verificadores?",
                        "Error de integridad",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {

                        bLL_DV.InicializarDVs();

                        MessageBox.Show(
                            "Dígitos verificadores recalculados correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        return;
                    }
                }

                else if (!bLL_DV.VerificarIntegridad() && !bllPermisos.EsAdministrador(user.Id))
                {
                    MessageBox.Show(
                           "No se puede ingresar al sistema en estos momentos. Contacte a un administrador.",
                           "Sin autorización",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    return;
                }

                SessionManager.GetInstance().Login(user);

                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = user.Username,
                    Modulo = "Login",
                    Descripcion = "Inicio de sesión",
                    Fecha = DateTime.Now,
                    Criticidad = 1
                });

                

                MessageBox.Show("Bienvenido " + user.Username);


                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                BLL_Evento bllEvento = new BLL_Evento();

                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = textBox1.Text,
                    Modulo = "Login",
                    Descripcion = "Intento fallido",
                    Fecha = DateTime.Now,
                    Criticidad = 3
                });

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            textBox2.Text = "1234";
            textBox1.Text = "Lucas";
            LanguageManager.GetInstance().TraducirControles(this);
            RegistrarClaves();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void FrmLogin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmSeleccionIdioma frmIdioma = new FrmSeleccionIdioma();
            frmIdioma.ShowDialog();
        }
    }
}
