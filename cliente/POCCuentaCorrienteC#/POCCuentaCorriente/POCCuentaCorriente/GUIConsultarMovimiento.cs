using System;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    // Ventana: consultar un movimiento por número de cuenta + ID del movimiento
    public partial class GUIConsultarMovimiento : Form
    {
        private readonly ServicioMovimientoBancario servicio =
            new ServicioMovimientoBancario();

        public GUIConsultarMovimiento()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Busque un movimiento por cuenta e ID");
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            int numeroCuenta;
            int idMovimiento;

            try
            {
                numeroCuenta = ValidacionesMovimiento.LeerEnteroPositivo(txtNumeroCuenta.Text, "Número de cuenta");
                idMovimiento = ValidacionesMovimiento.LeerEnteroPositivo(txtIdMovimiento.Text, "ID del movimiento");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnBuscar.Enabled = false;

            try
            {
                MovimientoData movimiento = await servicio.BuscarAsync(numeroCuenta, idMovimiento);

                if (movimiento == null)
                {
                    limpiarDatos();
                    MessageBox.Show(
                        "No existe un movimiento con ID " + idMovimiento +
                        " en la cuenta " + numeroCuenta + ".",
                        "Movimiento no encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                mostrarDatos(movimiento);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con el servidor:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }

        private void mostrarDatos(MovimientoData movimiento)
        {
            txtTipoMovimiento.Text = movimiento.tipoMovimiento;
            txtMonto.Text = movimiento.monto.ToString("N2");
            txtFechaMovimiento.Text = ServicioMovimientoBancario.FechaParaMostrar(movimiento.fechaMovimiento);
            txtDescripcion.Text = movimiento.descripcion;
            txtConfirmado.Text = movimiento.confirmado ? "Sí" : "No";
        }

        // Si el usuario cambia la cuenta o el ID, se borran los datos mostrados
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void limpiarDatos()
        {
            txtTipoMovimiento.Clear();
            txtMonto.Clear();
            txtFechaMovimiento.Clear();
            txtDescripcion.Clear();
            txtConfirmado.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            servicio.Dispose();
            base.OnFormClosed(e);
        }
    }
}
