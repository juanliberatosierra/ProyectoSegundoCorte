using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    public partial class GUIActualizarCuenta : Form
    {
        private int? cuentaBuscada = null;

        public GUIActualizarCuenta()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Busque la cuenta y modifique sus datos");

            // Solo se puede actualizar después de buscar la cuenta
            btnActualizar.Enabled = false;

            // Si cambian el número después de buscar, hay que volver a buscar
            txtNumeroCuenta.TextChanged += (s, e) =>
            {
                cuentaBuscada = null;
                btnActualizar.Enabled = false;
            };
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

                    cuentaBuscada = null;
                    btnActualizar.Enabled = false;

                    return;
                }

                txtTitular.Text = cuenta.titular;
                txtFechaApertura.Text = cuenta.fechaApertura;
                txtSaldo.Text = cuenta.saldo.ToString();
                txtCuotaManejo.Text = cuenta.cuotaManejo.ToString();
                txtTipoCuenta.Text = cuenta.tipoCuenta;

                cuentaBuscada = cuenta.numeroCuenta;
                btnActualizar.Enabled = true;
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
                    "Error al buscar la cuenta:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task actualizarCuenta()
        {
            // Seguridad extra: nunca actualizar sin haber buscado antes
            if (cuentaBuscada == null)
            {
                MessageBox.Show(
                    "Primero busque la cuenta que desea actualizar.",
                    "Actualizar cuenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                var inputData = new CuentaCorrienteInput
                {
                    numeroCuenta = cuentaBuscada.Value,
                    titular = txtTitular.Text,
                    fechaApertura = txtFechaApertura.Text,
                    saldo = double.Parse(txtSaldo.Text),
                    
                    cuotaManejo = string.IsNullOrWhiteSpace(txtCuotaManejo.Text)
                        ? (double?)null
                        : double.Parse(txtCuotaManejo.Text),
                    tipoCuenta = txtTipoCuenta.Text
                };

                CuentaCorrienteData cuenta;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    cuenta = await servicio.ActualizarAsync(inputData);
                }

                if (cuenta == null)
                {
                    MessageBox.Show(
                        "No se encontró una cuenta con ese número.",
                        "Actualizar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

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
                    "Revise que el saldo y la cuota de manejo sean valores numéricos.",
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
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