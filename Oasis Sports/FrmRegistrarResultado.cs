using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class FrmRegistrarResultado : BaseForm, IObserverIdioma
    {
        public FrmRegistrarResultado()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        BLL_Torneo bllTorneo_348LC = new BLL_Torneo();
        BLL_Resultado bllResultado_348LC = new BLL_Resultado();
        int idPartidoSeleccionado_348LC = 0;

        private void FrmRegistrarResultado_Load(object sender, EventArgs e)
        {
            RegistrarClaves();
            LanguageManager.GetInstance().TraducirControles(this);

            cmbTorneo.DisplayMember = "NombreTorneo";
            cmbTorneo.ValueMember = "Id";
            cmbTorneo.DataSource = bllTorneo_348LC.Listar_348LC();
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LanguageManager.GetInstance().TraducirControles(this)));
            else
                LanguageManager.GetInstance().TraducirControles(this);
        }

        private void RegistrarClaves()
        {
            int idIdioma = LanguageManager.GetInstance().IdIdiomaActual;
            BLL_Traduccion bll = new BLL_Traduccion();
            List<string> clavesExistentes = bll.ObtenerTodasLasClaves();

            foreach (Control c in this.Controls)
                RegistrarRecursivo(c, idIdioma, bll, clavesExistentes);
        }

        private void RegistrarRecursivo(Control c, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            if (!string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text)
                && !clavesExistentes.Contains(c.Name))
            {
                bll.GuardarOActualizar(new Traduccion
                {
                    IdIdioma = idIdioma,
                    Clave = c.Name,
                    Texto = c.Text
                });
                clavesExistentes.Add(c.Name);
            }

            foreach (Control hijo in c.Controls)
                RegistrarRecursivo(hijo, idIdioma, bll, clavesExistentes);
        }

        private void CargarGrilla_348LC()
        {
            if (cmbTorneo.SelectedValue == null)
                return;

            int idTorneo_348LC = Convert.ToInt32(cmbTorneo.SelectedValue);
            dgvPartidosPendientes.DataSource = bllResultado_348LC.ListarPendientes_348LC(idTorneo_348LC);
            dgvPartidosPendientes.Columns["Eliminado"].Visible = false;
            dgvPartidosPendientes.Columns["DVH"].Visible = false;
            dgvPartidosPendientes.Columns["Id"].Visible = false;
            dgvPartidosPendientes.Columns["IdEquipoLocal"].Visible = false;
            dgvPartidosPendientes.Columns["IdEquipoVisitante"].Visible = false;
            dgvPartidosPendientes.Columns["IdTorneo"].Visible = false;

        }

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla_348LC();
        }

        private void dgvPartidosPendientes_SelectionChanged(object sender, EventArgs e)
        {
            {
                if (dgvPartidosPendientes.CurrentRow == null)
                    return;

                Partido partido_348LC = (Partido)dgvPartidosPendientes.CurrentRow.DataBoundItem;
                idPartidoSeleccionado_348LC = partido_348LC.Id;
            }
        }


        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (idPartidoSeleccionado_348LC == 0)
            {
                MessageBox.Show("Seleccioná un partido de la grilla.");
                return;
            }

            try
            {
                if (chkSuspendido.Checked)
                {
                    bllResultado_348LC.Suspender_348LC(idPartidoSeleccionado_348LC);
                    MessageBox.Show("Partido marcado como suspendido. El Organizador debe reprogramarlo.");
                }
                else
                {
                    int golesLocal_348LC = Convert.ToInt32(nudGolesLocal.Value);
                    int golesVisitante_348LC = Convert.ToInt32(nudGolesVisitante.Value);

                    bllResultado_348LC.RegistrarResultado_348LC(idPartidoSeleccionado_348LC, golesLocal_348LC, golesVisitante_348LC);
                    MessageBox.Show("Resultado registrado correctamente.");
                }

                BLL_Evento bllEvento = new BLL_Evento();
                bllEvento.RegistrarEvento(new Evento()
                {
                    Usuario = SessionManager.GetInstance().Usuario.Username,
                    Modulo = "Registrar Resultado",
                    Descripcion = chkSuspendido.Checked ? "Partido suspendido" : "Nuevo resultado",
                    Fecha = DateTime.Now,
                    Criticidad = 4
                });

                CargarGrilla_348LC();
                idPartidoSeleccionado_348LC = 0;
            }
            catch (Exception ex_348LC)
            {
                MessageBox.Show(ex_348LC.Message);
            }
        }
    }
}
