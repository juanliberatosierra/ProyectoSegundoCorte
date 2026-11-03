using System;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    // Ventana: actualizar un movimiento. Primero se busca, se cargan todos
    // sus datos en el formulario, el usuario los edita y guarda.
    public partial class GUIActualizarMovimiento : Form
    {
        private readonly ServicioMovimientoBancario servicio =
            new ServicioMovimientoBancario();

        // Movimiento encontrado en la última búsqueda (el que se va a actualizar)
        private MovimientoData movimientoEncontrado;

        public GUIActualizarMovimiento()
        {
            InitializeComponent();
            habilitarEdicion(false);
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

                // Cargar TODA la información actual en el formulario
                cmbTipoMovimiento.SelectedItem = movimiento.tipoMovimiento;
                txtMonto.Text = movimiento.monto.ToString("0.##");
                dtpFechaMovimiento.Value = ServicioMovimientoBancario.FechaDesdeServidor(movimiento.fechaMovimiento);
                txtDescripcion.Text = movimiento.descripcion;
                chkConfirmado.Checked = movimiento.confirmado;

                habilitarEdicion(true);
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

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (movimientoEncontrado == null)
            {
                return;
            }

            MovimientoBancarioInput input;

            try
            {
                input = new MovimientoBancarioInput
                {
                    // La cuenta y el ID identifican el movimiento: no se cambian
                    numeroCuenta = movimientoEncontrado.numeroCuenta,
                    idMovimiento = movimientoEncontrado.idMovimiento,
                    tipoMovimiento = ValidacionesMovimiento.LeerTipoMovimiento(cmbTipoMovimiento.SelectedItem),
                    monto = ValidacionesMovimiento.LeerMonto(txtMonto.Text),
                    fechaMovimiento = ServicioMovimientoBancario.FechaParaServidor(
                        ValidacionesMovimiento.ValidarFecha(dtpFechaMovimiento.Value)),
                    descripcion = ValidacionesMovimiento.LeerDescripcion(txtDescripcion.Text),
                    confirmado = chkConfirmado.Checked
                };
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea guardar los cambios del movimiento " + input.idMovimiento +
                " de la cuenta " + input.numeroCuenta + "?",
                "Confirmar actualización",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            btnActualizar.Enabled = false;

            try
            {
                MovimientoData actualizado = await servicio.ActualizarAsync(input);

                if (actualizado == null)
                {
                    MessageBox.Show("No se pudo actualizar: el movimiento ya no existe.",
                        "No se actualizó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    limpiarDatos();
                    return;
                }

                movimientoEncontrado = actualizado;

                MessageBox.Show("El movimiento fue actualizado correctamente.",
                    "Movimiento actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con el servidor:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = movimientoEncontrado != null;
            }
        }

        // Si cambian la cuenta o el ID después de buscar, hay que buscar de nuevo
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void habilitarEdicion(bool habilitar)
        {
            cmbTipoMovimiento.Enabled = habilitar;
            txtMonto.Enabled = habilitar;
            dtpFechaMovimiento.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            chkConfirmado.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
        }

        private void limpiarDatos()
        {
            movimientoEncontrado = null;
            cmbTipoMovimiento.SelectedIndex = -1;
            txtMonto.Clear();
            dtpFechaMovimiento.Value = DateTime.Now;
            txtDescripcion.Clear();
            chkConfirmado.Checked = false;
            habilitarEdicion(false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            servicio.Dispose();
            base.OnFormClosed(e);
        }
    }
}
