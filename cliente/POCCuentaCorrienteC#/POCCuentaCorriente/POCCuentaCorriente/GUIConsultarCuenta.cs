using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente
{
    public partial class GUIConsultarCuenta : Form
    {
        public GUIConsultarCuenta()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            await consultarCuenta();
        }

        private async Task consultarCuenta()
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

                if (response.Data == null || response.Data.cuenta == null)
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
                    "Error al consultar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}