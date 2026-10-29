namespace Oasis_Sports
{
    partial class FrmProfesores
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
            txtEspecialidad = new TextBox();
            lblEspecialidad = new Label();
            dgvProfesores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).BeginInit();
            SuspendLayout();
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
            // btnEliminar
            //
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(12, 375);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(12, 334);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // btnAñadir
            //
            btnAñadir.BackColor = Color.White;
            btnAñadir.ForeColor = Color.DarkGreen;
            btnAñadir.Location = new Point(12, 293);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(209, 35);
            btnAñadir.TabIndex = 5;
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
            lblNombre.TabIndex = 9;
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
            lblApellido.TabIndex = 10;
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
            lblDNI.TabIndex = 11;
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
            // lblEspecialidad
            //
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.ForeColor = Color.DarkGreen;
            lblEspecialidad.Location = new Point(10, 212);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(147, 21);
            lblEspecialidad.TabIndex = 12;
            lblEspecialidad.Text = "ESPECIALIDAD";
            //
            // txtEspecialidad
            //
            txtEspecialidad.Location = new Point(12, 234);
            txtEspecialidad.MaxLength = 50;
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(209, 29);
            txtEspecialidad.TabIndex = 4;
            //
            // dgvProfesores
            //
            dgvProfesores.BackgroundColor = Color.White;
            dgvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesores.Location = new Point(293, 13);
            dgvProfesores.MultiSelect = false;
            dgvProfesores.Name = "dgvProfesores";
            dgvProfesores.ReadOnly = true;
            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.Size = new Size(577, 617);
            dgvProfesores.TabIndex = 0;
            dgvProfesores.SelectionChanged += dgvProfesores_SelectionChanged;
            //
            // FrmProfesores
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 645);
            Controls.Add(txtEspecialidad);
            Controls.Add(lblEspecialidad);
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
            Controls.Add(dgvProfesores);
            Name = "FrmProfesores";
            Text = "FrmProfesores";
            Load += FrmProfesores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).EndInit();
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
        private TextBox txtEspecialidad;
        private Label lblEspecialidad;
        private DataGridView dgvProfesores;
    }
}
