namespace Oasis_Sports
{
    partial class FrmLogin
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
            textBox2 = new TextBox();
            btnIniciarSesion = new Button();
            lblUsuario = new Label();
            lblContraseña = new Label();
            lblAlquilerCanchas = new Label();
            btnVolver = new Button();
            pictureBox1 = new PictureBox();
            btnIdiomaInicio = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(201, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 21);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(201, 156);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(221, 21);
            textBox2.TabIndex = 1;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.White;
            btnIniciarSesion.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = Color.DarkGreen;
            btnIniciarSesion.Location = new Point(230, 199);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(149, 35);
            btnIniciarSesion.TabIndex = 2;
            btnIniciarSesion.Text = "INICIAR SESION";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += button1_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.DarkGreen;
            lblUsuario.Location = new Point(133, 114);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(61, 15);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "USUARIO";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = Color.DarkGreen;
            lblContraseña.Location = new Point(107, 159);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(91, 15);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "CONTRASEÑA";
            // 
            // lblAlquilerCanchas
            // 
            lblAlquilerCanchas.AutoSize = true;
            lblAlquilerCanchas.BackColor = Color.Transparent;
            lblAlquilerCanchas.Font = new Font("Times New Roman", 30F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAlquilerCanchas.ForeColor = Color.Green;
            lblAlquilerCanchas.Location = new Point(61, 28);
            lblAlquilerCanchas.Name = "lblAlquilerCanchas";
            lblAlquilerCanchas.Size = new Size(493, 47);
            lblAlquilerCanchas.TabIndex = 5;
            lblAlquilerCanchas.Text = "Alquiler de canchas de fútbol";
            lblAlquilerCanchas.TextAlign = ContentAlignment.TopCenter;
            lblAlquilerCanchas.Click += label3_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(230, 240);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(149, 35);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.banner;
            pictureBox1.Location = new Point(-8, 152);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(645, 280);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btnIdiomaInicio
            // 
            btnIdiomaInicio.BackColor = Color.Transparent;
            btnIdiomaInicio.ForeColor = Color.DarkGreen;
            btnIdiomaInicio.Location = new Point(550, 5);
            btnIdiomaInicio.Name = "btnIdiomaInicio";
            btnIdiomaInicio.Size = new Size(75, 23);
            btnIdiomaInicio.TabIndex = 8;
            btnIdiomaInicio.Text = "Idioma";
            btnIdiomaInicio.UseVisualStyleBackColor = false;
            btnIdiomaInicio.Click += button1_Click_1;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(630, 353);
            Controls.Add(btnIdiomaInicio);
            Controls.Add(btnVolver);
            Controls.Add(lblAlquilerCanchas);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(btnIniciarSesion);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Transparent;
            Name = "FrmLogin";
            Text = "FrmLogin";
            FormClosing += FrmLogin_FormClosing_1;
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnIniciarSesion;
        private Label lblUsuario;
        private Label lblContraseña;
        private Label lblAlquilerCanchas;
        private Button btnVolver;
        private PictureBox pictureBox1;
        private Button btnIdiomaInicio;
    }
}