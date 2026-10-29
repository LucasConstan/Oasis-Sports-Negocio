namespace Oasis_Sports
{
    partial class FrmCrearClase
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
            lblNombreClase = new Label();
            txtNombreClase = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblDuracion = new Label();
            nudDuracion = new NumericUpDown();
            lblCupoMaximo = new Label();
            nudCupoMaximo = new NumericUpDown();
            btnBuscarDisponibilidad = new Button();
            lblCancha = new Label();
            cmbCancha = new ComboBox();
            lblCostoClase = new Label();
            nudCostoClase = new NumericUpDown();
            lblInicioInscripcion = new Label();
            dtpInicioInscripcion = new DateTimePicker();
            lblFinInscripcion = new Label();
            dtpFinInscripcion = new DateTimePicker();
            btnRegistrarClase = new Button();
            btnVolver = new Button();
            lblProfesores = new Label();
            dgvProfesores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCupoMaximo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCostoClase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).BeginInit();
            SuspendLayout();
            //
            // lblNombreClase
            //
            lblNombreClase.AutoSize = true;
            lblNombreClase.Location = new Point(20, 23);
            lblNombreClase.Name = "lblNombreClase";
            lblNombreClase.Size = new Size(87, 21);
            lblNombreClase.TabIndex = 0;
            lblNombreClase.Text = "NOMBRE";
            //
            // txtNombreClase
            //
            txtNombreClase.Location = new Point(200, 20);
            txtNombreClase.MaxLength = 50;
            txtNombreClase.Name = "txtNombreClase";
            txtNombreClase.Size = new Size(250, 29);
            txtNombreClase.TabIndex = 1;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 63);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(131, 21);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "DESCRIPCIÓN";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(200, 60);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(250, 29);
            txtDescripcion.TabIndex = 3;
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(20, 103);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(71, 21);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "FECHA";
            //
            // dtpFecha
            //
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(200, 100);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 29);
            dtpFecha.TabIndex = 5;
            //
            // lblHoraInicio
            //
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(20, 143);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(141, 21);
            lblHoraInicio.TabIndex = 6;
            lblHoraInicio.Text = "HORA INICIO";
            //
            // dtpHoraInicio
            //
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.Location = new Point(200, 140);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(250, 29);
            dtpHoraInicio.TabIndex = 7;
            //
            // lblDuracion
            //
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(20, 183);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(160, 21);
            lblDuracion.TabIndex = 8;
            lblDuracion.Text = "DURACIÓN (MIN)";
            //
            // nudDuracion
            //
            nudDuracion.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            nudDuracion.Location = new Point(200, 180);
            nudDuracion.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(250, 29);
            nudDuracion.TabIndex = 9;
            nudDuracion.Value = new decimal(new int[] { 60, 0, 0, 0 });
            //
            // lblCupoMaximo
            //
            lblCupoMaximo.AutoSize = true;
            lblCupoMaximo.Location = new Point(20, 223);
            lblCupoMaximo.Name = "lblCupoMaximo";
            lblCupoMaximo.Size = new Size(143, 21);
            lblCupoMaximo.TabIndex = 10;
            lblCupoMaximo.Text = "CUPO MÁXIMO";
            //
            // nudCupoMaximo
            //
            nudCupoMaximo.Location = new Point(200, 220);
            nudCupoMaximo.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCupoMaximo.Name = "nudCupoMaximo";
            nudCupoMaximo.Size = new Size(250, 29);
            nudCupoMaximo.TabIndex = 11;
            nudCupoMaximo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // btnBuscarDisponibilidad
            //
            btnBuscarDisponibilidad.BackColor = Color.White;
            btnBuscarDisponibilidad.Location = new Point(200, 265);
            btnBuscarDisponibilidad.Name = "btnBuscarDisponibilidad";
            btnBuscarDisponibilidad.Size = new Size(250, 42);
            btnBuscarDisponibilidad.TabIndex = 12;
            btnBuscarDisponibilidad.Text = "BUSCAR DISPONIBILIDAD";
            btnBuscarDisponibilidad.UseVisualStyleBackColor = false;
            btnBuscarDisponibilidad.Click += btnBuscarDisponibilidad_Click;
            //
            // lblCancha
            //
            lblCancha.AutoSize = true;
            lblCancha.Location = new Point(480, 23);
            lblCancha.Name = "lblCancha";
            lblCancha.Size = new Size(88, 21);
            lblCancha.TabIndex = 13;
            lblCancha.Text = "CANCHA";
            //
            // cmbCancha
            //
            cmbCancha.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCancha.FormattingEnabled = true;
            cmbCancha.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbCancha.Location = new Point(700, 20);
            cmbCancha.Name = "cmbCancha";
            cmbCancha.Size = new Size(180, 29);
            cmbCancha.TabIndex = 14;
            //
            // lblCostoClase
            //
            lblCostoClase.AutoSize = true;
            lblCostoClase.Location = new Point(480, 63);
            lblCostoClase.Name = "lblCostoClase";
            lblCostoClase.Size = new Size(77, 21);
            lblCostoClase.TabIndex = 15;
            lblCostoClase.Text = "COSTO";
            //
            // nudCostoClase
            //
            nudCostoClase.DecimalPlaces = 2;
            nudCostoClase.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudCostoClase.Location = new Point(700, 60);
            nudCostoClase.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudCostoClase.Name = "nudCostoClase";
            nudCostoClase.Size = new Size(180, 29);
            nudCostoClase.TabIndex = 16;
            nudCostoClase.ThousandsSeparator = true;
            //
            // lblInicioInscripcion
            //
            lblInicioInscripcion.AutoSize = true;
            lblInicioInscripcion.Location = new Point(480, 103);
            lblInicioInscripcion.Name = "lblInicioInscripcion";
            lblInicioInscripcion.Size = new Size(201, 21);
            lblInicioInscripcion.TabIndex = 17;
            lblInicioInscripcion.Text = "INICIO INSCRIPCIÓN";
            //
            // dtpInicioInscripcion
            //
            dtpInicioInscripcion.Format = DateTimePickerFormat.Short;
            dtpInicioInscripcion.Location = new Point(700, 100);
            dtpInicioInscripcion.Name = "dtpInicioInscripcion";
            dtpInicioInscripcion.Size = new Size(180, 29);
            dtpInicioInscripcion.TabIndex = 18;
            //
            // lblFinInscripcion
            //
            lblFinInscripcion.AutoSize = true;
            lblFinInscripcion.Location = new Point(480, 143);
            lblFinInscripcion.Name = "lblFinInscripcion";
            lblFinInscripcion.Size = new Size(178, 21);
            lblFinInscripcion.TabIndex = 19;
            lblFinInscripcion.Text = "FIN INSCRIPCIÓN";
            //
            // dtpFinInscripcion
            //
            dtpFinInscripcion.Format = DateTimePickerFormat.Short;
            dtpFinInscripcion.Location = new Point(700, 140);
            dtpFinInscripcion.Name = "dtpFinInscripcion";
            dtpFinInscripcion.Size = new Size(180, 29);
            dtpFinInscripcion.TabIndex = 20;
            //
            // btnRegistrarClase
            //
            btnRegistrarClase.BackColor = Color.White;
            btnRegistrarClase.Location = new Point(700, 265);
            btnRegistrarClase.Name = "btnRegistrarClase";
            btnRegistrarClase.Size = new Size(180, 42);
            btnRegistrarClase.TabIndex = 21;
            btnRegistrarClase.Text = "REGISTRAR CLASE";
            btnRegistrarClase.UseVisualStyleBackColor = false;
            btnRegistrarClase.Click += btnRegistrarClase_Click;
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.Location = new Point(480, 265);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 42);
            btnVolver.TabIndex = 22;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // lblProfesores
            //
            lblProfesores.AutoSize = true;
            lblProfesores.Location = new Point(20, 325);
            lblProfesores.Name = "lblProfesores";
            lblProfesores.Size = new Size(260, 21);
            lblProfesores.TabIndex = 23;
            lblProfesores.Text = "PROFESORES DISPONIBLES";
            //
            // dgvProfesores
            //
            dgvProfesores.AllowUserToAddRows = false;
            dgvProfesores.AllowUserToDeleteRows = false;
            dgvProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesores.Location = new Point(20, 355);
            dgvProfesores.MultiSelect = false;
            dgvProfesores.Name = "dgvProfesores";
            dgvProfesores.ReadOnly = true;
            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.Size = new Size(860, 290);
            dgvProfesores.TabIndex = 24;
            //
            // FrmCrearClase
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 665);
            Controls.Add(dgvProfesores);
            Controls.Add(lblProfesores);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarClase);
            Controls.Add(dtpFinInscripcion);
            Controls.Add(lblFinInscripcion);
            Controls.Add(dtpInicioInscripcion);
            Controls.Add(lblInicioInscripcion);
            Controls.Add(nudCostoClase);
            Controls.Add(lblCostoClase);
            Controls.Add(cmbCancha);
            Controls.Add(lblCancha);
            Controls.Add(btnBuscarDisponibilidad);
            Controls.Add(nudCupoMaximo);
            Controls.Add(lblCupoMaximo);
            Controls.Add(nudDuracion);
            Controls.Add(lblDuracion);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombreClase);
            Controls.Add(lblNombreClase);
            Name = "FrmCrearClase";
            Text = "FrmCrearClase";
            Load += FrmCrearClase_Load;
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCupoMaximo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCostoClase).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreClase;
        private TextBox txtNombreClase;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblDuracion;
        private NumericUpDown nudDuracion;
        private Label lblCupoMaximo;
        private NumericUpDown nudCupoMaximo;
        private Button btnBuscarDisponibilidad;
        private Label lblCancha;
        private ComboBox cmbCancha;
        private Label lblCostoClase;
        private NumericUpDown nudCostoClase;
        private Label lblInicioInscripcion;
        private DateTimePicker dtpInicioInscripcion;
        private Label lblFinInscripcion;
        private DateTimePicker dtpFinInscripcion;
        private Button btnRegistrarClase;
        private Button btnVolver;
        private Label lblProfesores;
        private DataGridView dgvProfesores;
    }
}
