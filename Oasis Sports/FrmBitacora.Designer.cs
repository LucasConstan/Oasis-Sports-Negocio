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
            cmbModulo = new ComboBox();
            cmbCriticidad = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            lblBitacora = new Label();
            lblUsuario = new Label();
            lblModulo = new Label();
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
            dgvBitacora.AllowUserToDeleteRows = false;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBitacora.BackgroundColor = Color.White;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(293, 13);
            dgvBitacora.MultiSelect = false;
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(731, 617);
            dgvBitacora.TabIndex = 0;
            //
            // lblBitacora
            //
            lblBitacora.AutoSize = true;
            lblBitacora.ForeColor = Color.DarkGreen;
            lblBitacora.Location = new Point(10, 13);
            lblBitacora.Name = "lblBitacora";
            lblBitacora.Size = new Size(229, 21);
            lblBitacora.TabIndex = 13;
            lblBitacora.Text = "BITACORA DE EVENTOS";
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.DarkGreen;
            lblUsuario.Location = new Point(10, 60);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(94, 21);
            lblUsuario.TabIndex = 14;
            lblUsuario.Text = "USUARIO";
            //
            // txtUsuario
            //
            txtUsuario.Location = new Point(12, 82);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(209, 29);
            txtUsuario.TabIndex = 1;
            //
            // lblModulo
            //
            lblModulo.AutoSize = true;
            lblModulo.ForeColor = Color.DarkGreen;
            lblModulo.Location = new Point(10, 126);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(87, 21);
            lblModulo.TabIndex = 15;
            lblModulo.Text = "MODULO";
            //
            // cmbModulo
            //
            cmbModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulo.FormattingEnabled = true;
            cmbModulo.Location = new Point(12, 148);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.Size = new Size(209, 29);
            cmbModulo.TabIndex = 2;
            //
            // lblCriticidad
            //
            lblCriticidad.AutoSize = true;
            lblCriticidad.ForeColor = Color.DarkGreen;
            lblCriticidad.Location = new Point(10, 192);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(118, 21);
            lblCriticidad.TabIndex = 16;
            lblCriticidad.Text = "CRITICIDAD";
            //
            // cmbCriticidad
            //
            cmbCriticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriticidad.FormattingEnabled = true;
            cmbCriticidad.Location = new Point(12, 214);
            cmbCriticidad.Name = "cmbCriticidad";
            cmbCriticidad.Size = new Size(209, 29);
            cmbCriticidad.TabIndex = 3;
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.ForeColor = Color.DarkGreen;
            lblDesde.Location = new Point(10, 258);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(71, 21);
            lblDesde.TabIndex = 17;
            lblDesde.Text = "DESDE";
            //
            // dtpDesde
            //
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(12, 280);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(209, 29);
            dtpDesde.TabIndex = 4;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.ForeColor = Color.DarkGreen;
            lblHasta.Location = new Point(10, 324);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(68, 21);
            lblHasta.TabIndex = 18;
            lblHasta.Text = "HASTA";
            //
            // dtpHasta
            //
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(12, 346);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(209, 29);
            dtpHasta.TabIndex = 5;
            //
            // btnBuscar
            //
            btnBuscar.BackColor = Color.White;
            btnBuscar.ForeColor = Color.DarkGreen;
            btnBuscar.Location = new Point(12, 400);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(209, 35);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.ForeColor = Color.DarkGreen;
            btnLimpiar.Location = new Point(12, 441);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(209, 35);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(12, 595);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(209, 35);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // FrmBitacora
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 645);
            Controls.Add(btnVolver);
            Controls.Add(lblCriticidad);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(lblModulo);
            Controls.Add(lblUsuario);
            Controls.Add(lblBitacora);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(cmbCriticidad);
            Controls.Add(cmbModulo);
            Controls.Add(txtUsuario);
            Controls.Add(dgvBitacora);
            Name = "FrmBitacora";
            Text = "FrmBitacora";
            FormClosing += FrmBitacora_FormClosing;
            Load += FrmBitacora_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBitacora;
        private TextBox txtUsuario;
        private ComboBox cmbModulo;
        private ComboBox cmbCriticidad;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Label lblBitacora;
        private Label lblUsuario;
        private Label lblModulo;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblCriticidad;
        private Button btnVolver;
    }
}
