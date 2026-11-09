using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    public partial class GUIAgregarCuenta : Form
    {
        public GUIAgregarCuenta()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Complete los datos de la nueva cuenta");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await agregarCuenta();
        }

        private async Task agregarCuenta()
        {
            try
            {
                var inputData = new CuentaCorrienteInput
                {
                    numeroCuenta = int.Parse(txtNumeroCuenta.Text),
                    titular = txtTitular.Text,
                    fechaApertura = dtpFechaApertura.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    saldo = double.Parse(txtSaldo.Text),
                    // La cuota de manejo es opcional: vacía -> null (el servidor guarda 0)
                    cuotaManejo = string.IsNullOrWhiteSpace(txtCuotaManejo.Text)
                        ? (double?)null
                        : double.Parse(txtCuotaManejo.Text),
                    tipoCuenta = cmbTipoCuenta.Text
                };

                CuentaCorrienteData cuenta;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    cuenta = await servicio.AgregarAsync(inputData);
                }

                // Verificar si el backend devolvió una cuenta
                if (cuenta == null)
                {
                    MessageBox.Show(
                        "No se pudo agregar la cuenta.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Cuenta agregada correctamente.\n\n" +
                    "Número de cuenta: " + cuenta.numeroCuenta + "\n" +
                    "Titular: " + cuenta.titular + "\n" +
                    "Fecha de apertura: " + cuenta.fechaApertura + "\n" +
                    "Saldo: " + cuenta.saldo + "\n" +
                    "Cuota de manejo: " + cuenta.cuotaManejo + "\n" +
                    "Tipo de cuenta: " + cuenta.tipoCuenta,
                    "Cuenta agregada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar formulario
                txtNumeroCuenta.Clear();
                txtTitular.Clear();
                dtpFechaApertura.Value = DateTime.Now;
                txtSaldo.Clear();
                txtCuotaManejo.Clear();
                cmbTipoCuenta.SelectedIndex = -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Revise que el número de cuenta, saldo y cuota de manejo sean valores numéricos.",
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Mensaje de validación enviado por el servidor
                MessageBox.Show(
                    ex.Message,
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GUIAgregarCuenta_Load(object sender, EventArgs e)
        {
            dtpFechaApertura.Format = DateTimePickerFormat.Short;

            cmbTipoCuenta.Items.Clear();
            cmbTipoCuenta.Items.Add("Empresarial");
            cmbTipoCuenta.Items.Add("Personal");

            cmbTipoCuenta.SelectedIndex = -1;
        }
    }
}