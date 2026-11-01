namespace Oasis_Sports
{
    partial class FrmGruposPermisos
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
            lblTituloGrupos = new Label();
            lblEstadoGrupo = new Label();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblNombreGrupo = new Label();
            txtNombreGrupo = new TextBox();
            lblAyudaCodigo = new Label();
            grpDisponibles = new GroupBox();
            treePermisosDisponibles = new TreeView();
            grpContenidoGrupo = new GroupBox();
            treePermisosDelGrupo = new TreeView();
            btnAgregarAlGrupo = new Button();
            btnQuitarDelGrupo = new Button();
            lblAyudaDisponibles = new Label();
            lblAyudaContenido = new Label();
            lblLeyendaPerfil = new Label();
            btnEditarGrupo = new Button();
            btnEliminarGrupo = new Button();
            btnNuevoGrupo = new Button();
            btnGuardarGrupo = new Button();
            btnVolver = new Button();
            grpDisponibles.SuspendLayout();
            grpContenidoGrupo.SuspendLayout();
            SuspendLayout();
            //
            // lblTituloGrupos
            //
            lblTituloGrupos.AutoSize = true;
            lblTituloGrupos.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTituloGrupos.Location = new Point(12, 10);
            lblTituloGrupos.Name = "lblTituloGrupos";
            lblTituloGrupos.Size = new Size(230, 25);
            lblTituloGrupos.TabIndex = 0;
            lblTituloGrupos.Text = "GRUPOS DE PERMISOS";
            //
            // lblEstadoGrupo
            //
            lblEstadoGrupo.AutoSize = true;
            lblEstadoGrupo.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblEstadoGrupo.ForeColor = Color.DarkBlue;
            lblEstadoGrupo.Location = new Point(12, 48);
            lblEstadoGrupo.Name = "lblEstadoGrupo";
            lblEstadoGrupo.Size = new Size(0, 21);
            lblEstadoGrupo.TabIndex = 1;
            //
            // lblCodigo
            //
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 88);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(72, 21);
            lblCodigo.TabIndex = 2;
            lblCodigo.Text = "Código: ";
            //
            // txtCodigo
            //
            txtCodigo.CharacterCasing = CharacterCasing.Upper;
            txtCodigo.Location = new Point(95, 85);
            txtCodigo.MaxLength = 5;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(90, 29);
            txtCodigo.TabIndex = 3;
            txtCodigo.TextChanged += txtGrupo_TextChanged;
            //
            // lblNombreGrupo
            //
            lblNombreGrupo.AutoSize = true;
            lblNombreGrupo.Location = new Point(205, 88);
            lblNombreGrupo.Name = "lblNombreGrupo";
            lblNombreGrupo.Size = new Size(76, 21);
            lblNombreGrupo.TabIndex = 4;
            lblNombreGrupo.Text = "Nombre:";
            //
            // txtNombreGrupo
            //
            txtNombreGrupo.Location = new Point(290, 85);
            txtNombreGrupo.MaxLength = 100;
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(400, 29);
            txtNombreGrupo.TabIndex = 5;
            txtNombreGrupo.TextChanged += txtGrupo_TextChanged;
            //
            // lblAyudaCodigo
            //
            lblAyudaCodigo.AutoSize = true;
            lblAyudaCodigo.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblAyudaCodigo.Location = new Point(95, 118);
            lblAyudaCodigo.Name = "lblAyudaCodigo";
            lblAyudaCodigo.Size = new Size(280, 15);
            lblAyudaCodigo.TabIndex = 6;
            lblAyudaCodigo.Text = "El código lleva 2 letras y 3 números (ej.: GE050)";
            //
            // grpDisponibles
            //
            grpDisponibles.Controls.Add(treePermisosDisponibles);
            grpDisponibles.Location = new Point(12, 150);
            grpDisponibles.Name = "grpDisponibles";
            grpDisponibles.Size = new Size(425, 320);
            grpDisponibles.TabIndex = 7;
            grpDisponibles.TabStop = false;
            grpDisponibles.Text = "Grupos y permisos existentes";
            //
            // treePermisosDisponibles
            //
            treePermisosDisponibles.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            treePermisosDisponibles.HideSelection = false;
            treePermisosDisponibles.Location = new Point(10, 28);
            treePermisosDisponibles.Name = "treePermisosDisponibles";
            treePermisosDisponibles.ShowNodeToolTips = true;
            treePermisosDisponibles.Size = new Size(405, 282);
            treePermisosDisponibles.TabIndex = 0;
            treePermisosDisponibles.AfterSelect += treePermisos_AfterSelect;
            treePermisosDisponibles.NodeMouseDoubleClick += treePermisosDisponibles_NodeMouseDoubleClick;
            //
            // grpContenidoGrupo
            //
            grpContenidoGrupo.Controls.Add(treePermisosDelGrupo);
            grpContenidoGrupo.Location = new Point(573, 150);
            grpContenidoGrupo.Name = "grpContenidoGrupo";
            grpContenidoGrupo.Size = new Size(425, 320);
            grpContenidoGrupo.TabIndex = 10;
            grpContenidoGrupo.TabStop = false;
            grpContenidoGrupo.Text = "Contenido del grupo";
            //
            // treePermisosDelGrupo
            //
            treePermisosDelGrupo.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            treePermisosDelGrupo.HideSelection = false;
            treePermisosDelGrupo.Location = new Point(10, 28);
            treePermisosDelGrupo.Name = "treePermisosDelGrupo";
            treePermisosDelGrupo.Size = new Size(405, 282);
            treePermisosDelGrupo.TabIndex = 0;
            treePermisosDelGrupo.AfterSelect += treePermisos_AfterSelect;
            treePermisosDelGrupo.NodeMouseDoubleClick += treePermisosDelGrupo_NodeMouseDoubleClick;
            //
            // btnAgregarAlGrupo
            //
            btnAgregarAlGrupo.Location = new Point(447, 250);
            btnAgregarAlGrupo.Name = "btnAgregarAlGrupo";
            btnAgregarAlGrupo.Size = new Size(116, 40);
            btnAgregarAlGrupo.TabIndex = 8;
            btnAgregarAlGrupo.Text = "Agregar >";
            btnAgregarAlGrupo.UseVisualStyleBackColor = true;
            btnAgregarAlGrupo.Click += btnAgregar_Click;
            //
            // btnQuitarDelGrupo
            //
            btnQuitarDelGrupo.Location = new Point(447, 300);
            btnQuitarDelGrupo.Name = "btnQuitarDelGrupo";
            btnQuitarDelGrupo.Size = new Size(116, 40);
            btnQuitarDelGrupo.TabIndex = 9;
            btnQuitarDelGrupo.Text = "< Quitar";
            btnQuitarDelGrupo.UseVisualStyleBackColor = true;
            btnQuitarDelGrupo.Click += btnQuitar_Click;
            //
            // lblAyudaDisponibles
            //
            lblAyudaDisponibles.AutoSize = true;
            lblAyudaDisponibles.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblAyudaDisponibles.Location = new Point(12, 475);
            lblAyudaDisponibles.Name = "lblAyudaDisponibles";
            lblAyudaDisponibles.Size = new Size(190, 15);
            lblAyudaDisponibles.TabIndex = 11;
            lblAyudaDisponibles.Text = "Doble clic para agregar al grupo";
            //
            // lblLeyendaPerfil
            //
            lblLeyendaPerfil.AutoSize = true;
            lblLeyendaPerfil.Font = new Font("Times New Roman", 10F, FontStyle.Bold | FontStyle.Italic);
            lblLeyendaPerfil.ForeColor = Color.DarkBlue;
            lblLeyendaPerfil.Location = new Point(215, 475);
            lblLeyendaPerfil.Name = "lblLeyendaPerfil";
            lblLeyendaPerfil.Size = new Size(220, 15);
            lblLeyendaPerfil.TabIndex = 18;
            lblLeyendaPerfil.Text = "En azul: grupos asignados como perfil";
            //
            // lblAyudaContenido
            //
            lblAyudaContenido.AutoSize = true;
            lblAyudaContenido.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblAyudaContenido.Location = new Point(573, 475);
            lblAyudaContenido.Name = "lblAyudaContenido";
            lblAyudaContenido.Size = new Size(190, 15);
            lblAyudaContenido.TabIndex = 12;
            lblAyudaContenido.Text = "Doble clic para quitar del grupo";
            //
            // btnEditarGrupo
            //
            btnEditarGrupo.Location = new Point(12, 505);
            btnEditarGrupo.Name = "btnEditarGrupo";
            btnEditarGrupo.Size = new Size(180, 40);
            btnEditarGrupo.TabIndex = 13;
            btnEditarGrupo.Text = "Editar grupo";
            btnEditarGrupo.UseVisualStyleBackColor = true;
            btnEditarGrupo.Click += btnModificar_Click;
            //
            // btnEliminarGrupo
            //
            btnEliminarGrupo.Location = new Point(202, 505);
            btnEliminarGrupo.Name = "btnEliminarGrupo";
            btnEliminarGrupo.Size = new Size(180, 40);
            btnEliminarGrupo.TabIndex = 14;
            btnEliminarGrupo.Text = "Eliminar grupo";
            btnEliminarGrupo.UseVisualStyleBackColor = true;
            btnEliminarGrupo.Click += btnEliminar_Click;
            //
            // btnNuevoGrupo
            //
            btnNuevoGrupo.Location = new Point(573, 505);
            btnNuevoGrupo.Name = "btnNuevoGrupo";
            btnNuevoGrupo.Size = new Size(205, 40);
            btnNuevoGrupo.TabIndex = 15;
            btnNuevoGrupo.Text = "Nuevo grupo";
            btnNuevoGrupo.UseVisualStyleBackColor = true;
            btnNuevoGrupo.Click += btnNuevo_Click;
            //
            // btnGuardarGrupo
            //
            btnGuardarGrupo.Location = new Point(788, 505);
            btnGuardarGrupo.Name = "btnGuardarGrupo";
            btnGuardarGrupo.Size = new Size(210, 40);
            btnGuardarGrupo.TabIndex = 16;
            btnGuardarGrupo.Text = "Guardar grupo";
            btnGuardarGrupo.UseVisualStyleBackColor = true;
            btnGuardarGrupo.Click += btnGuardar_Click;
            //
            // btnVolver
            //
            btnVolver.Location = new Point(888, 555);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(110, 36);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // FrmGruposPermisos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 600);
            Controls.Add(lblTituloGrupos);
            Controls.Add(lblEstadoGrupo);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(lblNombreGrupo);
            Controls.Add(txtNombreGrupo);
            Controls.Add(lblAyudaCodigo);
            Controls.Add(grpDisponibles);
            Controls.Add(btnAgregarAlGrupo);
            Controls.Add(btnQuitarDelGrupo);
            Controls.Add(grpContenidoGrupo);
            Controls.Add(lblAyudaDisponibles);
            Controls.Add(lblAyudaContenido);
            Controls.Add(lblLeyendaPerfil);
            Controls.Add(btnEditarGrupo);
            Controls.Add(btnEliminarGrupo);
            Controls.Add(btnNuevoGrupo);
            Controls.Add(btnGuardarGrupo);
            Controls.Add(btnVolver);
            Name = "FrmGruposPermisos";
            Text = "FrmGruposPermisos";
            Load += FrmGruposPermisos_Load;
            grpDisponibles.ResumeLayout(false);
            grpContenidoGrupo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloGrupos;
        private Label lblEstadoGrupo;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombreGrupo;
        private TextBox txtNombreGrupo;
        private Label lblAyudaCodigo;
        private GroupBox grpDisponibles;
        private TreeView treePermisosDisponibles;
        private GroupBox grpContenidoGrupo;
        private TreeView treePermisosDelGrupo;
        private Button btnAgregarAlGrupo;
        private Button btnQuitarDelGrupo;
        private Label lblAyudaDisponibles;
        private Label lblAyudaContenido;
        private Label lblLeyendaPerfil;
        private Button btnEditarGrupo;
        private Button btnEliminarGrupo;
        private Button btnNuevoGrupo;
        private Button btnGuardarGrupo;
        private Button btnVolver;
    }
}
