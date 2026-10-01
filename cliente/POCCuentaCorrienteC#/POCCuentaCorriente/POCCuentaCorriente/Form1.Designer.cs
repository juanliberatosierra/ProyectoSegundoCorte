namespace POCCuentaCorriente
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem cuentaCorrienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();

            this.archivoToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.salirToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.cuentaCorrienteToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.adicionarToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.listarToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.consultarToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.eliminarToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.actualizarToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.ayudaToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.acercaDeToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.archivoToolStripMenuItem,
                    this.cuentaCorrienteToolStripMenuItem,
                    this.ayudaToolStripMenuItem
                });

            this.menuStrip1.Location =
                new System.Drawing.Point(0, 0);

            this.menuStrip1.Name =
                "menuStrip1";

            this.menuStrip1.Size =
                new System.Drawing.Size(700, 28);

            this.menuStrip1.TabIndex = 0;

            // 
            // Archivo
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.salirToolStripMenuItem
                });

            this.archivoToolStripMenuItem.Name =
                "archivoToolStripMenuItem";

            this.archivoToolStripMenuItem.Size =
                new System.Drawing.Size(73, 24);

            this.archivoToolStripMenuItem.Text =
                "Archivo";

            // 
            // Salir
            // 
            this.salirToolStripMenuItem.Name =
                "salirToolStripMenuItem";

            this.salirToolStripMenuItem.Size =
                new System.Drawing.Size(110, 24);

            this.salirToolStripMenuItem.Text =
                "Salir";

            this.salirToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.salirToolStripMenuItem_Click);

            // 
            // Cuenta Corriente
            // 
            this.cuentaCorrienteToolStripMenuItem.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.adicionarToolStripMenuItem,
                    this.listarToolStripMenuItem,
                    this.consultarToolStripMenuItem,
                    this.eliminarToolStripMenuItem,
                    this.actualizarToolStripMenuItem
                });

            this.cuentaCorrienteToolStripMenuItem.Name =
                "cuentaCorrienteToolStripMenuItem";

            this.cuentaCorrienteToolStripMenuItem.Size =
                new System.Drawing.Size(130, 24);

            this.cuentaCorrienteToolStripMenuItem.Text =
                "Cuenta Corriente";

            // 
            // Adicionar
            // 
            this.adicionarToolStripMenuItem.Name =
                "adicionarToolStripMenuItem";

            this.adicionarToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.adicionarToolStripMenuItem.Text =
                "Adicionar";

            this.adicionarToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.adicionarToolStripMenuItem_Click);

            // 
            // Listar
            // 
            this.listarToolStripMenuItem.Name =
                "listarToolStripMenuItem";

            this.listarToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.listarToolStripMenuItem.Text =
                "Listar";

            this.listarToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.listarToolStripMenuItem_Click);

            // 
            // Consultar
            // 
            this.consultarToolStripMenuItem.Name =
                "consultarToolStripMenuItem";

            this.consultarToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.consultarToolStripMenuItem.Text =
                "Consultar";

            this.consultarToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.consultarToolStripMenuItem_Click);

            // 
            // Eliminar
            // 
            this.eliminarToolStripMenuItem.Name =
                "eliminarToolStripMenuItem";

            this.eliminarToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.eliminarToolStripMenuItem.Text =
                "Eliminar";

            this.eliminarToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.eliminarToolStripMenuItem_Click);

            // 
            // Actualizar
            // 
            this.actualizarToolStripMenuItem.Name =
                "actualizarToolStripMenuItem";

            this.actualizarToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.actualizarToolStripMenuItem.Text =
                "Actualizar";

            this.actualizarToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.actualizarToolStripMenuItem_Click);

            // 
            // Ayuda
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.acercaDeToolStripMenuItem
                });

            this.ayudaToolStripMenuItem.Name =
                "ayudaToolStripMenuItem";

            this.ayudaToolStripMenuItem.Size =
                new System.Drawing.Size(65, 24);

            this.ayudaToolStripMenuItem.Text =
                "Ayuda";

            // 
            // Acerca de...
            // 
            this.acercaDeToolStripMenuItem.Name =
                "acercaDeToolStripMenuItem";

            this.acercaDeToolStripMenuItem.Size =
                new System.Drawing.Size(150, 24);

            this.acercaDeToolStripMenuItem.Text =
                "Acerca de...";

            this.acercaDeToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.acercaDeToolStripMenuItem_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(700, 400);

            this.Controls.Add(this.menuStrip1);

            this.MainMenuStrip =
                this.menuStrip1;

            this.Name =
                "Form1";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Ventana Principal";

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}