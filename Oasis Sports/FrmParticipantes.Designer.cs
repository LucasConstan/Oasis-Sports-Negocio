namespace Oasis_Sports
{
    partial class FrmParticipantes
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAñadir = new Button();
            txtDNI = new TextBox();
            lblDNI = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            nudEdad = new NumericUpDown();
            lblEdad = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            dgvParticipantes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvParticipantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            SuspendLayout();
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(12, 595);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(209, 35);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // btnEliminar
            //
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(12, 502);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(12, 461);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // btnAñadir
            //
            btnAñadir.BackColor = Color.White;
            btnAñadir.ForeColor = Color.DarkGreen;
            btnAñadir.Location = new Point(12, 420);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(209, 35);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "AÑADIR";
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += btnAñadir_Click;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.DarkGreen;
            lblNombre.Location = new Point(10, 13);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(89, 21);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "NOMBRE";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(12, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(209, 29);
            txtNombre.TabIndex = 1;
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = Color.DarkGreen;
            lblApellido.Location = new Point(10, 80);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 21);
            lblApellido.TabIndex = 12;
            lblApellido.Text = "APELLIDO";
            //
            // txtApellido
            //
            txtApellido.Location = new Point(12, 102);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(209, 29);
            txtApellido.TabIndex = 2;
            //
            // lblDNI
            //
            lblDNI.AutoSize = true;
            lblDNI.ForeColor = Color.DarkGreen;
            lblDNI.Location = new Point(10, 146);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(42, 21);
            lblDNI.TabIndex = 13;
            lblDNI.Text = "DNI";
            //
            // txtDNI
            //
            txtDNI.Location = new Point(12, 168);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(209, 29);
            txtDNI.TabIndex = 3;
            //
            // lblEdad
            //
            lblEdad.AutoSize = true;
            lblEdad.ForeColor = Color.DarkGreen;
            lblEdad.Location = new Point(10, 212);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(60, 21);
            lblEdad.TabIndex = 14;
            lblEdad.Text = "EDAD";
            //
            // nudEdad
            //
            nudEdad.Location = new Point(12, 234);
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(209, 29);
            nudEdad.TabIndex = 4;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.DarkGreen;
            lblTelefono.Location = new Point(10, 278);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(108, 21);
            lblTelefono.TabIndex = 15;
            lblTelefono.Text = "TELEFONO";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(12, 300);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(209, 29);
            txtTelefono.TabIndex = 5;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.ForeColor = Color.DarkGreen;
            lblDireccion.Location = new Point(10, 344);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(113, 21);
            lblDireccion.TabIndex = 16;
            lblDireccion.Text = "DIRECCION";
            //
            // txtDireccion
            //
            txtDireccion.Location = new Point(12, 366);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(209, 29);
            txtDireccion.TabIndex = 6;
            //
            // dgvParticipantes
            //
            dgvParticipantes.BackgroundColor = Color.White;
            dgvParticipantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipantes.Location = new Point(293, 13);
            dgvParticipantes.MultiSelect = false;
            dgvParticipantes.Name = "dgvParticipantes";
            dgvParticipantes.ReadOnly = true;
            dgvParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipantes.Size = new Size(577, 617);
            dgvParticipantes.TabIndex = 0;
            dgvParticipantes.SelectionChanged += dgvParticipantes_SelectionChanged;
            //
            // FrmParticipantes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 645);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(nudEdad);
            Controls.Add(lblEdad);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(txtDNI);
            Controls.Add(lblDNI);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(dgvParticipantes);
            Name = "FrmParticipantes";
            Text = "FrmParticipantes";
            Load += FrmParticipantes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvParticipantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAñadir;
        private TextBox txtDNI;
        private Label lblDNI;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private NumericUpDown nudEdad;
        private Label lblEdad;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private DataGridView dgvParticipantes;
    }
}
