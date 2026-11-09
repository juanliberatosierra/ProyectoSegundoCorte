using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    public partial class GUIListarCuentas : Form
    {
        public GUIListarCuentas()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Consulte y filtre las cuentas registradas");
        }

        private async Task listarCuentas()
        {
            try
            {
                CuentaCorrienteData[] cuentas;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    cuentas = await servicio.ListarAsync(
                        txtTitular.Text,
                        cmbTipoCuenta.Text);
                }

                dgvCuentas.Rows.Clear();

                if (cuentas.Length == 0)
                {
                    MessageBox.Show(
                        "No se encontraron cuentas con los filtros seleccionados.",
                        "Listado de cuentas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                foreach (var cuenta in cuentas)
                {
                    dgvCuentas.Rows.Add(
                        cuenta.numeroCuenta,
                        cuenta.titular,
                        cuenta.fechaApertura,
                        cuenta.saldo,
                        cuenta.cuotaManejo,
                        cuenta.tipoCuenta
                    );
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al listar las cuentas:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            await listarCuentas();
        }

        private void GUIListarCuentas_Load(object sender, EventArgs e)
        {
            cmbTipoCuenta.Items.Clear();

            cmbTipoCuenta.Items.Add("Todos");
            cmbTipoCuenta.Items.Add("Empresarial");
            cmbTipoCuenta.Items.Add("Personal");

            cmbTipoCuenta.SelectedIndex = 0;
        }
    }
}