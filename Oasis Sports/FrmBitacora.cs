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
    public partial class FrmBitacora : BaseForm, IObserverIdioma
    {
        BLL_Evento bllEvento = new BLL_Evento();

        DataTable tablaEventos;

        public FrmBitacora()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
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

      

        private void CargarBitacora()
        {
            tablaEventos = bllEvento.ListarEventos();

            dgvBitacora.DataSource = tablaEventos;
        }

        private void dgvBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBitacora_Load_1(object sender, EventArgs e)
        {
            CargarBitacora();

            cmbCriticidad.Items.Add("Todas");
            cmbCriticidad.Items.Add("1");
            cmbCriticidad.Items.Add("2");
            cmbCriticidad.Items.Add("3");
            cmbCriticidad.SelectedIndex = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView vista = tablaEventos.DefaultView;

            string filtro = "";


            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                filtro += $"Usuario LIKE '%{txtUsuario.Text}%'";
            }


            if (cmbCriticidad.Text != "Todas")
            {
                if (filtro != "")
                    filtro += " AND ";

                filtro += $"Criticidad = {cmbCriticidad.Text}";
            }


            if (filtro != "")
                filtro += " AND ";

            filtro += $"Fecha >= #{dtpDesde.Value:yyyy-MM-dd}#";
            filtro += $" AND Fecha <= #{dtpHasta.Value:yyyy-MM-dd 23:59:59}#";

            vista.RowFilter = filtro;

            dgvBitacora.DataSource = vista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();

            cmbCriticidad.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Today.AddMonths(-1);

            dtpHasta.Value = DateTime.Today;

            dgvBitacora.DataSource = tablaEventos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void FrmBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);

        }
    }
}
