using BLL;
using Entidades;
using Servicios;

namespace Oasis_Sports
{
    public partial class FrmIdiomas : BaseForm, IObserverIdioma
    {
        BLL_Idioma bllIdioma = new BLL_Idioma();
        BLL_Traduccion bllTraduccion = new BLL_Traduccion();

        public FrmIdiomas()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);
        }

       
        private void FrmIdiomas_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);
            CargarIdiomas();
            //RegistrarClaves();
            CargarClaves();
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

            //MessageBox.Show("Claves registradas correctamente.");
            //CargarClaves();
            CargarClaves();
        }

        private void CargarIdiomas()
        {
            cmbIdiomas.DataSource = null;
            cmbIdiomas.DataSource = bllIdioma.Listar();
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "IdIdioma";
        }

        private void CargarClaves()
        {
            lstClaves.Items.Clear();
            var claves = bllTraduccion.ObtenerTodasLasClaves();
            foreach (var c in claves)
                lstClaves.Items.Add(c);
        }

       
        private void lstClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClaves.SelectedItem == null || cmbIdiomas.SelectedValue == null) return;

            string clave = lstClaves.SelectedItem.ToString()!;
            int idIdioma = (int)cmbIdiomas.SelectedValue;

            var traducciones = bllTraduccion.ObtenerPorIdioma(idIdioma);
            var t = traducciones.Find(x => x.Clave == clave);

            txtClave.Text = clave;
            txtTexto.Text = t != null ? t.Texto : "";
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbIdiomas.SelectedValue == null || string.IsNullOrWhiteSpace(txtClave.Text)) return;

            bllTraduccion.GuardarOActualizar(new Traduccion
            {
                IdIdioma = (int)cmbIdiomas.SelectedValue,
                Clave = txtClave.Text.Trim(),
                Texto = txtTexto.Text.Trim()
            });

            MessageBox.Show("Traducción guardada correctamente.");
            CargarClaves();
        }

        
        private void btnNuevoIdioma_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoIdioma.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresá un nombre para el idioma.");
                return;
            }

            bllIdioma.Agregar(new Idioma { Nombre = nombre });
            txtNuevoIdioma.Text = "";
            MessageBox.Show("Idioma creado correctamente.");
            CargarIdiomas();
        }

       
        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            if (cmbIdiomas.SelectedValue == null) return;

            int idIdioma = (int)cmbIdiomas.SelectedValue;
            bllTraduccion.CambiarIdioma(idIdioma); 
            MessageBox.Show("Idioma cambiado. Todos los formularios se actualizaron.");
        }

      
        private void btnRegistrarClaves_Click(object sender, EventArgs e)
        {
            
        }

        private void RegistrarClavesDeControl(Control.ControlCollection controles, int idIdioma)
        {
            foreach (Control c in controles)
            {
                if (!string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text))
                {
                    bllTraduccion.GuardarOActualizar(new Traduccion
                    {
                        IdIdioma = idIdioma,
                        Clave = c.Name,
                        Texto = c.Text
                    });
                }

                if (c.Controls.Count > 0)
                    RegistrarClavesDeControl(c.Controls, idIdioma);
            }
        }

        private void FrmIdiomas_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }
    }
}
