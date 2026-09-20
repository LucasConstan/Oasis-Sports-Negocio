namespace Oasis_Sports
{
    partial class FrmOrganizarPartidos
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
            cmbEquipoLocal = new ComboBox();
            cmbEquipoVisitante = new ComboBox();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            nudCancha = new NumericUpDown();
            btnProgramar = new Button();
            dgvFixture = new DataGridView();
            groupBox1 = new GroupBox();
            lblLocal = new Label();
            groupBox2 = new GroupBox();
            lblVisitante = new Label();
            btnVolver = new Button();
            lblTorneo = new Label();
            lblFecha = new Label();
            lblCancha = new Label();
            lblHora = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCancha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFixture).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbTorneo
            // 
            cmbTorneo.FormattingEnabled = true;
            cmbTorneo.Location = new Point(119, 30);
            cmbTorneo.Name = "cmbTorneo";
            cmbTorneo.Size = new Size(189, 29);
            cmbTorneo.TabIndex = 0;
            cmbTorneo.SelectedIndexChanged += cmbTorneo_SelectedIndexChanged;
            // 
            // cmbEquipoLocal
            // 
            cmbEquipoLocal.FormattingEnabled = true;
            cmbEquipoLocal.Location = new Point(25, 61);
            cmbEquipoLocal.Name = "cmbEquipoLocal";
            cmbEquipoLocal.Size = new Size(212, 29);
            cmbEquipoLocal.TabIndex = 1;
            // 
            // cmbEquipoVisitante
            // 
            cmbEquipoVisitante.FormattingEnabled = true;
            cmbEquipoVisitante.Location = new Point(18, 61);
            cmbEquipoVisitante.Name = "cmbEquipoVisitante";
            cmbEquipoVisitante.Size = new Size(241, 29);
            cmbEquipoVisitante.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(119, 73);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(189, 29);
            dtpFecha.TabIndex = 3;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(566, 74);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(212, 29);
            dtpHora.TabIndex = 4;
            // 
            // nudCancha
            // 
            nudCancha.Location = new Point(566, 32);
            nudCancha.Name = "nudCancha";
            nudCancha.Size = new Size(212, 29);
            nudCancha.TabIndex = 5;
            // 
            // btnProgramar
            // 
            btnProgramar.Location = new Point(312, 145);
            btnProgramar.Name = "btnProgramar";
            btnProgramar.Size = new Size(165, 48);
            btnProgramar.TabIndex = 6;
            btnProgramar.Text = "PROGRAMAR";
            btnProgramar.UseVisualStyleBackColor = true;
            btnProgramar.Click += btnProgramar_Click;
            // 
            // dgvFixture
            // 
            dgvFixture.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFixture.Location = new Point(71, 325);
            dgvFixture.Name = "dgvFixture";
            dgvFixture.Size = new Size(644, 305);
            dgvFixture.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblLocal);
            groupBox1.Controls.Add(cmbEquipoLocal);
            groupBox1.Location = new Point(28, 127);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 142);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Location = new Point(6, 18);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(72, 21);
            lblLocal.TabIndex = 2;
            lblLocal.Text = "LOCAL";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblVisitante);
            groupBox2.Controls.Add(cmbEquipoVisitante);
            groupBox2.Location = new Point(500, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(278, 142);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            // 
            // lblVisitante
            // 
            lblVisitante.AutoSize = true;
            lblVisitante.Location = new Point(6, 18);
            lblVisitante.Name = "lblVisitante";
            lblVisitante.Size = new Size(105, 21);
            lblVisitante.TabIndex = 3;
            lblVisitante.Text = "VISITANTE";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(312, 221);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(165, 48);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTorneo
            // 
            lblTorneo.AutoSize = true;
            lblTorneo.Location = new Point(26, 34);
            lblTorneo.Name = "lblTorneo";
            lblTorneo.Size = new Size(87, 21);
            lblTorneo.TabIndex = 3;
            lblTorneo.Text = "TORNEO";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(26, 79);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(71, 21);
            lblFecha.TabIndex = 11;
            lblFecha.Text = "FECHA";
            // 
            // lblCancha
            // 
            lblCancha.AutoSize = true;
            lblCancha.Location = new Point(472, 34);
            lblCancha.Name = "lblCancha";
            lblCancha.Size = new Size(88, 21);
            lblCancha.TabIndex = 12;
            lblCancha.Text = "CANCHA";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(488, 82);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(63, 21);
            lblHora.TabIndex = 13;
            lblHora.Text = "HORA";
            // 
            // FrmOrganizarPartidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 658);
            Controls.Add(lblHora);
            Controls.Add(lblCancha);
            Controls.Add(lblFecha);
            Controls.Add(lblTorneo);
            Controls.Add(btnVolver);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvFixture);
            Controls.Add(btnProgramar);
            Controls.Add(nudCancha);
            Controls.Add(dtpHora);
            Controls.Add(dtpFecha);
            Controls.Add(cmbTorneo);
            Name = "FrmOrganizarPartidos";
            Text = "FrmOrganizarPartidos";
            Load += FrmOrganizarPartidos_Load;
            ((System.ComponentModel.ISupportInitialize)nudCancha).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFixture).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTorneo;
        private ComboBox cmbEquipoLocal;
        private ComboBox cmbEquipoVisitante;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private NumericUpDown nudCancha;
        private Button btnProgramar;
        private DataGridView dgvFixture;
        private GroupBox groupBox1;
        private Label lblLocal;
        private GroupBox groupBox2;
        private Label lblVisitante;
        private Button btnVolver;
        private Label lblTorneo;
        private Label lblFecha;
        private Label lblCancha;
        private Label lblHora;
    }
}