using System;
using System.Windows.Forms;

namespace POCCuentaCorriente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Estilo.AplicarPrincipal(this, menuStrip1);
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarCuenta ventana = new GUIAgregarCuenta();
            ventana.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarCuentas ventana = new GUIListarCuentas();
            ventana.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIConsultarCuenta ventana = new GUIConsultarCuenta();
            ventana.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarCuenta ventana = new GUIEliminarCuenta();
            ventana.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarCuenta ventana = new GUIActualizarCuenta();
            ventana.Show();
        }

        // ===== Menú Movimiento Bancario =====

        private void adicionarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarMovimiento ventana = new GUIAgregarMovimiento();
            ventana.Show();
        }

        private void listarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarMovimientos ventana = new GUIListarMovimientos();
            ventana.Show();
        }

        private void consultarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIConsultarMovimiento ventana = new GUIConsultarMovimiento();
            ventana.Show();
        }

        private void eliminarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarMovimiento ventana = new GUIEliminarMovimiento();
            ventana.Show();
        }

        private void actualizarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarMovimiento ventana = new GUIActualizarMovimiento();
            ventana.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Versión 3\n\n" +
                "Integrantes:\n" +
                "Karla Lautero\n" +
                "Javier Carvajal\n" +
                "Juan Liberato",
                "Acerca de...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}