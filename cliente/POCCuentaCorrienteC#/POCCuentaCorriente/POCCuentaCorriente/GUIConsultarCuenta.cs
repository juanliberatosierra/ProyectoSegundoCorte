using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    public partial class GUIConsultarCuenta : Form
    {
        public GUIConsultarCuenta()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Busque una cuenta por su número");
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

                CuentaCorrienteData cuenta;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    cuenta = await servicio.BuscarAsync(numeroCuenta);
                }

                if (cuenta == null)
                {
                    MessageBox.Show(
                        "No se encontró una cuenta con ese número.",
                        "Consulta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

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
                    "Error al consultar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}