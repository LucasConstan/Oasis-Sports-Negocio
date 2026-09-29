namespace Oasis_Sports
{
    partial class FrmRegistrarResultado
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
            cmbTorneo = new ComboBox();
            nudGolesLocal = new NumericUpDown();
            nudGolesVisitante = new NumericUpDown();
            dgvPartidosPendientes = new DataGridView();
            chkSuspendido = new CheckBox();
            btnGuardar = new Button();
            lblTorneo = new Label();
            GolesLocal = new Label();
            GolesVisitante = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)nudGolesLocal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGolesVisitante).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidosPendientes).BeginInit();
            SuspendLayout();
            // 
            // cmbTorneo
            // 
            cmbTorneo.FormattingEnabled = true;
            cmbTorneo.Location = new Point(130, 26);
            cmbTorneo.Name = "cmbTorneo";
            cmbTorneo.Size = new Size(147, 29);
            cmbTorneo.TabIndex = 0;
            cmbTorneo.SelectedIndexChanged += cmbTorneo_SelectedIndexChanged;
            // 
            // nudGolesLocal
            // 
            nudGolesLocal.Location = new Point(481, 26);
            nudGolesLocal.Name = "nudGolesLocal";
            nudGolesLocal.Size = new Size(117, 29);
            nudGolesLocal.TabIndex = 1;
            // 
            // nudGolesVisitante
            // 
            nudGolesVisitante.Location = new Point(481, 79);
            nudGolesVisitante.Name = "nudGolesVisitante";
            nudGolesVisitante.Size = new Size(120, 29);
            nudGolesVisitante.TabIndex = 2;
            // 
            // dgvPartidosPendientes
            // 
            dgvPartidosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidosPendientes.Location = new Point(32, 132);
            dgvPartidosPendientes.Name = "dgvPartidosPendientes";
            dgvPartidosPendientes.ReadOnly = true;
            dgvPartidosPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidosPendientes.Size = new Size(590, 313);
            dgvPartidosPendientes.TabIndex = 3;
            dgvPartidosPendientes.SelectionChanged += dgvPartidosPendientes_SelectionChanged;
            // 
            // chkSuspendido
            // 
            chkSuspendido.AutoSize = true;
            chkSuspendido.Location = new Point(647, 132);
            chkSuspendido.Name = "chkSuspendido";
            chkSuspendido.Size = new Size(118, 25);
            chkSuspendido.TabIndex = 4;
            chkSuspendido.Text = "Suspendido";
            chkSuspendido.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(650, 347);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 38);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // lblTorneo
            // 
            lblTorneo.AutoSize = true;
            lblTorneo.Location = new Point(60, 29);
            lblTorneo.Name = "lblTorneo";
            lblTorneo.Size = new Size(64, 21);
            lblTorneo.TabIndex = 6;
            lblTorneo.Text = "Torneo";
            // 
            // GolesLocal
            // 
            GolesLocal.AutoSize = true;
            GolesLocal.Location = new Point(354, 29);
            GolesLocal.Name = "GolesLocal";
            GolesLocal.Size = new Size(121, 21);
            GolesLocal.TabIndex = 7;
            GolesLocal.Text = "Goles del local";
            // 
            // GolesVisitante
            // 
            GolesVisitante.AutoSize = true;
            GolesVisitante.Location = new Point(329, 81);
            GolesVisitante.Name = "GolesVisitante";
            GolesVisitante.Size = new Size(146, 21);
            GolesVisitante.TabIndex = 8;
            GolesVisitante.Text = "Goles del visitante";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(650, 407);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(131, 38);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(GolesVisitante);
            Controls.Add(GolesLocal);
            Controls.Add(lblTorneo);
            Controls.Add(btnGuardar);
            Controls.Add(chkSuspendido);
            Controls.Add(dgvPartidosPendientes);
            Controls.Add(nudGolesVisitante);
            Controls.Add(nudGolesLocal);
            Controls.Add(cmbTorneo);
            Name = "FrmRegistrarResultado";
            Text = "FrmRegistrarResultado";
            Load += FrmRegistrarResultado_Load;
            ((System.ComponentModel.ISupportInitialize)nudGolesLocal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGolesVisitante).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidosPendientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTorneo;
        private NumericUpDown nudGolesLocal;
        private NumericUpDown nudGolesVisitante;
        private DataGridView dgvPartidosPendientes;
        private CheckBox chkSuspendido;
        private Button btnGuardar;
        private Label lblTorneo;
        private Label GolesLocal;
        private Label GolesVisitante;
        private Button btnVolver;
    }
}