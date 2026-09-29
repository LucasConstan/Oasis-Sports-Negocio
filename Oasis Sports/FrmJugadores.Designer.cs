namespace Oasis_Sports
{
    partial class FrmJugadores
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
            btnVolver = new Button();
            lblEdad = new Label();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAñadir = new Button();
            txtDNI = new TextBox();
            lblDNI = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            dgvJugadores = new DataGridView();
            txtPosicion = new TextBox();
            lblPosicion = new Label();
            lblNumero = new Label();
            cmbEquipo = new ComboBox();
            label1 = new Label();
            nudNumero = new NumericUpDown();
            nudEdad = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(16, 633);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(209, 35);
            btnVolver.TabIndex = 35;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.ForeColor = Color.DarkGreen;
            lblEdad.Location = new Point(8, 217);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(60, 21);
            lblEdad.TabIndex = 33;
            lblEdad.Text = "EDAD";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(16, 582);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(14, 544);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.TabIndex = 31;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.BackColor = Color.White;
            btnAñadir.ForeColor = Color.DarkGreen;
            btnAñadir.Location = new Point(16, 503);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(209, 35);
            btnAñadir.TabIndex = 30;
            btnAñadir.Text = "AÑADIR";
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += btnAñadir_Click_1;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(10, 168);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(211, 29);
            txtDNI.TabIndex = 29;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.ForeColor = Color.DarkGreen;
            lblDNI.Location = new Point(8, 146);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(42, 21);
            lblDNI.TabIndex = 28;
            lblDNI.Text = "DNI";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(12, 102);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(209, 29);
            txtApellido.TabIndex = 27;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = Color.DarkGreen;
            lblApellido.Location = new Point(10, 80);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 21);
            lblApellido.TabIndex = 26;
            lblApellido.Text = "APELLIDO";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(209, 29);
            txtNombre.TabIndex = 25;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.DarkGreen;
            lblNombre.Location = new Point(10, 13);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(89, 21);
            lblNombre.TabIndex = 24;
            lblNombre.Text = "NOMBRE";
            // 
            // dgvJugadores
            // 
            dgvJugadores.BackgroundColor = Color.White;
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(293, 13);
            dgvJugadores.MultiSelect = false;
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.ReadOnly = true;
            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJugadores.Size = new Size(577, 617);
            dgvJugadores.TabIndex = 23;
            dgvJugadores.SelectionChanged += dgvJugadores_SelectionChanged;
            // 
            // txtPosicion
            // 
            txtPosicion.Location = new Point(10, 306);
            txtPosicion.Name = "txtPosicion";
            txtPosicion.Size = new Size(211, 29);
            txtPosicion.TabIndex = 37;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.ForeColor = Color.DarkGreen;
            lblPosicion.Location = new Point(8, 284);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(98, 21);
            lblPosicion.TabIndex = 36;
            lblPosicion.Text = "POSICION";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.ForeColor = Color.DarkGreen;
            lblNumero.Location = new Point(12, 355);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(90, 21);
            lblNumero.TabIndex = 38;
            lblNumero.Text = "NUMERO";
            // 
            // cmbEquipo
            // 
            cmbEquipo.FormattingEnabled = true;
            cmbEquipo.Location = new Point(14, 450);
            cmbEquipo.Name = "cmbEquipo";
            cmbEquipo.Size = new Size(205, 29);
            cmbEquipo.TabIndex = 40;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(14, 426);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 41;
            label1.Text = "EQUIPO";
            // 
            // nudNumero
            // 
            nudNumero.Location = new Point(12, 386);
            nudNumero.Name = "nudNumero";
            nudNumero.Size = new Size(207, 29);
            nudNumero.TabIndex = 42;
            // 
            // nudEdad
            // 
            nudEdad.Location = new Point(12, 246);
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(209, 29);
            nudEdad.TabIndex = 43;
            // 
            // FrmJugadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 684);
            Controls.Add(nudEdad);
            Controls.Add(nudNumero);
            Controls.Add(label1);
            Controls.Add(cmbEquipo);
            Controls.Add(lblNumero);
            Controls.Add(txtPosicion);
            Controls.Add(lblPosicion);
            Controls.Add(btnVolver);
            Controls.Add(lblEdad);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(txtDNI);
            Controls.Add(lblDNI);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(dgvJugadores);
            Name = "FrmJugadores";
            Text = "FrmJugadores";
            Load += FrmJugadores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumero).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Label lblEdad;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAñadir;
        private TextBox txtDNI;
        private Label lblDNI;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private DataGridView dgvJugadores;
        private TextBox txtPosicion;
        private Label lblPosicion;
        private Label lblNumero;
        private ComboBox cmbEquipo;
        private Label label1;
        private NumericUpDown nudNumero;
        private NumericUpDown nudEdad;
    }
}