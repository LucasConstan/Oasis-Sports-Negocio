namespace Oasis_Sports
{
    partial class FrmInscribirParticipante
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
            lblClase = new Label();
            cmbClase = new ComboBox();
            lblDatosClase = new Label();
            lblParticipantes = new Label();
            dgvParticipantes = new DataGridView();
            btnInscribir = new Button();
            btnDesinscribir = new Button();
            btnRegistrarParticipante = new Button();
            btnVolver = new Button();
            lblMatriculados = new Label();
            dgvMatriculados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvParticipantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMatriculados).BeginInit();
            SuspendLayout();
            //
            // lblClase
            //
            lblClase.AutoSize = true;
            lblClase.Location = new Point(20, 23);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(68, 21);
            lblClase.TabIndex = 0;
            lblClase.Text = "CLASE";
            //
            // cmbClase
            //
            cmbClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClase.FormattingEnabled = true;
            cmbClase.Location = new Point(160, 20);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(400, 29);
            cmbClase.TabIndex = 1;
            cmbClase.SelectedIndexChanged += cmbClase_SelectedIndexChanged;
            //
            // lblDatosClase
            //
            lblDatosClase.Location = new Point(20, 60);
            lblDatosClase.Name = "lblDatosClase";
            lblDatosClase.Size = new Size(860, 60);
            lblDatosClase.TabIndex = 2;
            //
            // lblParticipantes
            //
            lblParticipantes.AutoSize = true;
            lblParticipantes.Location = new Point(20, 130);
            lblParticipantes.Name = "lblParticipantes";
            lblParticipantes.Size = new Size(290, 21);
            lblParticipantes.TabIndex = 3;
            lblParticipantes.Text = "PARTICIPANTES DISPONIBLES";
            //
            // dgvParticipantes
            //
            dgvParticipantes.AllowUserToAddRows = false;
            dgvParticipantes.AllowUserToDeleteRows = false;
            dgvParticipantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParticipantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipantes.Location = new Point(20, 160);
            dgvParticipantes.MultiSelect = false;
            dgvParticipantes.Name = "dgvParticipantes";
            dgvParticipantes.ReadOnly = true;
            dgvParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipantes.Size = new Size(860, 200);
            dgvParticipantes.TabIndex = 4;
            //
            // btnInscribir
            //
            btnInscribir.BackColor = Color.White;
            btnInscribir.Location = new Point(20, 375);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(180, 42);
            btnInscribir.TabIndex = 5;
            btnInscribir.Text = "INSCRIBIR";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            //
            // btnDesinscribir
            //
            btnDesinscribir.BackColor = Color.White;
            btnDesinscribir.Location = new Point(210, 375);
            btnDesinscribir.Name = "btnDesinscribir";
            btnDesinscribir.Size = new Size(180, 42);
            btnDesinscribir.TabIndex = 10;
            btnDesinscribir.Text = "DESINSCRIBIR";
            btnDesinscribir.UseVisualStyleBackColor = false;
            btnDesinscribir.Click += btnDesinscribir_Click;
            //
            // btnRegistrarParticipante
            //
            btnRegistrarParticipante.BackColor = Color.White;
            btnRegistrarParticipante.Location = new Point(400, 375);
            btnRegistrarParticipante.Name = "btnRegistrarParticipante";
            btnRegistrarParticipante.Size = new Size(280, 42);
            btnRegistrarParticipante.TabIndex = 6;
            btnRegistrarParticipante.Text = "REGISTRAR PARTICIPANTE";
            btnRegistrarParticipante.UseVisualStyleBackColor = false;
            btnRegistrarParticipante.Click += btnRegistrarParticipante_Click;
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.Location = new Point(700, 375);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 42);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // lblMatriculados
            //
            lblMatriculados.AutoSize = true;
            lblMatriculados.Location = new Point(20, 435);
            lblMatriculados.Name = "lblMatriculados";
            lblMatriculados.Size = new Size(140, 21);
            lblMatriculados.TabIndex = 8;
            lblMatriculados.Text = "INSCRIPTOS";
            //
            // dgvMatriculados
            //
            dgvMatriculados.AllowUserToAddRows = false;
            dgvMatriculados.AllowUserToDeleteRows = false;
            dgvMatriculados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriculados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriculados.Location = new Point(20, 465);
            dgvMatriculados.MultiSelect = false;
            dgvMatriculados.Name = "dgvMatriculados";
            dgvMatriculados.ReadOnly = true;
            dgvMatriculados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriculados.Size = new Size(860, 200);
            dgvMatriculados.TabIndex = 9;
            //
            // FrmInscribirParticipante
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 685);
            Controls.Add(dgvMatriculados);
            Controls.Add(lblMatriculados);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarParticipante);
            Controls.Add(btnDesinscribir);
            Controls.Add(btnInscribir);
            Controls.Add(dgvParticipantes);
            Controls.Add(lblParticipantes);
            Controls.Add(lblDatosClase);
            Controls.Add(cmbClase);
            Controls.Add(lblClase);
            Name = "FrmInscribirParticipante";
            Text = "FrmInscribirParticipante";
            Load += FrmInscribirParticipante_Load;
            ((System.ComponentModel.ISupportInitialize)dgvParticipantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMatriculados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClase;
        private ComboBox cmbClase;
        private Label lblDatosClase;
        private Label lblParticipantes;
        private DataGridView dgvParticipantes;
        private Button btnInscribir;
        private Button btnDesinscribir;
        private Button btnRegistrarParticipante;
        private Button btnVolver;
        private Label lblMatriculados;
        private DataGridView dgvMatriculados;
    }
}
