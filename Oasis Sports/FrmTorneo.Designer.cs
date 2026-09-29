namespace Oasis_Sports
{
    partial class FrmTorneo
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
            dgvTorneos = new DataGridView();
            txtNombreTorneo = new TextBox();
            lblNombre = new Label();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            nudCantidadMaximaEquipos = new NumericUpDown();
            lblCantMax = new Label();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTorneos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMaximaEquipos).BeginInit();
            SuspendLayout();
            // 
            // dgvTorneos
            // 
            dgvTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTorneos.Location = new Point(422, 53);
            dgvTorneos.Name = "dgvTorneos";
            dgvTorneos.ReadOnly = true;
            dgvTorneos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTorneos.Size = new Size(435, 449);
            dgvTorneos.TabIndex = 0;
            dgvTorneos.SelectionChanged += dgvTorneos_SelectionChanged;
            // 
            // txtNombreTorneo
            // 
            txtNombreTorneo.Location = new Point(177, 50);
            txtNombreTorneo.Name = "txtNombreTorneo";
            txtNombreTorneo.Size = new Size(197, 29);
            txtNombreTorneo.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(5, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(5, 112);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 21);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(177, 104);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(197, 29);
            txtDescripcion.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(5, 168);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(81, 21);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "FUTBOL 7", "FUTBOL 5", "FUTBOL 11" });
            cmbCategoria.Location = new Point(177, 160);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(197, 29);
            cmbCategoria.TabIndex = 7;
            cmbCategoria.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(177, 218);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(197, 29);
            dtpFechaInicio.TabIndex = 8;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(5, 224);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(123, 21);
            lblFechaInicio.TabIndex = 9;
            lblFechaInicio.Text = "Fecha de inicio";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(5, 271);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(166, 21);
            lblFechaFin.TabIndex = 11;
            lblFechaFin.Text = "Fecha de finalizacion";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(177, 268);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(197, 29);
            dtpFechaFin.TabIndex = 10;
            // 
            // nudCantidadMaximaEquipos
            // 
            nudCantidadMaximaEquipos.Location = new Point(237, 322);
            nudCantidadMaximaEquipos.Name = "nudCantidadMaximaEquipos";
            nudCantidadMaximaEquipos.Size = new Size(137, 29);
            nudCantidadMaximaEquipos.TabIndex = 12;
            // 
            // lblCantMax
            // 
            lblCantMax.AutoSize = true;
            lblCantMax.Location = new Point(5, 324);
            lblCantMax.Name = "lblCantMax";
            lblCantMax.Size = new Size(226, 21);
            lblCantMax.TabIndex = 13;
            lblCantMax.Text = "Cantidad maxima de equipos";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(18, 387);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(169, 46);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(205, 387);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(169, 46);
            btnModificar.TabIndex = 15;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(18, 456);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(169, 46);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(205, 456);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(169, 46);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmTorneo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 547);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(lblCantMax);
            Controls.Add(nudCantidadMaximaEquipos);
            Controls.Add(lblFechaFin);
            Controls.Add(dtpFechaFin);
            Controls.Add(lblFechaInicio);
            Controls.Add(dtpFechaInicio);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(txtNombreTorneo);
            Controls.Add(dgvTorneos);
            Name = "FrmTorneo";
            Text = "FrmTorneo";
            Load += FrmTorneo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTorneos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMaximaEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTorneos;
        private TextBox txtNombreTorneo;
        private Label lblNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private NumericUpDown nudCantidadMaximaEquipos;
        private Label lblCantMax;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnVolver;
    }
}