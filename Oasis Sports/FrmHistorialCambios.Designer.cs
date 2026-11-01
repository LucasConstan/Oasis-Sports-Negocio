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
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            btnRestaurar = new Button();
            btnCerrar = new Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            //
            // dgvHistorial
            //
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.Location = new Point(12, 90);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(960, 360);
            dgvHistorial.TabIndex = 2;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 57);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            //
            // cmbUsuario
            //
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Location = new Point(80, 54);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(250, 23);
            cmbUsuario.TabIndex = 1;
            cmbUsuario.Format += cmbUsuario_Format;
            cmbUsuario.SelectedIndexChanged += cmbUsuario_SelectedIndexChanged;
            //
            // btnRestaurar
            //
            btnRestaurar.Location = new Point(12, 462);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(200, 35);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Text = "Restaurar esta versión";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            //
            // btnCerrar
            //
            btnCerrar.Location = new Point(865, 462);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(107, 35);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(375, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(234, 32);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Historial de Cambios";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            //
            // FrmHistorialCambios
            //
            ClientSize = new Size(984, 509);
            Controls.Add(lblTitulo);
            Controls.Add(btnCerrar);
            Controls.Add(btnRestaurar);
            Controls.Add(cmbUsuario);
            Controls.Add(lblUsuario);
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
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Button btnRestaurar;
        private Button btnCerrar;
        private Label lblTitulo;
    }
}
