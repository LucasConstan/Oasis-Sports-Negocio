namespace Oasis_Sports
{
    partial class FrmCambiarContraseña
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
            lblCambiarContraseña = new Label();
            lblContraseñaActual = new Label();
            txtContraseñaActual = new TextBox();
            lblContraseñaNueva = new Label();
            txtContraseñaNueva = new TextBox();
            lblConfirmarContraseña = new Label();
            txtConfirmarContraseña = new TextBox();
            btnCambiar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            //
            // lblCambiarContraseña
            //
            lblCambiarContraseña.AutoSize = true;
            lblCambiarContraseña.ForeColor = Color.DarkGreen;
            lblCambiarContraseña.Location = new Point(10, 13);
            lblCambiarContraseña.Name = "lblCambiarContraseña";
            lblCambiarContraseña.Size = new Size(240, 21);
            lblCambiarContraseña.TabIndex = 6;
            lblCambiarContraseña.Text = "CAMBIAR CONTRASEÑA";
            //
            // lblContraseñaActual
            //
            lblContraseñaActual.AutoSize = true;
            lblContraseñaActual.ForeColor = Color.DarkGreen;
            lblContraseñaActual.Location = new Point(10, 60);
            lblContraseñaActual.Name = "lblContraseñaActual";
            lblContraseñaActual.Size = new Size(215, 21);
            lblContraseñaActual.TabIndex = 7;
            lblContraseñaActual.Text = "CONTRASEÑA ACTUAL";
            //
            // txtContraseñaActual
            //
            txtContraseñaActual.Location = new Point(12, 82);
            txtContraseñaActual.MaxLength = 50;
            txtContraseñaActual.Name = "txtContraseñaActual";
            txtContraseñaActual.Size = new Size(296, 29);
            txtContraseñaActual.TabIndex = 1;
            txtContraseñaActual.UseSystemPasswordChar = true;
            //
            // lblContraseñaNueva
            //
            lblContraseñaNueva.AutoSize = true;
            lblContraseñaNueva.ForeColor = Color.DarkGreen;
            lblContraseñaNueva.Location = new Point(10, 126);
            lblContraseñaNueva.Name = "lblContraseñaNueva";
            lblContraseñaNueva.Size = new Size(207, 21);
            lblContraseñaNueva.TabIndex = 8;
            lblContraseñaNueva.Text = "NUEVA CONTRASEÑA";
            //
            // txtContraseñaNueva
            //
            txtContraseñaNueva.Location = new Point(12, 148);
            txtContraseñaNueva.MaxLength = 50;
            txtContraseñaNueva.Name = "txtContraseñaNueva";
            txtContraseñaNueva.Size = new Size(296, 29);
            txtContraseñaNueva.TabIndex = 2;
            txtContraseñaNueva.UseSystemPasswordChar = true;
            //
            // lblConfirmarContraseña
            //
            lblConfirmarContraseña.AutoSize = true;
            lblConfirmarContraseña.ForeColor = Color.DarkGreen;
            lblConfirmarContraseña.Location = new Point(10, 192);
            lblConfirmarContraseña.Name = "lblConfirmarContraseña";
            lblConfirmarContraseña.Size = new Size(296, 21);
            lblConfirmarContraseña.TabIndex = 9;
            lblConfirmarContraseña.Text = "CONFIRMAR NUEVA CONTRASEÑA";
            //
            // txtConfirmarContraseña
            //
            txtConfirmarContraseña.Location = new Point(12, 214);
            txtConfirmarContraseña.MaxLength = 50;
            txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            txtConfirmarContraseña.Size = new Size(296, 29);
            txtConfirmarContraseña.TabIndex = 3;
            txtConfirmarContraseña.UseSystemPasswordChar = true;
            //
            // btnCambiar
            //
            btnCambiar.BackColor = Color.White;
            btnCambiar.ForeColor = Color.DarkGreen;
            btnCambiar.Location = new Point(12, 268);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(296, 35);
            btnCambiar.TabIndex = 4;
            btnCambiar.Text = "CAMBIAR";
            btnCambiar.UseVisualStyleBackColor = false;
            btnCambiar.Click += btnCambiar_Click;
            //
            // btnVolver
            //
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(12, 309);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(296, 35);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // FrmCambiarContraseña
            //
            AcceptButton = btnCambiar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 360);
            Controls.Add(btnVolver);
            Controls.Add(btnCambiar);
            Controls.Add(txtConfirmarContraseña);
            Controls.Add(lblConfirmarContraseña);
            Controls.Add(txtContraseñaNueva);
            Controls.Add(lblContraseñaNueva);
            Controls.Add(txtContraseñaActual);
            Controls.Add(lblContraseñaActual);
            Controls.Add(lblCambiarContraseña);
            Name = "FrmCambiarContraseña";
            Text = "FrmCambiarContraseña";
            FormClosing += FrmCambiarContraseña_FormClosing;
            Load += FrmCambiarContraseña_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCambiarContraseña;
        private Label lblContraseñaActual;
        private TextBox txtContraseñaActual;
        private Label lblContraseñaNueva;
        private TextBox txtContraseñaNueva;
        private Label lblConfirmarContraseña;
        private TextBox txtConfirmarContraseña;
        private Button btnCambiar;
        private Button btnVolver;
    }
}
