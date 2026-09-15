namespace Oasis_Sports
{
    partial class FrmEquipos
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAñadir = new Button();
            txtColorPrincipal = new TextBox();
            lblColorPrincipal = new Label();
            txtNombreResponsable = new TextBox();
            lblNombreResponsable = new Label();
            txtNombreEquipo = new TextBox();
            lblNombreEquipo = new Label();
            dgvEquipos = new DataGridView();
            txtColorSecundario = new TextBox();
            lblColorSecundario = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(14, 398);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(14, 344);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.TabIndex = 18;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.BackColor = Color.White;
            btnAñadir.ForeColor = Color.DarkGreen;
            btnAñadir.Location = new Point(14, 288);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(209, 35);
            btnAñadir.TabIndex = 17;
            btnAñadir.Text = "AÑADIR";
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // txtColorPrincipal
            // 
            txtColorPrincipal.Location = new Point(12, 164);
            txtColorPrincipal.Name = "txtColorPrincipal";
            txtColorPrincipal.Size = new Size(211, 29);
            txtColorPrincipal.TabIndex = 16;
            // 
            // lblColorPrincipal
            // 
            lblColorPrincipal.AutoSize = true;
            lblColorPrincipal.ForeColor = Color.DarkGreen;
            lblColorPrincipal.Location = new Point(10, 142);
            lblColorPrincipal.Name = "lblColorPrincipal";
            lblColorPrincipal.Size = new Size(179, 21);
            lblColorPrincipal.TabIndex = 15;
            lblColorPrincipal.Text = "COLOR PRINCIPAL:";
            // 
            // txtNombreResponsable
            // 
            txtNombreResponsable.Location = new Point(14, 98);
            txtNombreResponsable.Name = "txtNombreResponsable";
            txtNombreResponsable.Size = new Size(209, 29);
            txtNombreResponsable.TabIndex = 14;
            // 
            // lblNombreResponsable
            // 
            lblNombreResponsable.AutoSize = true;
            lblNombreResponsable.ForeColor = Color.DarkGreen;
            lblNombreResponsable.Location = new Point(12, 76);
            lblNombreResponsable.Name = "lblNombreResponsable";
            lblNombreResponsable.Size = new Size(273, 21);
            lblNombreResponsable.TabIndex = 13;
            lblNombreResponsable.Text = "NOMBRE DEL RESPONSABLE: ";
            // 
            // txtNombreEquipo
            // 
            txtNombreEquipo.Location = new Point(14, 31);
            txtNombreEquipo.Name = "txtNombreEquipo";
            txtNombreEquipo.Size = new Size(209, 29);
            txtNombreEquipo.TabIndex = 12;
            // 
            // lblNombreEquipo
            // 
            lblNombreEquipo.AutoSize = true;
            lblNombreEquipo.ForeColor = Color.DarkGreen;
            lblNombreEquipo.Location = new Point(12, 9);
            lblNombreEquipo.Name = "lblNombreEquipo";
            lblNombreEquipo.Size = new Size(89, 21);
            lblNombreEquipo.TabIndex = 11;
            lblNombreEquipo.Text = "NOMBRE";
            // 
            // dgvEquipos
            // 
            dgvEquipos.BackgroundColor = Color.White;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(295, 9);
            dgvEquipos.MultiSelect = false;
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.Size = new Size(577, 482);
            dgvEquipos.TabIndex = 10;
            dgvEquipos.SelectionChanged += dgvEquipos_SelectionChanged;
            // 
            // txtColorSecundario
            // 
            txtColorSecundario.Location = new Point(12, 235);
            txtColorSecundario.Name = "txtColorSecundario";
            txtColorSecundario.Size = new Size(211, 29);
            txtColorSecundario.TabIndex = 21;
            // 
            // lblColorSecundario
            // 
            lblColorSecundario.AutoSize = true;
            lblColorSecundario.ForeColor = Color.DarkGreen;
            lblColorSecundario.Location = new Point(10, 213);
            lblColorSecundario.Name = "lblColorSecundario";
            lblColorSecundario.Size = new Size(204, 21);
            lblColorSecundario.TabIndex = 20;
            lblColorSecundario.Text = "COLOR SECUNDARIO:";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(14, 449);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(209, 35);
            btnVolver.TabIndex = 22;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmEquipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 489);
            Controls.Add(btnVolver);
            Controls.Add(txtColorSecundario);
            Controls.Add(lblColorSecundario);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(txtColorPrincipal);
            Controls.Add(lblColorPrincipal);
            Controls.Add(txtNombreResponsable);
            Controls.Add(lblNombreResponsable);
            Controls.Add(txtNombreEquipo);
            Controls.Add(lblNombreEquipo);
            Controls.Add(dgvEquipos);
            Name = "FrmEquipos";
            Text = "FrmEquipos";
            Load += FrmEquipos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAñadir;
        private TextBox txtColorPrincipal;
        private Label lblColorPrincipal;
        private TextBox txtNombreResponsable;
        private Label lblNombreResponsable;
        private TextBox txtNombreEquipo;
        private Label lblNombreEquipo;
        private DataGridView dgvEquipos;
        private TextBox txtColorSecundario;
        private Label lblColorSecundario;
        private Button btnVolver;
    }
}