using System;
using System.Windows.Forms;

namespace POCCuentaCorriente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarCuenta ventana = new GUIAgregarCuenta();
            ventana.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarCuentas ventana = new GUIListarCuentas();
            ventana.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIConsultarCuenta ventana = new GUIConsultarCuenta();
            ventana.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarCuenta ventana = new GUIEliminarCuenta();
            ventana.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarCuenta ventana = new GUIActualizarCuenta();
            ventana.ShowDialog();
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