namespace Oasis_Sports
{
    partial class FrmSeleccionIdioma
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
            btnConfirmar = new Button();
            lblBienvenido = new Label();
            lblSeleccionarIdioma = new Label();
            SuspendLayout();
            // 
            // cmbIdiomas
            // 
            cmbIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdiomas.Location = new Point(55, 105);
            cmbIdiomas.Name = "cmbIdiomas";
            cmbIdiomas.Size = new Size(270, 23);
            cmbIdiomas.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(126, 155);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(120, 35);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBienvenido.Location = new Point(126, 9);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(115, 30);
            lblBienvenido.TabIndex = 4;
            lblBienvenido.Text = "Bienvenido";
            // 
            // lblSeleccionarIdioma
            // 
            lblSeleccionarIdioma.AutoSize = true;
            lblSeleccionarIdioma.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeleccionarIdioma.Location = new Point(87, 58);
            lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            lblSeleccionarIdioma.Size = new Size(202, 30);
            lblSeleccionarIdioma.TabIndex = 5;
            lblSeleccionarIdioma.Text = "Selecciona el idioma";
            // 
            // FrmSeleccionIdioma
            // 
            ClientSize = new Size(374, 211);
            Controls.Add(lblSeleccionarIdioma);
            Controls.Add(lblBienvenido);
            Controls.Add(cmbIdiomas);
            Controls.Add(btnConfirmar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSeleccionIdioma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selección de idioma";
            Load += FrmSeleccionIdioma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbIdiomas;
        private Button btnConfirmar;
        private Label lblBienvenido;
        private Label lblSeleccionarIdioma;
    }
}