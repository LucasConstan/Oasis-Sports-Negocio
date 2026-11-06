namespace Oasis_Sports
{
    partial class FrmRegistrarPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPagos = new Label();
            dgvPagos = new DataGridView();
            lblParticipante = new Label();
            lblMonto = new Label();
            nudMonto = new NumericUpDown();
            lblFechaPago = new Label();
            dtpFechaPago = new DateTimePicker();
            lblMedioPago = new Label();
            cmbMedioPago = new ComboBox();
            btnRegistrarPago = new Button();
            btnCancelarPago = new Button();
            btnVolver = new Button();
            lblFiltroDNI = new Label();
            txtFiltroDNI = new TextBox();
            lblFiltroEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            lblMarcaTarjeta = new Label();
            cmbMarcaTarjeta = new ComboBox();
            lblUltimosDigitos = new Label();
            txtUltimosDigitos = new TextBox();
            lblBancoOrigen = new Label();
            cmbBancoOrigen = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            //
            // lblPagos
            //
            lblPagos.AutoSize = true;
            lblPagos.Location = new Point(20, 15);
            lblPagos.ForeColor = Color.DarkGreen;
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(68, 21);
            lblPagos.TabIndex = 0;
            lblPagos.Text = "PAGOS";
            //
            // dgvPagos
            //
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(20, 45);
            dgvPagos.MultiSelect = false;
            dgvPagos.BackgroundColor = Color.White;
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(860, 280);
            dgvPagos.TabIndex = 1;
            dgvPagos.SelectionChanged += dgvPagos_SelectionChanged;
            //
            // lblParticipante
            //
            lblParticipante.Location = new Point(20, 340);
            lblParticipante.ForeColor = Color.DarkGreen;
            lblParticipante.Name = "lblParticipante";
            lblParticipante.Size = new Size(860, 30);
            lblParticipante.TabIndex = 2;
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(20, 388);
            lblMonto.ForeColor = Color.DarkGreen;
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(76, 21);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "MONTO";
            //
            // nudMonto
            //
            nudMonto.DecimalPlaces = 2;
            nudMonto.Enabled = false;
            nudMonto.Location = new Point(200, 385);
            nudMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudMonto.ThousandsSeparator = true;
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(200, 29);
            nudMonto.TabIndex = 4;
            nudMonto.ThousandsSeparator = true;
            //
            // lblFechaPago
            //
            lblFechaPago.AutoSize = true;
            lblFechaPago.Location = new Point(440, 388);
            lblFechaPago.ForeColor = Color.DarkGreen;
            lblFechaPago.Name = "lblFechaPago";
            lblFechaPago.Size = new Size(141, 21);
            lblFechaPago.TabIndex = 5;
            lblFechaPago.Text = "FECHA PAGO";
            //
            // dtpFechaPago
            //
            dtpFechaPago.Format = DateTimePickerFormat.Short;
            dtpFechaPago.Location = new Point(640, 385);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(240, 29);
            dtpFechaPago.TabIndex = 6;
            //
            // lblMedioPago
            //
            lblMedioPago.AutoSize = true;
            lblMedioPago.Location = new Point(20, 433);
            lblMedioPago.ForeColor = Color.DarkGreen;
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(158, 21);
            lblMedioPago.TabIndex = 7;
            lblMedioPago.Text = "MEDIO DE PAGO";
            //
            // cmbMedioPago
            //
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(200, 430);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(200, 29);
            cmbMedioPago.TabIndex = 8;
            //
            // btnRegistrarPago
            //
            btnRegistrarPago.BackColor = Color.White;
            btnRegistrarPago.Location = new Point(200, 535);
            btnRegistrarPago.ForeColor = Color.DarkGreen;
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(200, 42);
            btnRegistrarPago.TabIndex = 9;
            btnRegistrarPago.Text = "REGISTRAR PAGO";
            btnRegistrarPago.UseVisualStyleBackColor = false;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            //
            // btnCancelarPago
            //
            btnCancelarPago.BackColor = Color.White;
            btnCancelarPago.Location = new Point(420, 535);
            btnCancelarPago.ForeColor = Color.DarkGreen;
            btnCancelarPago.Name = "btnCancelarPago";
            btnCancelarPago.Size = new Size(200, 42);
            btnCancelarPago.TabIndex = 10;
            btnCancelarPago.Text = "CANCELAR PAGO";
            btnCancelarPago.UseVisualStyleBackColor = false;
            btnCancelarPago.Click += btnCancelarPago_Click;
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.Location = new Point(640, 535);
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(240, 42);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // lblFiltroDNI
            //
            lblFiltroDNI.AutoSize = true;
            lblFiltroDNI.ForeColor = Color.DarkGreen;
            lblFiltroDNI.Location = new Point(300, 15);
            lblFiltroDNI.Name = "lblFiltroDNI";
            lblFiltroDNI.Size = new Size(42, 21);
            lblFiltroDNI.TabIndex = 12;
            lblFiltroDNI.Text = "DNI";
            //
            // txtFiltroDNI
            //
            txtFiltroDNI.Location = new Point(360, 10);
            txtFiltroDNI.MaxLength = 8;
            txtFiltroDNI.Name = "txtFiltroDNI";
            txtFiltroDNI.Size = new Size(150, 29);
            txtFiltroDNI.TabIndex = 13;
            //
            // lblFiltroEstado
            //
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.ForeColor = Color.DarkGreen;
            lblFiltroEstado.Location = new Point(540, 15);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(83, 21);
            lblFiltroEstado.TabIndex = 14;
            lblFiltroEstado.Text = "ESTADO";
            //
            // cmbFiltroEstado
            //
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(640, 10);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(240, 29);
            cmbFiltroEstado.TabIndex = 15;
            //
            // lblMarcaTarjeta
            //
            lblMarcaTarjeta.AutoSize = true;
            lblMarcaTarjeta.ForeColor = Color.DarkGreen;
            lblMarcaTarjeta.Location = new Point(440, 433);
            lblMarcaTarjeta.Name = "lblMarcaTarjeta";
            lblMarcaTarjeta.Size = new Size(171, 21);
            lblMarcaTarjeta.TabIndex = 16;
            lblMarcaTarjeta.Text = "MARCA TARJETA";
            lblMarcaTarjeta.Visible = false;
            //
            // cmbMarcaTarjeta
            //
            cmbMarcaTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarcaTarjeta.FormattingEnabled = true;
            cmbMarcaTarjeta.Location = new Point(640, 430);
            cmbMarcaTarjeta.Name = "cmbMarcaTarjeta";
            cmbMarcaTarjeta.Size = new Size(240, 29);
            cmbMarcaTarjeta.TabIndex = 17;
            cmbMarcaTarjeta.Visible = false;
            //
            // lblUltimosDigitos
            //
            lblUltimosDigitos.AutoSize = true;
            lblUltimosDigitos.ForeColor = Color.DarkGreen;
            lblUltimosDigitos.Location = new Point(440, 478);
            lblUltimosDigitos.Name = "lblUltimosDigitos";
            lblUltimosDigitos.Size = new Size(190, 21);
            lblUltimosDigitos.TabIndex = 18;
            lblUltimosDigitos.Text = "ÚLTIMOS 4 DÍGITOS";
            lblUltimosDigitos.Visible = false;
            //
            // txtUltimosDigitos
            //
            txtUltimosDigitos.Location = new Point(640, 475);
            txtUltimosDigitos.MaxLength = 4;
            txtUltimosDigitos.Name = "txtUltimosDigitos";
            txtUltimosDigitos.Size = new Size(240, 29);
            txtUltimosDigitos.TabIndex = 19;
            txtUltimosDigitos.Visible = false;
            //
            // lblBancoOrigen
            //
            lblBancoOrigen.AutoSize = true;
            lblBancoOrigen.ForeColor = Color.DarkGreen;
            lblBancoOrigen.Location = new Point(440, 433);
            lblBancoOrigen.Name = "lblBancoOrigen";
            lblBancoOrigen.Size = new Size(190, 21);
            lblBancoOrigen.TabIndex = 20;
            lblBancoOrigen.Text = "BANCO / BILLETERA";
            lblBancoOrigen.Visible = false;
            //
            // cmbBancoOrigen
            //
            cmbBancoOrigen.FormattingEnabled = true;
            cmbBancoOrigen.Location = new Point(640, 430);
            cmbBancoOrigen.MaxLength = 50;
            cmbBancoOrigen.Name = "cmbBancoOrigen";
            cmbBancoOrigen.Size = new Size(240, 29);
            cmbBancoOrigen.TabIndex = 21;
            cmbBancoOrigen.Visible = false;
            //
            // FrmRegistrarPago
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(cmbBancoOrigen);
            Controls.Add(lblBancoOrigen);
            Controls.Add(txtUltimosDigitos);
            Controls.Add(lblUltimosDigitos);
            Controls.Add(cmbMarcaTarjeta);
            Controls.Add(lblMarcaTarjeta);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblFiltroEstado);
            Controls.Add(txtFiltroDNI);
            Controls.Add(lblFiltroDNI);
            Controls.Add(btnVolver);
            Controls.Add(btnCancelarPago);
            Controls.Add(btnRegistrarPago);
            Controls.Add(cmbMedioPago);
            Controls.Add(lblMedioPago);
            Controls.Add(dtpFechaPago);
            Controls.Add(lblFechaPago);
            Controls.Add(nudMonto);
            Controls.Add(lblMonto);
            Controls.Add(lblParticipante);
            Controls.Add(dgvPagos);
            Controls.Add(lblPagos);
            Name = "FrmRegistrarPago";
            Text = "FrmRegistrarPago";
            Load += FrmRegistrarPago_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPagos;
        private DataGridView dgvPagos;
        private Label lblParticipante;
        private Label lblMonto;
        private NumericUpDown nudMonto;
        private Label lblFechaPago;
        private DateTimePicker dtpFechaPago;
        private Label lblMedioPago;
        private ComboBox cmbMedioPago;
        private Button btnRegistrarPago;
        private Button btnCancelarPago;
        private Button btnVolver;
        private Label lblFiltroDNI;
        private TextBox txtFiltroDNI;
        private Label lblFiltroEstado;
        private ComboBox cmbFiltroEstado;
        private Label lblMarcaTarjeta;
        private ComboBox cmbMarcaTarjeta;
        private Label lblUltimosDigitos;
        private TextBox txtUltimosDigitos;
        private Label lblBancoOrigen;
        private ComboBox cmbBancoOrigen;
    }
}
