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
    public partial class FrmRegistrarPago : BaseForm, IObserverIdioma
    {
        BLL_Pago bllPago_348LC = new BLL_Pago();
        BLL_Participante bllParticipante_348LC = new BLL_Participante();
        BLL_Matricula bllMatricula_348LC = new BLL_Matricula();
        Participante participanteSeleccionado_348LC = null;
        List<Pago> pagos_348LC = new List<Pago>();

        public FrmRegistrarPago()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void FrmRegistrarPago_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            cmbMedioPago.Items.Clear();
            cmbMedioPago.Items.AddRange(BLL_Pago.MEDIOS_PAGO);

            cmbMarcaTarjeta.Items.Clear();
            cmbMarcaTarjeta.Items.AddRange(BLL_Pago.MARCAS_TARJETA);

            cmbBancoOrigen.Items.Clear();
            cmbBancoOrigen.Items.AddRange(BLL_Pago.BANCOS_SUGERIDOS);

            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;

            CargarFiltroEstado_348LC();

            dgvPagos.CellFormatting += dgvPagos_CellFormatting;
            txtFiltroDNI.TextChanged += Filtro_Changed;
            cmbFiltroEstado.SelectedIndexChanged += Filtro_Changed;

            CargarPagos_348LC();
        }

        private string Texto_348LC(string clave_348LC, string porDefecto_348LC)
        {
            string texto_348LC = LanguageManager.GetInstance().ObtenerTexto(clave_348LC);
            return texto_348LC == clave_348LC ? porDefecto_348LC : texto_348LC;
        }

        private void CargarFiltroEstado_348LC()
        {
            int seleccionado_348LC = cmbFiltroEstado.SelectedIndex;

            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add(Texto_348LC("msgTodos", "Todos"));
            cmbFiltroEstado.Items.Add(BLL_Pago.ESTADO_PENDIENTE);
            cmbFiltroEstado.Items.Add(BLL_Pago.ESTADO_REGISTRADO);
            cmbFiltroEstado.Items.Add(BLL_Pago.ESTADO_CANCELADO);
            cmbFiltroEstado.Items.Add(BLL_Pago.ESTADO_REINTEGRADO);

            cmbFiltroEstado.SelectedIndex = seleccionado_348LC < 0 ? 0 : seleccionado_348LC;
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDetalleMedioPago_348LC();
        }

        private void MostrarDetalleMedioPago_348LC()
        {
            string medio_348LC = cmbMedioPago.SelectedItem == null ? "" : cmbMedioPago.SelectedItem.ToString();
            bool tarjeta_348LC = BLL_Pago.EsTarjeta_348LC(medio_348LC);
            bool transferencia_348LC = medio_348LC == BLL_Pago.MEDIO_TRANSFERENCIA;

            lblMarcaTarjeta.Visible = tarjeta_348LC;
            cmbMarcaTarjeta.Visible = tarjeta_348LC;
            lblUltimosDigitos.Visible = tarjeta_348LC;
            txtUltimosDigitos.Visible = tarjeta_348LC;

            lblBancoOrigen.Visible = transferencia_348LC;
            cmbBancoOrigen.Visible = transferencia_348LC;
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            MostrarPagos_348LC();
        }

        private void dgvPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvPagos.Rows[e.RowIndex].DataBoundItem is Pago pago_348LC))
                return;

            if (pago_348LC.Estado == BLL_Pago.ESTADO_PENDIENTE)
                e.CellStyle.BackColor = Color.LightYellow;
            else if (pago_348LC.Estado == BLL_Pago.ESTADO_REGISTRADO)
                e.CellStyle.BackColor = Color.Honeydew;
            else
                e.CellStyle.BackColor = Color.Gainsboro;

            if (dgvPagos.Columns[e.ColumnIndex].Name == "MedioPago" && !string.IsNullOrEmpty(pago_348LC.MedioPago))
            {
                e.Value = BLL_Pago.ObtenerDetalleMedioPago_348LC(pago_348LC);
                e.FormattingApplied = true;
            }
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(ActualizarIdioma));
            else
            {
                LanguageManager.GetInstance().TraducirControles(this);
                CargarFiltroEstado_348LC();
                MostrarPagos_348LC();
            }
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
                && !clavesExistentes.Contains(c.Name)
                && LanguageManager.GetInstance().EsTraducible(c))
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

        private void CargarPagos_348LC()
        {
            pagos_348LC = bllPago_348LC.Listar_348LC();
            MostrarPagos_348LC();
        }

        private void MostrarPagos_348LC()
        {
            string dni_348LC = txtFiltroDNI.Text.Trim();
            string estado_348LC = cmbFiltroEstado.SelectedIndex > 0 ? cmbFiltroEstado.SelectedItem.ToString() : null;

            dgvPagos.DataSource = pagos_348LC
                .Where(p_348LC => dni_348LC == "" || (p_348LC.DNI ?? "").Contains(dni_348LC))
                .Where(p_348LC => estado_348LC == null || p_348LC.Estado == estado_348LC)
                .ToList();

            dgvPagos.Columns["IdMatricula"].Visible = false;
            dgvPagos.Columns["Eliminado"].Visible = false;
            dgvPagos.Columns["DVH"].Visible = false;
            dgvPagos.Columns["MarcaTarjeta"].Visible = false;
            dgvPagos.Columns["UltimosDigitos"].Visible = false;
            dgvPagos.Columns["BancoOrigen"].Visible = false;

            string[] orden_348LC = { "Id", "DNI", "Nombre", "Apellido", "NombreClase", "Monto", "MedioPago", "FechaPago", "Estado" };
            for (int i_348LC = 0; i_348LC < orden_348LC.Length; i_348LC++)
                dgvPagos.Columns[orden_348LC[i_348LC]].DisplayIndex = i_348LC;

            TitularColumnas_348LC();

            dgvPagos.Columns["Monto"].DefaultCellStyle.Format = "$ #,##0.00";
            dgvPagos.Columns["FechaPago"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvPagos.Rows.Count == 0)
            {
                participanteSeleccionado_348LC = null;
                lblParticipante.Text = pagos_348LC.Count == 0
                    ? Texto_348LC("msgSinPagos", "No hay pagos registrados.")
                    : Texto_348LC("msgSinPagosFiltro", "No hay pagos que coincidan con el filtro.");
                nudMonto.Value = 0;
                HabilitarEdicion_348LC(false);
            }
        }

        private void TitularColumnas_348LC()
        {
            if (dgvPagos.DataSource == null)
                return;

            dgvPagos.Columns["Id"].HeaderText = "N°";
            dgvPagos.Columns["DNI"].HeaderText = Texto_348LC("colDNI", "DNI");
            dgvPagos.Columns["Nombre"].HeaderText = Texto_348LC("colNombre", "Nombre");
            dgvPagos.Columns["Apellido"].HeaderText = Texto_348LC("colApellido", "Apellido");
            dgvPagos.Columns["NombreClase"].HeaderText = Texto_348LC("colClase", "Clase");
            dgvPagos.Columns["Monto"].HeaderText = Texto_348LC("colMonto", "Monto");
            dgvPagos.Columns["MedioPago"].HeaderText = Texto_348LC("colMedioPago", "Medio de pago");
            dgvPagos.Columns["FechaPago"].HeaderText = Texto_348LC("colFechaPago", "Fecha de pago");
            dgvPagos.Columns["Estado"].HeaderText = Texto_348LC("colEstado", "Estado");
        }

        private void HabilitarEdicion_348LC(bool habilitar_348LC)
        {
            cmbMedioPago.Enabled = habilitar_348LC;
            dtpFechaPago.Enabled = habilitar_348LC;
            btnRegistrarPago.Enabled = habilitar_348LC;
            btnCancelarPago.Enabled = habilitar_348LC;
            cmbMarcaTarjeta.Enabled = habilitar_348LC;
            txtUltimosDigitos.Enabled = habilitar_348LC;
            cmbBancoOrigen.Enabled = habilitar_348LC;
        }

        private void dgvPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
                return;

            Pago pago_348LC = (Pago)dgvPagos.CurrentRow.DataBoundItem;
            bool pendiente_348LC = pago_348LC.Estado == BLL_Pago.ESTADO_PENDIENTE;

            nudMonto.Value = pago_348LC.Monto;
            dtpFechaPago.Value = pago_348LC.FechaPago ?? DateTime.Today;
            cmbMedioPago.SelectedItem = pendiente_348LC ? null : pago_348LC.MedioPago;
            cmbMarcaTarjeta.SelectedItem = pendiente_348LC ? null : pago_348LC.MarcaTarjeta;
            txtUltimosDigitos.Text = pendiente_348LC ? "" : pago_348LC.UltimosDigitos ?? "";
            cmbBancoOrigen.Text = pendiente_348LC ? "" : pago_348LC.BancoOrigen ?? "";
            MostrarDetalleMedioPago_348LC();
            HabilitarEdicion_348LC(pendiente_348LC);

            Matricula matricula_348LC = bllMatricula_348LC.ObtenerPorId_348LC(pago_348LC.IdMatricula);
            participanteSeleccionado_348LC = matricula_348LC == null ? null : bllParticipante_348LC.ObtenerPorId_348LC(matricula_348LC.IdParticipante);
            lblParticipante.Text = participanteSeleccionado_348LC == null ? "" :
                $"{Texto_348LC("colDNI", "DNI")}: {participanteSeleccionado_348LC.DNI}   {participanteSeleccionado_348LC.Nombre} {participanteSeleccionado_348LC.Apellido}   " +
                $"{Texto_348LC("colDireccion", "Dirección")}: {participanteSeleccionado_348LC.Direccion}";
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un pago pendiente de la grilla.");
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show("Se cancelará el pago y se dará de baja la inscripción del participante. ¿Continuar?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            try
            {
                Pago pago_348LC = (Pago)dgvPagos.CurrentRow.DataBoundItem;

                bllPago_348LC.Cancelar_348LC(pago_348LC.Id);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Clases",
                    Descripcion = "Pago cancelado",
                    Fecha = DateTime.Now,
                    Criticidad = 4
                });

                CargarPagos_348LC();
                MessageBox.Show("Pago cancelado. La inscripción se dio de baja y se liberó el lugar en la clase.");
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un pago pendiente de la grilla.");
                return;
            }

            Pago pagoSeleccionado_348LC = (Pago)dgvPagos.CurrentRow.DataBoundItem;
            string ruta_348LC;

            Pago pago_348LC = new Pago
            {
                Id = pagoSeleccionado_348LC.Id,
                MedioPago = cmbMedioPago.SelectedItem == null ? "" : cmbMedioPago.SelectedItem.ToString(),
                MarcaTarjeta = cmbMarcaTarjeta.SelectedItem == null ? "" : cmbMarcaTarjeta.SelectedItem.ToString(),
                UltimosDigitos = txtUltimosDigitos.Text,
                BancoOrigen = cmbBancoOrigen.Text,
                FechaPago = dtpFechaPago.Value.Date
            };

            try
            {
                bllPago_348LC.ValidarRegistro_348LC(pago_348LC, participanteSeleccionado_348LC);
            }
            catch (Exception exValidacion_348LC)
            {
                MessageBox.Show(exValidacion_348LC.Message);
                return;
            }

            DialogResult confirmacion_348LC = MessageBox.Show(
                $"¿Registrar el pago de ${pago_348LC.Monto:N2} en {BLL_Pago.ObtenerDetalleMedioPago_348LC(pago_348LC)} para {participanteSeleccionado_348LC.Nombre} {participanteSeleccionado_348LC.Apellido}?",
                "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion_348LC != DialogResult.Yes)
                return;

            using (SaveFileDialog guardar_348LC = new SaveFileDialog())
            {
                string carpeta_348LC = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Oasis Sports", "Comprobantes");
                Directory.CreateDirectory(carpeta_348LC);

                guardar_348LC.Title = "Guardar comprobante de pago";
                guardar_348LC.Filter = "Archivo PDF (*.pdf)|*.pdf";
                guardar_348LC.DefaultExt = "pdf";
                guardar_348LC.InitialDirectory = carpeta_348LC;
                guardar_348LC.FileName = $"Comprobante_{pagoSeleccionado_348LC.Id:D8}.pdf";

                if (guardar_348LC.ShowDialog() != DialogResult.OK)
                    return;

                ruta_348LC = guardar_348LC.FileName;
            }

            try
            {
                bllPago_348LC.Registrar_348LC(pago_348LC, participanteSeleccionado_348LC);

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Clases",
                    Descripcion = "Pago registrado",
                    Fecha = DateTime.Now,
                    Criticidad = 4
                });

                CargarPagos_348LC();

                try
                {
                    GenerarPdfComprobante_348LC(pago_348LC, bllPago_348LC.GenerarComprobante_348LC(pago_348LC, participanteSeleccionado_348LC), ruta_348LC);
                    MessageBox.Show("Pago registrado. Comprobante guardado en:\n" + ruta_348LC);
                }
                catch (Exception exPdf_348LC)
                {
                    MessageBox.Show("El pago se registró, pero no se pudo generar el comprobante en PDF: " + exPdf_348LC.Message);
                }
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }

        private void GenerarPdfComprobante_348LC(Pago pago_348LC, string comprobante_348LC, string ruta_348LC)
        {
            if (File.Exists(ruta_348LC))
                File.Delete(ruta_348LC);

            using (PrintDocument documento_348LC = new PrintDocument())
            {
                documento_348LC.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                if (!documento_348LC.PrinterSettings.IsValid)
                    throw new Exception("No está instalada la impresora \"Microsoft Print to PDF\".");

                documento_348LC.PrinterSettings.PrintToFile = true;
                documento_348LC.PrinterSettings.PrintFileName = ruta_348LC;
                documento_348LC.DocumentName = $"Comprobante {pago_348LC.Id:D8}";
                documento_348LC.PrintController = new StandardPrintController();

                documento_348LC.PrintPage += (s_348LC, ev_348LC) =>
                {
                    Graphics g_348LC = ev_348LC.Graphics;
                    Rectangle margen_348LC = ev_348LC.MarginBounds;
                    float y_348LC = margen_348LC.Top;

                    using (Font titulo_348LC = new Font("Times New Roman", 22, FontStyle.Bold))
                    using (Font subtitulo_348LC = new Font("Times New Roman", 14, FontStyle.Italic))
                    using (Font texto_348LC = new Font("Times New Roman", 12))
                    {
                        g_348LC.DrawString("OASIS SPORTS", titulo_348LC, Brushes.Black, margen_348LC.Left, y_348LC);
                        y_348LC += titulo_348LC.GetHeight(g_348LC);

                        g_348LC.DrawString("Comprobante de pago - Clases de fútbol", subtitulo_348LC, Brushes.Black, margen_348LC.Left, y_348LC);
                        y_348LC += subtitulo_348LC.GetHeight(g_348LC) + 10;

                        g_348LC.DrawLine(Pens.Black, margen_348LC.Left, y_348LC, margen_348LC.Right, y_348LC);
                        y_348LC += 20;

                        g_348LC.DrawString(comprobante_348LC, texto_348LC, Brushes.Black,
                            new RectangleF(margen_348LC.Left, y_348LC, margen_348LC.Width, margen_348LC.Bottom - y_348LC));
                    }

                    ev_348LC.HasMorePages = false;
                };

                documento_348LC.Print();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }
    }
}
