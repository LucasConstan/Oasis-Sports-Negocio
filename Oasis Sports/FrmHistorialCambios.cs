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
using Servicios;

namespace Oasis_Sports
{
    public partial class FrmHistorialCambios : Form, IObserverIdioma
    {
        BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
        int idUsuario;
        string nombreUsuario;

        public FrmHistorialCambios(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            LanguageManager.GetInstance().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);
        }

        private void FrmHistorialCambios_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Historial de cambios: " + nombreUsuario;
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            dgvHistorial.DataSource = bllHistorial.ObtenerHistorialUsuario(idUsuario);
        }

        private void FrmHistorialCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }

        BLLUsuario bLLUsuario = new BLLUsuario();
        BLL_DV bll_DV = new BLL_DV();
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un registro de la lista.");
                return;
            }

            DataGridViewRow fila = dgvHistorial.CurrentRow;

            string campo = fila.Cells["NombreCampo"].Value?.ToString() ?? "";
            string valorAnterior = fila.Cells["ValorAnterior"].Value?.ToString() ?? "";


            if (valorAnterior == "(restauración)")
            {
                MessageBox.Show("Este registro es una restauración, no se puede volver a restaurar.");
                return;
            }


            if (campo == "Password")
            {
                MessageBox.Show("No se puede restaurar la contraseña porque está enmascarada por seguridad.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Restaurar el campo '{campo}' al valor '{valorAnterior}'?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo
            );

            if (confirmacion != DialogResult.Yes) return;

            string quienRestaura = SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            bllHistorial.RestaurarCampo(idUsuario, campo, valorAnterior, quienRestaura);
            bll_DV.InicializarDVs();

            MessageBox.Show("Campo restaurado correctamente.");
            CargarHistorial();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}