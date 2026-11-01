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
            lblPerfilUsuario = new Label();
            cmbUsuarios = new ComboBox();
            lblUsuarios = new Label();
            btnAsignarPerfil = new Button();
            btnQuitarPerfil = new Button();
            lstPerfiles = new ListBox();
            lblPerfiles = new Label();
            btnVolver = new Button();
            btnCrearGP = new Button();
            SuspendLayout();
            //
            // treeView1
            //
            treeView1.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            treeView1.Location = new Point(316, 53);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(510, 492);
            treeView1.TabIndex = 0;
            //
            // lblPerfilUsuario
            //
            lblPerfilUsuario.AutoSize = true;
            lblPerfilUsuario.Location = new Point(316, 18);
            lblPerfilUsuario.Name = "lblPerfilUsuario";
            lblPerfilUsuario.Size = new Size(189, 21);
            lblPerfilUsuario.TabIndex = 1;
            lblPerfilUsuario.Text = "PERFIL DEL USUARIO";
            //
            // cmbUsuarios
            //
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(34, 77);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(258, 29);
            cmbUsuarios.TabIndex = 2;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
            //
            // lblUsuarios
            //
            lblUsuarios.AutoSize = true;
            lblUsuarios.Location = new Point(34, 53);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(76, 21);
            lblUsuarios.TabIndex = 3;
            lblUsuarios.Text = "Usuarios";
            //
            // lblPerfiles
            //
            lblPerfiles.AutoSize = true;
            lblPerfiles.Location = new Point(34, 115);
            lblPerfiles.Name = "lblPerfiles";
            lblPerfiles.Size = new Size(166, 21);
            lblPerfiles.TabIndex = 9;
            lblPerfiles.Text = "Perfiles disponibles";
            //
            // lstPerfiles
            //
            lstPerfiles.FormattingEnabled = true;
            lstPerfiles.ItemHeight = 21;
            lstPerfiles.Location = new Point(34, 140);
            lstPerfiles.Name = "lstPerfiles";
            lstPerfiles.Size = new Size(258, 172);
            lstPerfiles.TabIndex = 6;
            //
            // btnAsignarPerfil
            //
            btnAsignarPerfil.Location = new Point(32, 330);
            btnAsignarPerfil.Name = "btnAsignarPerfil";
            btnAsignarPerfil.Size = new Size(260, 43);
            btnAsignarPerfil.TabIndex = 4;
            btnAsignarPerfil.Text = "ASIGNAR PERFIL";
            btnAsignarPerfil.UseVisualStyleBackColor = true;
            btnAsignarPerfil.Click += btnAgregar_Click;
            //
            // btnQuitarPerfil
            //
            btnQuitarPerfil.Location = new Point(32, 379);
            btnQuitarPerfil.Name = "btnQuitarPerfil";
            btnQuitarPerfil.Size = new Size(260, 43);
            btnQuitarPerfil.TabIndex = 5;
            btnQuitarPerfil.Text = "QUITAR PERFIL";
            btnQuitarPerfil.UseVisualStyleBackColor = true;
            btnQuitarPerfil.Click += btnQuitar_Click;
            //
            // btnVolver
            //
            btnVolver.Location = new Point(32, 502);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(260, 43);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += button1_Click;
            //
            // btnCrearGP
            //
            btnCrearGP.Location = new Point(32, 437);
            btnCrearGP.Name = "btnCrearGP";
            btnCrearGP.Size = new Size(260, 54);
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
            Controls.Add(lblPerfiles);
            Controls.Add(lstPerfiles);
            Controls.Add(btnQuitarPerfil);
            Controls.Add(btnAsignarPerfil);
            Controls.Add(lblUsuarios);
            Controls.Add(cmbUsuarios);
            Controls.Add(lblPerfilUsuario);
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
        private Label lblPerfilUsuario;
        private ComboBox cmbUsuarios;
        private Label lblUsuarios;
        private Button btnAsignarPerfil;
        private Button btnQuitarPerfil;
        private ListBox lstPerfiles;
        private Label lblPerfiles;
        private Button btnVolver;
        private Button btnCrearGP;
    }
}
