using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class FrmRegistrarResultado : BaseForm, IObserverIdioma
    {
        public FrmRegistrarResultado()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Resultado bllResultado_348LC = new BLL_Resultado();
        int idPartidoSeleccionado_348LC = 0;

        private void FrmRegistrarResultado_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();
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

        private void CargarGrilla_348LC()
        {
            if (cmbTorneo.SelectedValue == null)
                return;

            int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
            dgvPartidosPendientes.DataSource = bllResultado_348LC.ListarPendientes_348LC(idTorneo_348LC);
            dgvPartidosPendientes.Columns["Eliminado"].Visible = false;
            dgvPartidosPendientes.Columns["DVH"].Visible = false;
            dgvPartidosPendientes.Columns["Id"].Visible = false;
            dgvPartidosPendientes.Columns["IdEquipoLocal"].Visible = false;
            dgvPartidosPendientes.Columns["IdEquipoVisitante"].Visible = false;
            dgvPartidosPendientes.Columns["IdTorneo"].Visible = false;

        }

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla_348LC();
        }

        private void dgvPartidosPendientes_SelectionChanged(object sender, EventArgs e)
        {
            {
                if (dgvPartidosPendientes.CurrentRow == null)
                    return;

                Partido partido_348LC = (Partido)dgvPartidosPendientes.CurrentRow.DataBoundItem;
                idPartidoSeleccionado_348LC = partido_348LC.Id;
            }
        }


        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (cmbTorneo.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un torneo.");
                return;
            }

            Torneo torneo_348LC = (Torneo)cmbTorneo.SelectedItem;

            try
            {
                string reporte_348LC = bllTorneo_348LC.GenerarReporte_348LC(torneo_348LC.Id);
                string ruta_348LC;

                using (SaveFileDialog guardar_348LC = new SaveFileDialog())
                {
                    string carpeta_348LC = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes");
                    Directory.CreateDirectory(carpeta_348LC);

                    guardar_348LC.Title = "Guardar reporte del torneo";
                    guardar_348LC.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    guardar_348LC.DefaultExt = "pdf";
                    guardar_348LC.InitialDirectory = carpeta_348LC;
                    guardar_348LC.FileName = $"Torneo_{torneo_348LC.Id:D4}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (guardar_348LC.ShowDialog() != DialogResult.OK)
                        return;

                    ruta_348LC = guardar_348LC.FileName;
                }

                GenerarPdfReporte_348LC(torneo_348LC, reporte_348LC, ruta_348LC);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Registrar Resultado",
                    Descripcion = "Reporte de torneo generado",
                    Fecha = DateTime.Now,
                    Criticidad = 5
                });

                MessageBox.Show("Reporte guardado en:\n" + ruta_348LC);
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void GenerarPdfReporte_348LC(Torneo torneo_348LC, string reporte_348LC, string ruta_348LC)
        {
            try
            {
                if (File.Exists(ruta_348LC))
                    File.Delete(ruta_348LC);
            }
            catch (IOException)
            {
                throw new Exception("No se puede reemplazar el archivo porque está abierto en otro programa. Cerralo o elegí otro nombre.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("No hay permisos para guardar el reporte en esa ubicación. Elegí otra carpeta.");
            }

            string[] lineas_348LC = reporte_348LC.Replace("\r", "").TrimEnd('\n').Split('\n');
            int lineaActual_348LC = 0;
            int pagina_348LC = 1;

            using (PrintDocument documento_348LC = new PrintDocument())
            {
                documento_348LC.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                if (!documento_348LC.PrinterSettings.IsValid)
                    throw new Exception("No está instalada la impresora \"Microsoft Print to PDF\".");

                documento_348LC.PrinterSettings.PrintToFile = true;
                documento_348LC.PrinterSettings.PrintFileName = ruta_348LC;
                documento_348LC.DocumentName = $"Reporte {torneo_348LC.NombreTorneo}";
                documento_348LC.PrintController = new StandardPrintController();

                documento_348LC.PrintPage += (s_348LC, ev_348LC) =>
                {
                    Graphics g_348LC = ev_348LC.Graphics;
                    Rectangle margen_348LC = ev_348LC.MarginBounds;
                    float y_348LC = margen_348LC.Top;

                    using (Font titulo_348LC = new Font("Times New Roman", 22, FontStyle.Bold))
                    using (Font subtitulo_348LC = new Font("Times New Roman", 14, FontStyle.Italic))
                    using (Font texto_348LC = new Font("Courier New", 9))
                    using (Font pie_348LC = new Font("Times New Roman", 9))
                    {
                        if (pagina_348LC == 1)
                        {
                            g_348LC.DrawString("OASIS SPORTS", titulo_348LC, Brushes.Black, margen_348LC.Left, y_348LC);
                            y_348LC += titulo_348LC.GetHeight(g_348LC);

                            g_348LC.DrawString("Reporte de torneo", subtitulo_348LC, Brushes.Black, margen_348LC.Left, y_348LC);
                            y_348LC += subtitulo_348LC.GetHeight(g_348LC) + 10;

                            g_348LC.DrawLine(Pens.Black, margen_348LC.Left, y_348LC, margen_348LC.Right, y_348LC);
                            y_348LC += 20;
                        }

                        float altoLinea_348LC = texto_348LC.GetHeight(g_348LC);

                        while (lineaActual_348LC < lineas_348LC.Length && y_348LC + altoLinea_348LC <= margen_348LC.Bottom)
                        {
                            g_348LC.DrawString(lineas_348LC[lineaActual_348LC], texto_348LC, Brushes.Black, margen_348LC.Left, y_348LC);
                            y_348LC += altoLinea_348LC;
                            lineaActual_348LC++;
                        }

                        g_348LC.DrawString($"{torneo_348LC.NombreTorneo} - Página {pagina_348LC}", pie_348LC, Brushes.Black,
                            margen_348LC.Left, margen_348LC.Bottom + 10);
                    }

                    pagina_348LC++;
                    ev_348LC.HasMorePages = lineaActual_348LC < lineas_348LC.Length;
                };

                documento_348LC.Print();
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (idPartidoSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un partido de la grilla.");
                return;
            }

            try
            {
                if (chkSuspendido.Checked)
                {
                    bllResultado_348LC.Suspender_348LC(idPartidoSeleccionado_348LC);
                    MessageBox.Show("Partido marcado como suspendido. El Organizador debe reprogramarlo.");
                }
                else
                {
                    int golesLocal_348LC = Convert.ToInt32(nudGolesLocal.Value);
                    int golesVisitante_348LC = Convert.ToInt32(nudGolesVisitante.Value);

                    bllResultado_348LC.RegistrarResultado_348LC(idPartidoSeleccionado_348LC, golesLocal_348LC, golesVisitante_348LC);
                    MessageBox.Show("Resultado registrado correctamente.");
                }

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Registrar Resultado",
                    Descripcion = chkSuspendido.Checked ? "Partido suspendido" : "Nuevo resultado",
                    Fecha = DateTime.Now,
                    Criticidad = 4
                });

                CargarGrilla_348LC();
                idPartidoSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }
    }
}
