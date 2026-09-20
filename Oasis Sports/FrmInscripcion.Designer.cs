namespace Oasis_Sports
{
    partial class FrmInscripcion
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
            lblTorneo = new Label();
            lblEquipos = new Label();
            cmbEquipoExistente = new ComboBox();
            dgvJugadoresEquipo = new DataGridView();
            dgvEquiposInscriptos = new DataGridView();
            btnAgregarEquipo = new Button();
            btnQuitarEquipo = new Button();
            btnQuitarJugador = new Button();
            btnAgregarJugador = new Button();
            lblJugadores = new Label();
            cmbJugadorExistente = new ComboBox();
            btnVolver = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvJugadoresEquipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposInscriptos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbTorneo
            // 
            cmbTorneo.FormattingEnabled = true;
            cmbTorneo.Location = new Point(88, 42);
            cmbTorneo.Name = "cmbTorneo";
            cmbTorneo.Size = new Size(164, 29);
            cmbTorneo.TabIndex = 0;
            cmbTorneo.SelectedIndexChanged += cmbTorneo_SelectedIndexChanged;
            // 
            // lblTorneo
            // 
            lblTorneo.AutoSize = true;
            lblTorneo.Location = new Point(18, 45);
            lblTorneo.Name = "lblTorneo";
            lblTorneo.Size = new Size(64, 21);
            lblTorneo.TabIndex = 1;
            lblTorneo.Text = "Torneo";
            // 
            // lblEquipos
            // 
            lblEquipos.AutoSize = true;
            lblEquipos.Location = new Point(6, 25);
            lblEquipos.Name = "lblEquipos";
            lblEquipos.Size = new Size(72, 21);
            lblEquipos.TabIndex = 3;
            lblEquipos.Text = "Equipos";
            // 
            // cmbEquipoExistente
            // 
            cmbEquipoExistente.FormattingEnabled = true;
            cmbEquipoExistente.Location = new Point(25, 61);
            cmbEquipoExistente.Name = "cmbEquipoExistente";
            cmbEquipoExistente.Size = new Size(209, 29);
            cmbEquipoExistente.TabIndex = 2;
            // 
            // dgvJugadoresEquipo
            // 
            dgvJugadoresEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadoresEquipo.Location = new Point(323, 28);
            dgvJugadoresEquipo.Name = "dgvJugadoresEquipo";
            dgvJugadoresEquipo.Size = new Size(639, 266);
            dgvJugadoresEquipo.TabIndex = 4;
            dgvJugadoresEquipo.SelectionChanged += dgvJugadoresEquipo_SelectionChanged;
            // 
            // dgvEquiposInscriptos
            // 
            dgvEquiposInscriptos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquiposInscriptos.Location = new Point(323, 25);
            dgvEquiposInscriptos.Name = "dgvEquiposInscriptos";
            dgvEquiposInscriptos.Size = new Size(639, 296);
            dgvEquiposInscriptos.TabIndex = 5;
            dgvEquiposInscriptos.SelectionChanged += dgvEquiposInscriptos_SelectionChanged;
            // 
            // btnAgregarEquipo
            // 
            btnAgregarEquipo.Location = new Point(25, 114);
            btnAgregarEquipo.Name = "btnAgregarEquipo";
            btnAgregarEquipo.Size = new Size(209, 54);
            btnAgregarEquipo.TabIndex = 6;
            btnAgregarEquipo.Text = "AGREGAR EQUIPO";
            btnAgregarEquipo.UseVisualStyleBackColor = true;
            btnAgregarEquipo.Click += btnAgregarEquipo_Click;
            // 
            // btnQuitarEquipo
            // 
            btnQuitarEquipo.Location = new Point(25, 187);
            btnQuitarEquipo.Name = "btnQuitarEquipo";
            btnQuitarEquipo.Size = new Size(209, 53);
            btnQuitarEquipo.TabIndex = 7;
            btnQuitarEquipo.Text = "QUITAR EQUIPO";
            btnQuitarEquipo.UseVisualStyleBackColor = true;
            btnQuitarEquipo.Click += btnQuitarEquipo_Click;
            // 
            // btnQuitarJugador
            // 
            btnQuitarJugador.Location = new Point(25, 197);
            btnQuitarJugador.Name = "btnQuitarJugador";
            btnQuitarJugador.Size = new Size(209, 53);
            btnQuitarJugador.TabIndex = 9;
            btnQuitarJugador.Text = "QUITAR JUGADOR";
            btnQuitarJugador.UseVisualStyleBackColor = true;
            btnQuitarJugador.Click += btnQuitarJugador_Click;
            // 
            // btnAgregarJugador
            // 
            btnAgregarJugador.Location = new Point(25, 121);
            btnAgregarJugador.Name = "btnAgregarJugador";
            btnAgregarJugador.Size = new Size(209, 54);
            btnAgregarJugador.TabIndex = 8;
            btnAgregarJugador.Text = "AGREGAR JUGADOR";
            btnAgregarJugador.UseVisualStyleBackColor = true;
            btnAgregarJugador.Click += btnAgregarJugador_Click;
            // 
            // lblJugadores
            // 
            lblJugadores.AutoSize = true;
            lblJugadores.Location = new Point(6, 25);
            lblJugadores.Name = "lblJugadores";
            lblJugadores.Size = new Size(85, 21);
            lblJugadores.TabIndex = 11;
            lblJugadores.Text = "Jugadores";
            // 
            // cmbJugadorExistente
            // 
            cmbJugadorExistente.FormattingEnabled = true;
            cmbJugadorExistente.Location = new Point(25, 68);
            cmbJugadorExistente.Name = "cmbJugadorExistente";
            cmbJugadorExistente.Size = new Size(209, 29);
            cmbJugadorExistente.TabIndex = 10;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(5, 672);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(150, 42);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvEquiposInscriptos);
            groupBox1.Controls.Add(lblEquipos);
            groupBox1.Controls.Add(cmbEquipoExistente);
            groupBox1.Controls.Add(btnAgregarEquipo);
            groupBox1.Controls.Add(btnQuitarEquipo);
            groupBox1.Location = new Point(276, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1024, 344);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbJugadorExistente);
            groupBox2.Controls.Add(btnAgregarJugador);
            groupBox2.Controls.Add(btnQuitarJugador);
            groupBox2.Controls.Add(dgvJugadoresEquipo);
            groupBox2.Controls.Add(lblJugadores);
            groupBox2.Location = new Point(276, 378);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1024, 336);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            // 
            // FrmInscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 751);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnVolver);
            Controls.Add(lblTorneo);
            Controls.Add(cmbTorneo);
            Name = "FrmInscripcion";
            Text = "FrmInscripcion";
            Load += FrmInscripcion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJugadoresEquipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposInscriptos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTorneo;
        private Label lblTorneo;
        private Label lblEquipos;
        private ComboBox cmbEquipoExistente;
        private DataGridView dgvJugadoresEquipo;
        private DataGridView dgvEquiposInscriptos;
        private Button btnAgregarEquipo;
        private Button btnQuitarEquipo;
        private Button btnQuitarJugador;
        private Button btnAgregarJugador;
        private Label lblJugadores;
        private ComboBox cmbJugadorExistente;
        private Button btnVolver;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}