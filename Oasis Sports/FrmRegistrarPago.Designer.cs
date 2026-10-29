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
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            //
            // lblPagos
            //
            lblPagos.AutoSize = true;
            lblPagos.Location = new Point(20, 15);
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
            lblParticipante.Name = "lblParticipante";
            lblParticipante.Size = new Size(860, 30);
            lblParticipante.TabIndex = 2;
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(20, 388);
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
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(200, 29);
            nudMonto.TabIndex = 4;
            nudMonto.ThousandsSeparator = true;
            //
            // lblFechaPago
            //
            lblFechaPago.AutoSize = true;
            lblFechaPago.Location = new Point(440, 388);
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
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(158, 21);
            lblMedioPago.TabIndex = 7;
            lblMedioPago.Text = "MEDIO DE PAGO";
            //
            // cmbMedioPago
            //
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de débito", "Tarjeta de crédito", "Transferencia" });
            cmbMedioPago.Location = new Point(200, 430);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(200, 29);
            cmbMedioPago.TabIndex = 8;
            //
            // btnRegistrarPago
            //
            btnRegistrarPago.BackColor = Color.White;
            btnRegistrarPago.Location = new Point(200, 485);
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
            btnCancelarPago.Location = new Point(420, 485);
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
            btnVolver.Location = new Point(640, 485);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(240, 42);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // FrmRegistrarPago
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
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
    }
}
