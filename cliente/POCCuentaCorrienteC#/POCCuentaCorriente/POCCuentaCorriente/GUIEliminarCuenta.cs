using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    public partial class GUIEliminarCuenta : Form
    {
        public GUIEliminarCuenta()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Busque la cuenta y confirme su eliminación");

            // Solo se puede eliminar después de buscar la cuenta
            btnEliminar.Enabled = false;
            txtNumeroCuenta.TextChanged += (s, e) => limpiarDatos();
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

                CuentaCorrienteData cuenta;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    cuenta = await servicio.BuscarAsync(numeroCuenta);
                }

                if (cuenta == null)
                {
                    MessageBox.Show(
                        "No se encontró una cuenta con ese número.",
                        "Cuenta no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    limpiarDatos();

                    return;
                }

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

                bool eliminada;

                using (var servicio = new ServicioCuentaCorriente())
                {
                    eliminada = await servicio.EliminarAsync(numeroCuenta);
                }

                if (!eliminada)
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

                txtNumeroCuenta.Clear();
                limpiarDatos();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Ingrese un número de cuenta válido.",
                    "Datos inválidos",
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