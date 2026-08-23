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
            textBox1 = new TextBox();
            label1 = new Label();
            lstPermisosDisponibles = new ListBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lstPermisosDelGrupo = new ListBox();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnGuardar = new Button();
            btnVolver = new Button();
            btnModificar = new Button();
            lblmodo = new Label();
            btnNuevo = new Button();
            btnEliminar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(329, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(154, 29);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 47);
            label1.Name = "label1";
            label1.Size = new Size(152, 21);
            label1.TabIndex = 1;
            label1.Text = "Nombre de grupo: ";
            // 
            // lstPermisosDisponibles
            // 
            lstPermisosDisponibles.FormattingEnabled = true;
            lstPermisosDisponibles.ItemHeight = 21;
            lstPermisosDisponibles.Location = new Point(30, 22);
            lstPermisosDisponibles.Name = "lstPermisosDisponibles";
            lstPermisosDisponibles.Size = new Size(182, 256);
            lstPermisosDisponibles.TabIndex = 2;
            lstPermisosDisponibles.SelectedIndexChanged += lstPermisosDisponibles_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstPermisosDisponibles);
            groupBox1.Location = new Point(51, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 293);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permisos disponibles";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstPermisosDelGrupo);
            groupBox2.Location = new Point(504, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(240, 293);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Permisos del grupo";
            // 
            // lstPermisosDelGrupo
            // 
            lstPermisosDelGrupo.FormattingEnabled = true;
            lstPermisosDelGrupo.ItemHeight = 21;
            lstPermisosDelGrupo.Location = new Point(30, 22);
            lstPermisosDelGrupo.Name = "lstPermisosDelGrupo";
            lstPermisosDelGrupo.Size = new Size(182, 256);
            lstPermisosDelGrupo.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(330, 113);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(153, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(330, 166);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(153, 38);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "QUITAR";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(329, 276);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(153, 38);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(682, 413);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(113, 32);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += button1_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(331, 222);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(152, 39);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblmodo
            // 
            lblmodo.AutoSize = true;
            lblmodo.Location = new Point(4, 8);
            lblmodo.Name = "lblmodo";
            lblmodo.Size = new Size(76, 21);
            lblmodo.TabIndex = 10;
            lblmodo.Text = "MODO: ";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(504, 42);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(168, 31);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "NUEVO GRUPO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += button1_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(329, 332);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(153, 38);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmGruposPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(lblmodo);
            Controls.Add(btnModificar);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "FrmGruposPermisos";
            Text = "FrmGruposPermisos";
            Load += FrmGruposPermisos_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private ListBox lstPermisosDisponibles;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox lstPermisosDelGrupo;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnGuardar;
        private Button btnVolver;
        private Button btnModificar;
        private Label lblmodo;
        private Button btnNuevo;
        private Button btnEliminar;
    }
}