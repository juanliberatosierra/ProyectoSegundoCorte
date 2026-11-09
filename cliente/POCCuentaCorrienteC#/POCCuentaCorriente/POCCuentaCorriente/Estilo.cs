using System;
using System.Drawing;
using System.Windows.Forms;

namespace POCCuentaCorriente
{
    // Aplica el diseño visual del banco a todas las ventanas.
    // Solo cambia colores, fuentes y encabezados; no toca la lógica.
    public static class Estilo
    {
        // Colores
        public static readonly Color AzulOscuro = Color.FromArgb(11, 37, 69);
        public static readonly Color AzulMedio = Color.FromArgb(19, 64, 122);
        public static readonly Color Dorado = Color.FromArgb(200, 162, 74);
        public static readonly Color Fondo = Color.FromArgb(244, 246, 249);
        public static readonly Color GrisBorde = Color.FromArgb(197, 204, 214);
        public static readonly Color TextoOscuro = Color.FromArgb(40, 44, 52);
        public static readonly Color TextoSuave = Color.FromArgb(184, 199, 221);

        // Fuentes: Bahnschrift para títulos y botones, Segoe UI para campos
        public static readonly Font FuenteTitulo = new Font("Bahnschrift", 17F, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Bahnschrift", 10F, FontStyle.Regular);
        public static readonly Font FuenteBoton = new Font("Bahnschrift", 10F, FontStyle.Regular);
        public static readonly Font FuenteMenu = new Font("Bahnschrift", 10F, FontStyle.Regular);
        public static readonly Font FuenteTarjeta = new Font("Bahnschrift", 12F, FontStyle.Bold);
        public static readonly Font FuenteTexto = new Font("Segoe UI", 9F, FontStyle.Regular);

        private const int AltoEncabezado = 80;

        // ===================== VENTANAS DE CASO DE USO =====================

        public static void Aplicar(Form ventana, string subtitulo)
        {
            ventana.BackColor = Fondo;
            ventana.Font = FuenteTexto;

            // Estilo de cada control existente (y de los que estén dentro de paneles)
            AplicarAControles(ventana.Controls);

            // Bajar los controles existentes para dejar espacio al encabezado
            foreach (Control c in ventana.Controls)
            {
                if (c.Dock == DockStyle.None)
                {
                    c.Top += AltoEncabezado;
                }
            }

            ventana.ClientSize = new Size(
                ventana.ClientSize.Width,
                ventana.ClientSize.Height + AltoEncabezado);

            // Encabezado azul con el título de la ventana
            Panel encabezado = CrearEncabezado(ventana.Text, subtitulo);
            ventana.Controls.Add(encabezado);
            encabezado.SendToBack();
        }

        private static Panel CrearEncabezado(string titulo, string subtitulo)
        {
            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = AltoEncabezado;
            encabezado.BackColor = AzulOscuro;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = FuenteTitulo;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(24, 14);

            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = subtitulo;
            lblSubtitulo.Font = FuenteSubtitulo;
            lblSubtitulo.ForeColor = TextoSuave;
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(26, 48);

            // Línea dorada inferior
            Panel linea = new Panel();
            linea.Dock = DockStyle.Bottom;
            linea.Height = 3;
            linea.BackColor = Dorado;

            encabezado.Controls.Add(lblTitulo);
            encabezado.Controls.Add(lblSubtitulo);
            encabezado.Controls.Add(linea);

            return encabezado;
        }

        private static void AplicarAControles(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is Button)
                {
                    EstiloBoton((Button)c);
                }
                else if (c is DataGridView)
                {
                    EstiloTabla((DataGridView)c);
                }
                else if (c is TextBox || c is ComboBox || c is NumericUpDown || c is DateTimePicker)
                {
                    c.Font = FuenteTexto;
                    c.ForeColor = TextoOscuro;
                }
                else if (c is GroupBox)
                {
                    c.BackColor = Color.White;
                    c.ForeColor = AzulOscuro;
                    c.Font = FuenteBoton;
                    AplicarAControles(c.Controls);
                    // Los controles internos vuelven a la fuente normal
                    foreach (Control hijo in c.Controls)
                    {
                        if (!(hijo is Button)) { hijo.ForeColor = TextoOscuro; }
                    }
                }
                else if (c is Label || c is CheckBox || c is RadioButton)
                {
                    c.Font = FuenteTexto;
                    c.ForeColor = TextoOscuro;
                }
                else if (c.HasChildren)
                {
                    AplicarAControles(c.Controls);
                }
            }
        }

        private static void EstiloBoton(Button boton)
        {
            string texto = boton.Text.ToLower();
            bool secundario =
                texto.Contains("limpiar") || texto.Contains("cancelar") ||
                texto.Contains("cerrar") || texto.Contains("volver") ||
                texto.Contains("salir");

            boton.FlatStyle = FlatStyle.Flat;
            boton.Font = FuenteBoton;
            boton.Cursor = Cursors.Hand;

            if (secundario)
            {
                boton.BackColor = Color.White;
                boton.ForeColor = TextoOscuro;
                boton.FlatAppearance.BorderColor = GrisBorde;
                boton.FlatAppearance.BorderSize = 1;
            }
            else
            {
                boton.BackColor = AzulMedio;
                boton.ForeColor = Color.White;
                boton.FlatAppearance.BorderSize = 0;
                boton.FlatAppearance.MouseOverBackColor = AzulOscuro;
            }
        }

        private static void EstiloTabla(DataGridView tabla)
        {
            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.GridColor = Color.FromArgb(225, 230, 236);
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = AzulOscuro;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = FuenteBoton;
            tabla.ColumnHeadersHeight = 34;
            tabla.DefaultCellStyle.Font = FuenteTexto;
            tabla.DefaultCellStyle.ForeColor = TextoOscuro;
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
            tabla.DefaultCellStyle.SelectionForeColor = TextoOscuro;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            tabla.RowHeadersVisible = false;
        }

        // ===================== VENTANA PRINCIPAL =====================

        public static void AplicarPrincipal(Form ventana, MenuStrip menu)
        {
            ventana.BackColor = Fondo;
            ventana.Font = FuenteTexto;
            ventana.Text = "Banco POC — Sistema de Cuentas Corrientes";
            ventana.ClientSize = new Size(760, 420);
            ventana.StartPosition = FormStartPosition.CenterScreen;

            // Menú azul
            menu.BackColor = AzulOscuro;
            menu.Font = FuenteMenu;
            menu.Renderer = new ToolStripProfessionalRenderer(new ColoresMenu());
            foreach (ToolStripMenuItem item in menu.Items)
            {
                item.ForeColor = Color.FromArgb(230, 236, 245);
                foreach (ToolStripItem sub in item.DropDownItems)
                {
                    sub.ForeColor = TextoOscuro;
                    sub.Font = FuenteTexto;
                }
            }

            // Barra inferior
            Label barra = new Label();
            barra.Dock = DockStyle.Bottom;
            barra.Height = 28;
            barra.BackColor = Color.FromArgb(233, 237, 242);
            barra.ForeColor = Color.FromArgb(85, 85, 102);
            barra.Font = FuenteTexto;
            barra.TextAlign = ContentAlignment.MiddleLeft;
            barra.Padding = new Padding(10, 0, 0, 0);
            barra.Text = "Servidor: http://localhost:8081/graphql   ·   Versión 3.0";

            // Tarjetas
            Panel tarjetaCuentas = CrearTarjeta(
                "Cuentas corrientes",
                "Agregar, consultar, listar, actualizar y eliminar cuentas",
                new Point(28, AltoEncabezado + 50));

            Panel tarjetaMovimientos = CrearTarjeta(
                "Movimientos bancarios",
                "Registrar depósitos y retiros asociados a una cuenta",
                new Point(392, AltoEncabezado + 50));

            // Encabezado de bienvenida (debajo del menú)
            Panel encabezado = CrearEncabezado(
                "Bienvenido al Sistema Bancario",
                "Seleccione una opción del menú para comenzar");
            encabezado.Height = AltoEncabezado + 10;

            ventana.Controls.Add(tarjetaCuentas);
            ventana.Controls.Add(tarjetaMovimientos);
            ventana.Controls.Add(barra);
            ventana.Controls.Add(encabezado);

            // Orden de acoplado: el menú queda arriba de todo y el encabezado debajo
            encabezado.SendToBack();
            menu.SendToBack();
        }

        private static Panel CrearTarjeta(string titulo, string descripcion, Point ubicacion)
        {
            Panel tarjeta = new Panel();
            tarjeta.BackColor = Color.White;
            tarjeta.Size = new Size(340, 100);
            tarjeta.Location = ubicacion;

            Panel bordeDorado = new Panel();
            bordeDorado.Dock = DockStyle.Left;
            bordeDorado.Width = 5;
            bordeDorado.BackColor = Dorado;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = FuenteTarjeta;
            lblTitulo.ForeColor = AzulOscuro;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 18);

            Label lblDescripcion = new Label();
            lblDescripcion.Text = descripcion;
            lblDescripcion.Font = FuenteTexto;
            lblDescripcion.ForeColor = Color.FromArgb(102, 102, 119);
            lblDescripcion.Location = new Point(20, 48);
            lblDescripcion.Size = new Size(305, 40);

            tarjeta.Controls.Add(lblTitulo);
            tarjeta.Controls.Add(lblDescripcion);
            tarjeta.Controls.Add(bordeDorado);

            return tarjeta;
        }

        // Colores del menú al pasar el mouse
        private class ColoresMenu : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return AzulMedio; } }
            public override Color MenuItemSelectedGradientBegin { get { return AzulMedio; } }
            public override Color MenuItemSelectedGradientEnd { get { return AzulMedio; } }
            public override Color MenuItemPressedGradientBegin { get { return AzulMedio; } }
            public override Color MenuItemPressedGradientEnd { get { return AzulMedio; } }
            public override Color MenuItemBorder { get { return AzulMedio; } }
            public override Color MenuBorder { get { return GrisBorde; } }
            public override Color ToolStripDropDownBackground { get { return Color.White; } }
            public override Color ImageMarginGradientBegin { get { return Color.White; } }
            public override Color ImageMarginGradientMiddle { get { return Color.White; } }
            public override Color ImageMarginGradientEnd { get { return Color.White; } }
        }
    }
}