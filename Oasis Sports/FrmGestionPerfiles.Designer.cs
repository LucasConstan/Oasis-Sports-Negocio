namespace Oasis_Sports
{
    partial class FrmGestionPerfiles
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
            treeView1 = new TreeView();
            lblPermisosActivos = new Label();
            cmbUsuarios = new ComboBox();
            lblUsuario = new Label();
            btnAgregar = new Button();
            btnQuitar = new Button();
            lstDisponibles = new ListBox();
            btnVolver = new Button();
            btnCrearGP = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(316, 53);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(510, 492);
            treeView1.TabIndex = 0;
            // 
            // lblPermisosActivos
            // 
            lblPermisosActivos.AutoSize = true;
            lblPermisosActivos.Location = new Point(316, 18);
            lblPermisosActivos.Name = "lblPermisosActivos";
            lblPermisosActivos.Size = new Size(189, 21);
            lblPermisosActivos.TabIndex = 1;
            lblPermisosActivos.Text = "PERMISOS ACTIVOS";
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(34, 77);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(195, 29);
            cmbUsuarios.TabIndex = 2;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(34, 53);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(76, 21);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuarios";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(32, 330);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(192, 43);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(32, 379);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(192, 43);
            btnQuitar.TabIndex = 5;
            btnQuitar.Text = "QUITAR";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // lstDisponibles
            // 
            lstDisponibles.FormattingEnabled = true;
            lstDisponibles.ItemHeight = 21;
            lstDisponibles.Location = new Point(32, 130);
            lstDisponibles.Name = "lstDisponibles";
            lstDisponibles.Size = new Size(197, 172);
            lstDisponibles.TabIndex = 6;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(32, 502);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(192, 43);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += button1_Click;
            // 
            // btnCrearGP
            // 
            btnCrearGP.Location = new Point(32, 437);
            btnCrearGP.Name = "btnCrearGP";
            btnCrearGP.Size = new Size(192, 54);
            btnCrearGP.TabIndex = 8;
            btnCrearGP.Text = "GRUPO DE PERMISOS";
            btnCrearGP.UseVisualStyleBackColor = true;
            btnCrearGP.Click += button1_Click_1;
            // 
            // FrmGestionPerfiles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 609);
            Controls.Add(btnCrearGP);
            Controls.Add(btnVolver);
            Controls.Add(lstDisponibles);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(lblUsuario);
            Controls.Add(cmbUsuarios);
            Controls.Add(lblPermisosActivos);
            Controls.Add(treeView1);
            Name = "FrmGestionPerfiles";
            Text = "FrmGestionPerfiles";
            FormClosing += FrmGestionPerfiles_FormClosing;
            Load += FrmGestionPerfiles_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label lblPermisosActivos;
        private ComboBox cmbUsuarios;
        private Label lblUsuario;
        private Button btnAgregar;
        private Button btnQuitar;
        private ListBox lstDisponibles;
        private Button btnVolver;
        private Button btnCrearGP;
    }
}