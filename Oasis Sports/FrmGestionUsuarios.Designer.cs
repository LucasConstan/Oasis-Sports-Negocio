namespace Oasis_Sports
{
    partial class FrmGestionUsuarios
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
            dataGridView1 = new DataGridView();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            lblContraseña = new Label();
            txtContraseñaRepetida = new TextBox();
            lblRepetirContraseña = new Label();
            btnAñadir = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(305, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(577, 482);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.DarkGreen;
            lblUsuario.Location = new Point(10, 15);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(107, 21);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "USUARIO : ";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(12, 37);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(209, 29);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(12, 104);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(209, 29);
            txtContraseña.TabIndex = 4;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.ForeColor = Color.DarkGreen;
            lblContraseña.Location = new Point(10, 82);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(149, 21);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "CONTRASEÑA : ";
            // 
            // txtContraseñaRepetida
            // 
            txtContraseñaRepetida.Location = new Point(10, 170);
            txtContraseñaRepetida.Name = "txtContraseñaRepetida";
            txtContraseñaRepetida.PasswordChar = '*';
            txtContraseñaRepetida.Size = new Size(211, 29);
            txtContraseñaRepetida.TabIndex = 6;
            // 
            // lblRepetirContraseña
            // 
            lblRepetirContraseña.AutoSize = true;
            lblRepetirContraseña.ForeColor = Color.DarkGreen;
            lblRepetirContraseña.Location = new Point(8, 148);
            lblRepetirContraseña.Name = "lblRepetirContraseña";
            lblRepetirContraseña.Size = new Size(227, 21);
            lblRepetirContraseña.TabIndex = 5;
            lblRepetirContraseña.Text = "REPETIR CONTRASEÑA: ";
            // 
            // btnAñadir
            // 
            btnAñadir.BackColor = Color.White;
            btnAñadir.ForeColor = Color.DarkGreen;
            btnAñadir.Location = new Point(12, 229);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(209, 35);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "AÑADIR";
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(12, 285);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(12, 339);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(12, 392);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(209, 35);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button1_Click;
            // 
            // FrmGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(881, 482);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(txtContraseñaRepetida);
            Controls.Add(lblRepetirContraseña);
            Controls.Add(txtContraseña);
            Controls.Add(lblContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(dataGridView1);
            Name = "FrmGestionUsuarios";
            Text = "FrmGestionUsuarios";
            FormClosing += FrmGestionUsuarios_FormClosing;
            Load += FrmGestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label lblContraseña;
        private TextBox txtContraseñaRepetida;
        private Label lblRepetirContraseña;
        private Button btnAñadir;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnVolver;
    }
}