using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente
{
    public partial class GUIActualizarCuenta : Form
    {
        public GUIActualizarCuenta()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await buscarCuenta();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await actualizarCuenta();
        }

        private async Task buscarCuenta()
        {
            try
            {
                int numeroCuenta = int.Parse(txtNumeroCuenta.Text);

                var client = new GraphQLHttpClient(
                    "http://localhost:8081/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        query buscarCuenta($numeroCuenta: Int!) {
                            buscarCuenta(numeroCuenta: $numeroCuenta) {
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
                        numeroCuenta = numeroCuenta
                    }
                };

                var response =
                    await client.SendQueryAsync<ResponseCuentaCorriente>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show(
                        response.Errors[0].Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (response.Data == null ||
                    response.Data.cuenta == null)
                {
                    MessageBox.Show(
                        "No se encontró una cuenta con ese número.",
                        "Consulta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                var cuenta = response.Data.cuenta;

                txtTitular.Text = cuenta.titular;
                txtFechaApertura.Text = cuenta.fechaApertura;
                txtSaldo.Text = cuenta.saldo.ToString();
                txtCuotaManejo.Text = cuenta.cuotaManejo.ToString();
                txtTipoCuenta.Text = cuenta.tipoCuenta;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Ingrese un número de cuenta válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task actualizarCuenta()
        {
            try
            {
                int numeroCuenta = int.Parse(txtNumeroCuenta.Text);

                var client = new GraphQLHttpClient(
                    "http://localhost:8081/graphql",
                    new SystemTextJsonSerializer());

                var inputData = new CuentaCorrienteInput
                {
                    numeroCuenta = numeroCuenta,
                    titular = txtTitular.Text,
                    fechaApertura = txtFechaApertura.Text,
                    saldo = double.Parse(txtSaldo.Text),
                    cuotaManejo = double.Parse(txtCuotaManejo.Text),
                    tipoCuenta = txtTipoCuenta.Text
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation actualizarCuenta($input: CuentaCorrienteInput!) {
                            actualizarCuenta(input: $input) {
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
                    await client.SendMutationAsync<ActualizarCuentaResponse>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show(
                        response.Errors[0].Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (response.Data == null ||
                    response.Data.actualizarCuenta == null)
                {
                    MessageBox.Show(
                        "No se encontró una cuenta con ese número.",
                        "Actualizar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var cuenta = response.Data.actualizarCuenta;

                MessageBox.Show(
                    "Cuenta actualizada correctamente.\n\n" +
                    "Número de cuenta: " + cuenta.numeroCuenta + "\n" +
                    "Titular: " + cuenta.titular + "\n" +
                    "Fecha de apertura: " + cuenta.fechaApertura + "\n" +
                    "Saldo: " + cuenta.saldo + "\n" +
                    "Cuota de manejo: " + cuenta.cuotaManejo + "\n" +
                    "Tipo de cuenta: " + cuenta.tipoCuenta,
                    "Actualizar cuenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
                    "Error al actualizar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}