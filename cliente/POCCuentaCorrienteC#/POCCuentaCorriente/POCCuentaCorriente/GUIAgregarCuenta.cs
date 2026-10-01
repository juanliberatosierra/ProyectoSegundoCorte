using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente
{
    public partial class GUIAgregarCuenta : Form
    {
        public GUIAgregarCuenta()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await agregarCuenta();
        }

        private async Task agregarCuenta()
        {
            try
            {
                var client = new GraphQLHttpClient(
                    "http://localhost:8081/graphql",
                    new SystemTextJsonSerializer());

                var inputData = new CuentaCorrienteInput
                {
                    numeroCuenta = int.Parse(txtNumeroCuenta.Text),
                    titular = txtTitular.Text,
                    fechaApertura = dtpFechaApertura.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    saldo = double.Parse(txtSaldo.Text),
                    cuotaManejo = double.Parse(txtCuotaManejo.Text),
                    tipoCuenta = cmbTipoCuenta.Text
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation agregarCuenta($input: CuentaCorrienteInput!) {
                            agregarCuenta(input: $input) {
                                numeroCuenta
                                titular
                                fechaApertura
                                saldo
                                cuotaManejo
                                tipoCuenta
                            }
                        }
                    ",
                    Variables = new
                    {
                        input = inputData
                    }
                };

                var response =
                    await client.SendMutationAsync<AddCuentaResponse>(request);

                // Mostrar mensajes limpios de las validaciones
                if (response.Errors != null && response.Errors.Length > 0)
                {
                    string mensaje = response.Errors[0].Message;

                    if (mensaje.Contains("cuota de manejo no puede ser mayor que el saldo"))
                    {
                        mensaje = "La cuota de manejo no puede ser mayor que el saldo.";
                    }
                    else if (mensaje.Contains("saldo no puede ser negativo"))
                    {
                        mensaje = "El saldo no puede ser negativo.";
                    }
                    else if (mensaje.Contains("cuota de manejo no puede ser negativa"))
                    {
                        mensaje = "La cuota de manejo no puede ser negativa.";
                    }
                    else if (mensaje.Contains("Ya existe una cuenta con ese número"))
                    {
                        mensaje = "Ya existe una cuenta con ese número.";
                    }

                    MessageBox.Show(
                        mensaje,
                        "Datos inválidos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Verificar si el backend devolvió una cuenta
                if (response.Data == null ||
                    response.Data.agregarCuenta == null)
                {
                    MessageBox.Show(
                        "No se pudo agregar la cuenta.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                var cuenta = response.Data.agregarCuenta;

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