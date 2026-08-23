namespace Oasis_Sports
{
    partial class FrmHistorialCambios
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
            dgvHistorial = new DataGridView();
            lblTitulo = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.Location = new Point(12, 50);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(760, 350);
            dgvHistorial.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(100, 23);
            lblTitulo.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 412);
            button1.Name = "button1";
            button1.Size = new Size(178, 35);
            button1.TabIndex = 2;
            button1.Text = "Restaurar valor anterior";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(665, 414);
            button2.Name = "button2";
            button2.Size = new Size(107, 35);
            button2.TabIndex = 3;
            button2.Text = "Cerrar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(276, 9);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 4;
            label1.Text = "Historial de Cambios";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmHistorialCambios
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvHistorial);
            Name = "FrmHistorialCambios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Cambios";
            FormClosing += FrmHistorialCambios_FormClosing;
            Load += FrmHistorialCambios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridView dgvHistorial;
        private Label lblTitulo;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}