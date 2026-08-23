namespace Oasis_Sports
{
    partial class FrmBitacora
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
            dgvBitacora = new DataGridView();
            txtUsuario = new TextBox();
            cmbCriticidad = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            lblBitacora = new Label();
            lblUsuario = new Label();
            lblDesde = new Label();
            lblHasta = new Label();
            lblCriticidad = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            SuspendLayout();
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.BackgroundColor = Color.DarkGreen;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(316, 12);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.Size = new Size(708, 504);
            dgvBitacora.TabIndex = 0;
            dgvBitacora.CellContentClick += dgvBitacora_CellContentClick;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(133, 76);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(157, 29);
            txtUsuario.TabIndex = 1;
            // 
            // cmbCriticidad
            // 
            cmbCriticidad.FormattingEnabled = true;
            cmbCriticidad.Location = new Point(133, 110);
            cmbCriticidad.Name = "cmbCriticidad";
            cmbCriticidad.Size = new Size(157, 29);
            cmbCriticidad.TabIndex = 2;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(133, 145);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(157, 29);
            dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(133, 180);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(157, 29);
            dtpHasta.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(53, 239);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(186, 32);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += button1_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(53, 279);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(186, 32);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += button2_Click;
            // 
            // lblBitacora
            // 
            lblBitacora.AutoSize = true;
            lblBitacora.Location = new Point(53, 33);
            lblBitacora.Name = "lblBitacora";
            lblBitacora.Size = new Size(157, 21);
            lblBitacora.TabIndex = 7;
            lblBitacora.Text = "Bitacora de eventos";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 84);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(68, 21);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 145);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(57, 21);
            lblDesde.TabIndex = 9;
            lblDesde.Text = "Desde";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(14, 183);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(52, 21);
            lblHasta.TabIndex = 10;
            lblHasta.Text = "Hasta";
            // 
            // lblCriticidad
            // 
            lblCriticidad.AutoSize = true;
            lblCriticidad.Location = new Point(12, 114);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(83, 21);
            lblCriticidad.TabIndex = 11;
            lblCriticidad.Text = "Criticidad";
            lblCriticidad.Click += label5_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(53, 320);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(186, 32);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += button3_Click;
            // 
            // FrmBitacora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 537);
            Controls.Add(btnVolver);
            Controls.Add(lblCriticidad);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(lblUsuario);
            Controls.Add(lblBitacora);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(cmbCriticidad);
            Controls.Add(txtUsuario);
            Controls.Add(dgvBitacora);
            Name = "FrmBitacora";
            Text = "FrmBitacora";
            FormClosing += FrmBitacora_FormClosing;
            Load += FrmBitacora_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBitacora;
        private TextBox txtUsuario;
        private ComboBox cmbCriticidad;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Label lblBitacora;
        private Label lblUsuario;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblCriticidad;
        private Button btnVolver;
    }
}