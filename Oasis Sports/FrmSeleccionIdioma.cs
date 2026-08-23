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
    public partial class FrmSeleccionIdioma : Form, IObserverIdioma
    {
        BLL_Idioma bllIdioma = new BLL_Idioma();
        BLL_Traduccion bllTraduccion = new BLL_Traduccion();

        public FrmSeleccionIdioma()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmSeleccionIdioma_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            cmbIdiomas.DataSource = bllIdioma.Listar();
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "IdIdioma";
            //RegistrarClaves();
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

            foreach (Control c in this.Controls)
                RegistrarRecursivo(c, idIdioma, bll);
        }

        private void RegistrarRecursivo(Control c, int idIdioma, BLL_Traduccion bll)
        {
            if (!string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text))
            {
                bll.GuardarOActualizar(new Traduccion
                {
                    IdIdioma = idIdioma,
                    Clave = c.Name,
                    Texto = c.Text
                });
            }

            foreach (Control hijo in c.Controls)
                RegistrarRecursivo(hijo, idIdioma, bll);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbIdiomas.SelectedValue == null) return;

            int idIdioma = (int)cmbIdiomas.SelectedValue;
            bllTraduccion.CambiarIdioma(idIdioma);


            this.Close();
        }

        
        
    }
}