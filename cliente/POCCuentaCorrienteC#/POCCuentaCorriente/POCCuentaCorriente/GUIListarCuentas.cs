using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente
{
    public partial class GUIListarCuentas : Form
    {
        public GUIListarCuentas()
        {
            InitializeComponent();
        }

        private async Task listarCuentas()
        {
            try
            {
                var client = new GraphQLHttpClient(
                    "http://localhost:8081/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        query listarCuentas(
                            $titular: String,
                            $tipoCuenta: String
                        ) {
                            listarCuentas(
                                titular: $titular,
                                tipoCuenta: $tipoCuenta
                            ) {
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
                        titular = txtTitular.Text,
                        tipoCuenta = cmbTipoCuenta.Text
                    }
                };

                var response =
                    await client.SendQueryAsync<ListarCuentasResponse>(request);

                if (response.Errors != null &&
                    response.Errors.Length > 0)
                {
                    MessageBox.Show(
                        response.Errors[0].Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                dgvCuentas.Rows.Clear();

                if (response.Data == null ||
                    response.Data.listarCuentas == null ||
                    response.Data.listarCuentas.Length == 0)
                {
                    MessageBox.Show(
                        "No se encontraron cuentas con los filtros seleccionados.",
                        "Listado de cuentas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                foreach (var cuenta in response.Data.listarCuentas)
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