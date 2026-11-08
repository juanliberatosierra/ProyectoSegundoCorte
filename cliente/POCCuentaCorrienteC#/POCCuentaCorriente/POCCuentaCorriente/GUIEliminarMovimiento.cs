using System;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    // Ventana: eliminar un movimiento. Primero se busca y se muestra
    // toda su información; luego se confirma la eliminación.
    public partial class GUIEliminarMovimiento : Form
    {
        private readonly ServicioMovimientoBancario servicio =
            new ServicioMovimientoBancario();

        // Movimiento encontrado en la última búsqueda (el que se va a eliminar)
        private MovimientoData movimientoEncontrado;

        public GUIEliminarMovimiento()
        {
            InitializeComponent();
            Estilo.Aplicar(this, "Busque el movimiento y confirme su eliminación");
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

                movimientoEncontrado = movimiento;

                txtTipoMovimiento.Text = movimiento.tipoMovimiento;
                txtMonto.Text = movimiento.monto.ToString("N2");
                txtFechaMovimiento.Text = ServicioMovimientoBancario.FechaParaMostrar(movimiento.fechaMovimiento);
                txtDescripcion.Text = movimiento.descripcion;
                txtConfirmado.Text = movimiento.confirmado ? "Sí" : "No";

                btnEliminar.Enabled = true;
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (movimientoEncontrado == null)
            {
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar el movimiento " +
                movimientoEncontrado.idMovimiento + " de la cuenta " +
                movimientoEncontrado.numeroCuenta + "?\n\n" +
                movimientoEncontrado.tipoMovimiento + " por " +
                movimientoEncontrado.monto.ToString("N2") + "\n" +
                movimientoEncontrado.descripcion,
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            btnEliminar.Enabled = false;

            try
            {
                bool eliminado = await servicio.EliminarAsync(
                    movimientoEncontrado.numeroCuenta,
                    movimientoEncontrado.idMovimiento);

                if (!eliminado)
                {
                    MessageBox.Show("No se pudo eliminar el movimiento (puede que ya no exista).",
                        "No se eliminó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("El movimiento fue eliminado correctamente.",
                    "Movimiento eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNumeroCuenta.Clear();
                txtIdMovimiento.Clear();
                limpiarDatos();
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
        }

        // Si cambian la cuenta o el ID después de buscar, hay que buscar de nuevo
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void limpiarDatos()
        {
            movimientoEncontrado = null;
            txtTipoMovimiento.Clear();
            txtMonto.Clear();
            txtFechaMovimiento.Clear();
            txtDescripcion.Clear();
            txtConfirmado.Clear();
            btnEliminar.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            servicio.Dispose();
            base.OnFormClosed(e);
        }
    }
}
