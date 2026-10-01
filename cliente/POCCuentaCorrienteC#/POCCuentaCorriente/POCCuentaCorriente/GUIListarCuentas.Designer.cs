namespace POCCuentaCorriente
{
    partial class GUIListarCuentas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.ComboBox cmbTipoCuenta;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgvCuentas;

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
            this.lblTitular = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.cmbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();

            this.SuspendLayout();

            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;

            this.lblTitular.Location =
                new System.Drawing.Point(20, 20);

            this.lblTitular.Name =
                "lblTitular";

            this.lblTitular.Size =
                new System.Drawing.Size(50, 15);

            this.lblTitular.Text =
                "Titular:";

            // 
            // txtTitular
            // 
            this.txtTitular.Location =
                new System.Drawing.Point(80, 17);

            this.txtTitular.Name =
                "txtTitular";

            this.txtTitular.Size =
                new System.Drawing.Size(250, 23);

            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;

            this.lblTipoCuenta.Location =
                new System.Drawing.Point(360, 20);

            this.lblTipoCuenta.Name =
                "lblTipoCuenta";

            this.lblTipoCuenta.Size =
                new System.Drawing.Size(90, 15);

            this.lblTipoCuenta.Text =
                "Tipo de cuenta:";

            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbTipoCuenta.FormattingEnabled = true;

            this.cmbTipoCuenta.Location =
                new System.Drawing.Point(460, 17);

            this.cmbTipoCuenta.Name =
                "cmbTipoCuenta";

            this.cmbTipoCuenta.Size =
                new System.Drawing.Size(180, 23);

            // 
            // btnListar
            // 
            this.btnListar.Location =
                new System.Drawing.Point(670, 15);

            this.btnListar.Name =
                "btnListar";

            this.btnListar.Size =
                new System.Drawing.Size(120, 30);

            this.btnListar.Text =
                "Listar";

            this.btnListar.UseVisualStyleBackColor =
                true;

            this.btnListar.Click +=
                new System.EventHandler(this.btnListar_Click);

            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;

            this.dgvCuentas.AllowUserToDeleteRows = false;

            this.dgvCuentas.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCuentas.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvCuentas.Location =
                new System.Drawing.Point(20, 65);

            this.dgvCuentas.Name =
                "dgvCuentas";

            this.dgvCuentas.ReadOnly = true;

            this.dgvCuentas.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvCuentas.Size =
                new System.Drawing.Size(900, 350);

            // 
            // Columnas
            // 

            this.dgvCuentas.Columns.Add(
                "numeroCuenta",
                "Número de cuenta");

            this.dgvCuentas.Columns.Add(
                "titular",
                "Titular");

            this.dgvCuentas.Columns.Add(
                "fechaApertura",
                "Fecha de apertura");

            this.dgvCuentas.Columns.Add(
                "saldo",
                "Saldo");

            this.dgvCuentas.Columns.Add(
                "cuotaManejo",
                "Cuota de manejo");

            this.dgvCuentas.Columns.Add(
                "tipoCuenta",
                "Tipo de cuenta");

            // 
            // GUIListarCuentas
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(940, 450);

            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.cmbTipoCuenta);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.txtTitular);
            this.Controls.Add(this.lblTitular);

            this.Name =
                "GUIListarCuentas";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Listado de Cuentas Corrientes";

            this.Load +=
                new System.EventHandler(this.GUIListarCuentas_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}