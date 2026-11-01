using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            CargarBitacora();
            CargarFiltros();
            LimpiarFiltros();
        }

        private void CargarBitacora()
        {
            tablaEventos = bllEvento.ListarEventos();

            dgvBitacora.DataSource = tablaEventos.DefaultView;

            if (dgvBitacora.Columns.Contains("IdEvento"))
                dgvBitacora.Columns["IdEvento"].Visible = false;
        }

        private void CargarFiltros()
        {
            cmbModulo.Items.Clear();
            cmbModulo.Items.Add("Todos");
            foreach (string modulo in tablaEventos.AsEnumerable()
                .Select(r => r["Modulo"].ToString())
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Distinct()
                .OrderBy(m => m))
                cmbModulo.Items.Add(modulo);

            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.Add("Todas");
            foreach (int criticidad in tablaEventos.AsEnumerable()
                .Select(r => Convert.ToInt32(r["Criticidad"]))
                .Distinct()
                .OrderBy(c => c))
                cmbCriticidad.Items.Add(criticidad.ToString());
        }

        private void LimpiarFiltros()
        {
            txtUsuario.Clear();
            cmbModulo.SelectedIndex = 0;
            cmbCriticidad.SelectedIndex = 0;

            DateTime fechaMinima = tablaEventos.Rows.Count > 0
                ? tablaEventos.AsEnumerable().Min(r => Convert.ToDateTime(r["Fecha"])).Date
                : DateTime.Today.AddMonths(-1);

            dtpDesde.Value = fechaMinima;
            dtpHasta.Value = DateTime.Today;

            tablaEventos.DefaultView.RowFilter = "";
        }

        private string EscaparTextoFiltro(string texto)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in texto)
            {
                if (c == '[' || c == ']' || c == '*' || c == '%')
                    resultado.Append('[').Append(c).Append(']');
                else if (c == '\'')
                    resultado.Append("''");
                else
                    resultado.Append(c);
            }

            return resultado.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.");
                return;
            }

            List<string> condiciones = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                condiciones.Add($"Usuario LIKE '%{EscaparTextoFiltro(txtUsuario.Text.Trim())}%'");

            if (cmbModulo.SelectedIndex > 0)
                condiciones.Add($"Modulo = '{cmbModulo.Text.Replace("'", "''")}'");

            if (cmbCriticidad.SelectedIndex > 0)
                condiciones.Add($"Criticidad = {Convert.ToInt32(cmbCriticidad.Text)}");

            string desde = dtpDesde.Value.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string hasta = dtpHasta.Value.Date.AddDays(1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            condiciones.Add($"Fecha >= #{desde}#");
            condiciones.Add($"Fecha < #{hasta}#");

            tablaEventos.DefaultView.RowFilter = string.Join(" AND ", condiciones);

            if (tablaEventos.DefaultView.Count == 0)
                MessageBox.Show("No se encontraron eventos con los filtros seleccionados.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
