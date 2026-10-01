using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente
{
    public partial class GUIEliminarCuenta : Form
    {
        public GUIEliminarCuenta()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await buscarCuenta();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await eliminarCuenta();
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
                        "Cuenta no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    limpiarDatos();

                    return;
                }

                var cuenta = response.Data.cuenta;

                txtTitular.Text = cuenta.titular;
                txtFechaApertura.Text = cuenta.fechaApertura;
                txtSaldo.Text = cuenta.saldo.ToString();
                txtCuotaManejo.Text = cuenta.cuotaManejo.ToString();
                txtTipoCuenta.Text = cuenta.tipoCuenta;

                btnEliminar.Enabled = true;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Ingrese un número de cuenta válido.",
                    "Datos inválidos",
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

        private async Task eliminarCuenta()
        {
            try
            {
                int numeroCuenta = int.Parse(txtNumeroCuenta.Text);

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar la cuenta número "
                    + numeroCuenta + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                var client = new GraphQLHttpClient(
                    "http://localhost:8081/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation eliminarCuenta($numeroCuenta: Int!) {
                            eliminarCuenta(numeroCuenta: $numeroCuenta)
                        }
                    ",
                    Variables = new
                    {
                        numeroCuenta = numeroCuenta
                    }
                };

                var response =
                    await client.SendMutationAsync<EliminarCuentaResponse>(request);

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
                    !response.Data.eliminarCuenta)
                {
                    MessageBox.Show(
                        "No se pudo eliminar la cuenta.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "La cuenta número " + numeroCuenta +
                    " fue eliminada correctamente.",
                    "Cuenta eliminada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarDatos();
                txtNumeroCuenta.Clear();
                btnEliminar.Enabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Ingrese un número de cuenta válido.",
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void limpiarDatos()
        {
            txtTitular.Clear();
            txtFechaApertura.Clear();
            txtSaldo.Clear();
            txtCuotaManejo.Clear();
            txtTipoCuenta.Clear();
            btnEliminar.Enabled = false;
        }
    }
}