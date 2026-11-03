using System;
using System.Windows.Forms;
using POCCuentaCorriente.model;
using POCCuentaCorriente.servicios;

namespace POCCuentaCorriente
{
    // Ventana: listar movimientos en una grilla, con filtro por cuenta y tipo.
    // Usa la consulta personalizada listarMovimientosConCuenta, que trae
    // cada movimiento + 2 atributos de su cuenta (titular y tipo de cuenta).
    public partial class GUIListarMovimientos : Form
    {
        private readonly ServicioMovimientoBancario servicio =
            new ServicioMovimientoBancario();

        public GUIListarMovimientos()
        {
            InitializeComponent();
        }

        private async void GUIListarMovimientos_Load(object sender, EventArgs e)
        {
            cmbTipoMovimiento.SelectedIndex = 0; // "Todos"
            await listarMovimientos(false);
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            await listarMovimientos(true);
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtNumeroCuenta.Clear();
            cmbTipoMovimiento.SelectedIndex = 0;
            await listarMovimientos(false);
        }

        private async System.Threading.Tasks.Task listarMovimientos(bool avisarSiVacio)
        {
            // Filtro 1: número de cuenta (opcional)
            int? numeroCuenta = null;

            if (txtNumeroCuenta.Text.Trim().Length > 0)
            {
                try
                {
                    numeroCuenta = ValidacionesMovimiento.LeerEnteroPositivo(txtNumeroCuenta.Text, "Número de cuenta");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Datos inválidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Filtro 2: tipo de movimiento ("Todos" = sin filtro)
            string tipo = cmbTipoMovimiento.SelectedItem == null
                ? null
                : cmbTipoMovimiento.SelectedItem.ToString();

            if (tipo == "Todos")
            {
                tipo = null;
            }

            btnListar.Enabled = false;

            try
            {
                MovimientoDetalleData[] movimientos =
                    await servicio.ListarConCuentaAsync(numeroCuenta, tipo);

                dgvMovimientos.Rows.Clear();

                foreach (MovimientoDetalleData m in movimientos)
                {
                    dgvMovimientos.Rows.Add(
                        m.idMovimiento,
                        m.numeroCuenta,
                        m.titularCuenta,
                        m.tipoCuenta,
                        m.tipoMovimiento,
                        m.monto.ToString("N2"),
                        ServicioMovimientoBancario.FechaParaMostrar(m.fechaMovimiento),
                        m.descripcion,
                        m.confirmado ? "Sí" : "No");
                }

                lblTotal.Text = "Total de movimientos: " + movimientos.Length;

                if (movimientos.Length == 0 && avisarSiVacio)
                {
                    MessageBox.Show("No se encontraron movimientos con los filtros seleccionados.",
                        "Listado de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                btnListar.Enabled = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            servicio.Dispose();
            base.OnFormClosed(e);
        }
    }
}
