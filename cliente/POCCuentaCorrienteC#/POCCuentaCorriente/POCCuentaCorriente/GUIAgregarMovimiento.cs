using System;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    // Ventana: registrar un nuevo movimiento bancario en una cuenta existente
    public partial class GUIAgregarMovimiento : Form
    {
        private readonly ServicioMovimientoBancario servicio =
            new ServicioMovimientoBancario();

        public GUIAgregarMovimiento()
        {
            InitializeComponent();
            limpiarFormulario();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            MovimientoBancarioInput input;

            // 1. Validar lo que escribió el usuario
            try
            {
                input = new MovimientoBancarioInput
                {
                    numeroCuenta = ValidacionesMovimiento.LeerEnteroPositivo(txtNumeroCuenta.Text, "Número de cuenta"),
                    idMovimiento = ValidacionesMovimiento.LeerEnteroPositivo(txtIdMovimiento.Text, "ID del movimiento"),
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

            // 2. Enviar al servidor
            btnGuardar.Enabled = false;

            try
            {
                MovimientoData movimiento = await servicio.AgregarAsync(input);

                MessageBox.Show(
                    "Movimiento registrado correctamente.\n\n" +
                    "Cuenta: " + movimiento.numeroCuenta + "\n" +
                    "ID: " + movimiento.idMovimiento + "\n" +
                    "Tipo: " + movimiento.tipoMovimiento + "\n" +
                    "Monto: " + movimiento.monto.ToString("N2"),
                    "Movimiento agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiarFormulario();
            }
            catch (InvalidOperationException ex)
            {
                // Error de validación enviado por el servidor (ej: la cuenta no existe)
                MessageBox.Show(ex.Message, "No se pudo agregar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con el servidor:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            txtNumeroCuenta.Clear();
            txtIdMovimiento.Clear();
            cmbTipoMovimiento.SelectedIndex = -1;
            txtMonto.Clear();
            dtpFechaMovimiento.Value = DateTime.Now;
            txtDescripcion.Clear();
            chkConfirmado.Checked = false;
            txtNumeroCuenta.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            servicio.Dispose();
            base.OnFormClosed(e);
        }
    }
}
