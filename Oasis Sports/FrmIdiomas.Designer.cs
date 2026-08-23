namespace Oasis_Sports
{
    partial class FrmIdiomas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbIdiomas = new ComboBox();
            lstClaves = new ListBox();
            txtClave = new TextBox();
            txtTexto = new TextBox();
            txtNuevoIdioma = new TextBox();
            btnGuardar = new Button();
            btnNuevoIdioma = new Button();
            btnCambiarIdioma = new Button();
            lblIdiomaActivo = new Label();
            lblClaves = new Label();
            lblClave = new Label();
            lblTexto = new Label();
            lblNuevoIdioma = new Label();
            btnVolver = new Button();
            lblIdioma = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbIdiomas
            // 
            cmbIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdiomas.Location = new Point(49, 323);
            cmbIdiomas.Name = "cmbIdiomas";
            cmbIdiomas.Size = new Size(190, 29);
            cmbIdiomas.TabIndex = 5;
            // 
            // lstClaves
            // 
            lstClaves.ItemHeight = 21;
            lstClaves.Location = new Point(422, 92);
            lstClaves.Name = "lstClaves";
            lstClaves.Size = new Size(270, 361);
            lstClaves.TabIndex = 7;
            lstClaves.SelectedIndexChanged += lstClaves_SelectedIndexChanged;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(29, 36);
            txtClave.Name = "txtClave";
            txtClave.ReadOnly = true;
            txtClave.Size = new Size(190, 29);
            txtClave.TabIndex = 8;
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(29, 86);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(190, 29);
            txtTexto.TabIndex = 9;
            // 
            // txtNuevoIdioma
            // 
            txtNuevoIdioma.Location = new Point(49, 95);
            txtNuevoIdioma.Name = "txtNuevoIdioma";
            txtNuevoIdioma.Size = new Size(190, 29);
            txtNuevoIdioma.TabIndex = 12;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.Location = new Point(246, 47);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 58);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar traducción";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevoIdioma
            // 
            btnNuevoIdioma.BackColor = Color.Transparent;
            btnNuevoIdioma.Location = new Point(266, 92);
            btnNuevoIdioma.Name = "btnNuevoIdioma";
            btnNuevoIdioma.Size = new Size(130, 32);
            btnNuevoIdioma.TabIndex = 13;
            btnNuevoIdioma.Text = "Crear idioma";
            btnNuevoIdioma.UseVisualStyleBackColor = false;
            btnNuevoIdioma.Click += btnNuevoIdioma_Click;
            // 
            // btnCambiarIdioma
            // 
            btnCambiarIdioma.BackColor = Color.Transparent;
            btnCambiarIdioma.Location = new Point(266, 315);
            btnCambiarIdioma.Name = "btnCambiarIdioma";
            btnCambiarIdioma.Size = new Size(130, 43);
            btnCambiarIdioma.TabIndex = 6;
            btnCambiarIdioma.Text = "Aplicar idioma";
            btnCambiarIdioma.UseVisualStyleBackColor = false;
            btnCambiarIdioma.Click += btnCambiarIdioma_Click;
            // 
            // lblIdiomaActivo
            // 
            lblIdiomaActivo.Location = new Point(0, 0);
            lblIdiomaActivo.Name = "lblIdiomaActivo";
            lblIdiomaActivo.Size = new Size(100, 23);
            lblIdiomaActivo.TabIndex = 0;
            // 
            // lblClaves
            // 
            lblClaves.Location = new Point(0, 0);
            lblClaves.Name = "lblClaves";
            lblClaves.Size = new Size(100, 23);
            lblClaves.TabIndex = 1;
            // 
            // lblClave
            // 
            lblClave.Location = new Point(0, 0);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(100, 23);
            lblClave.TabIndex = 2;
            // 
            // lblTexto
            // 
            lblTexto.Location = new Point(0, 0);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(100, 23);
            lblTexto.TabIndex = 3;
            // 
            // lblNuevoIdioma
            // 
            lblNuevoIdioma.Location = new Point(0, 0);
            lblNuevoIdioma.Name = "lblNuevoIdioma";
            lblNuevoIdioma.Size = new Size(100, 23);
            lblNuevoIdioma.TabIndex = 4;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Transparent;
            btnVolver.Location = new Point(20, 405);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(98, 38);
            btnVolver.TabIndex = 14;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button1_Click;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIdioma.Location = new Point(247, 25);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(197, 27);
            lblIdioma.TabIndex = 15;
            lblIdioma.Text = "Gestion de Idiomas";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtTexto);
            groupBox1.Controls.Add(txtClave);
            groupBox1.Location = new Point(20, 155);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(396, 137);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // FrmIdiomas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(700, 470);
            Controls.Add(groupBox1);
            Controls.Add(lblIdioma);
            Controls.Add(lstClaves);
            Controls.Add(lblIdiomaActivo);
            Controls.Add(lblClaves);
            Controls.Add(lblClave);
            Controls.Add(lblTexto);
            Controls.Add(lblNuevoIdioma);
            Controls.Add(cmbIdiomas);
            Controls.Add(btnCambiarIdioma);
            Controls.Add(txtNuevoIdioma);
            Controls.Add(btnNuevoIdioma);
            Controls.Add(btnVolver);
            Name = "FrmIdiomas";
            Text = "Gestión de Idiomas";
            FormClosing += FrmIdiomas_FormClosing;
            Load += FrmIdiomas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbIdiomas;
        private ListBox lstClaves;
        private TextBox txtClave;
        private TextBox txtTexto;
        private TextBox txtNuevoIdioma;
        private Button btnGuardar;
        private Button btnNuevoIdioma;
        private Button btnCambiarIdioma;
        private Label lblIdiomaActivo;
        private Label lblClaves;
        private Label lblClave;
        private Label lblTexto;
        private Label lblNuevoIdioma;
        private Button btnVolver;
        private Label lblIdioma;
        private GroupBox groupBox1;
    }
}
