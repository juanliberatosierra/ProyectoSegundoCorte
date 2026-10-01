namespace POCCuentaCorriente
{
    partial class GUIActualizarCuenta
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblCuotaManejo;
        private System.Windows.Forms.Label lblTipoCuenta;

        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.TextBox txtFechaApertura;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtCuotaManejo;
        private System.Windows.Forms.TextBox txtTipoCuenta;

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActualizar;

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
            this.lblNumeroCuenta = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblCuotaManejo = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();

            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.txtFechaApertura = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtCuotaManejo = new System.Windows.Forms.TextBox();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();

            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location =
                new System.Drawing.Point(30, 30);
            this.lblNumeroCuenta.Name =
                "lblNumeroCuenta";
            this.lblNumeroCuenta.Size =
                new System.Drawing.Size(120, 16);
            this.lblNumeroCuenta.Text =
                "Número de cuenta:";

            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location =
                new System.Drawing.Point(180, 27);
            this.txtNumeroCuenta.Name =
                "txtNumeroCuenta";
            this.txtNumeroCuenta.Size =
                new System.Drawing.Size(250, 22);

            // 
            // btnBuscar
            // 
            this.btnBuscar.Location =
                new System.Drawing.Point(450, 25);
            this.btnBuscar.Name =
                "btnBuscar";
            this.btnBuscar.Size =
                new System.Drawing.Size(100, 30);
            this.btnBuscar.Text =
                "Buscar";
            this.btnBuscar.UseVisualStyleBackColor =
                true;
            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location =
                new System.Drawing.Point(30, 80);
            this.lblTitular.Name =
                "lblTitular";
            this.lblTitular.Size =
                new System.Drawing.Size(50, 16);
            this.lblTitular.Text =
                "Titular:";

            // 
            // txtTitular
            // 
            this.txtTitular.Location =
                new System.Drawing.Point(180, 77);
            this.txtTitular.Name =
                "txtTitular";
            this.txtTitular.Size =
                new System.Drawing.Size(370, 22);

            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Location =
                new System.Drawing.Point(30, 125);
            this.lblFechaApertura.Name =
                "lblFechaApertura";
            this.lblFechaApertura.Size =
                new System.Drawing.Size(120, 16);
            this.lblFechaApertura.Text =
                "Fecha de apertura:";

            // 
            // txtFechaApertura
            // 
            this.txtFechaApertura.Location =
                new System.Drawing.Point(180, 122);
            this.txtFechaApertura.Name =
                "txtFechaApertura";
            this.txtFechaApertura.Size =
                new System.Drawing.Size(370, 22);

            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location =
                new System.Drawing.Point(30, 170);
            this.lblSaldo.Name =
                "lblSaldo";
            this.lblSaldo.Size =
                new System.Drawing.Size(45, 16);
            this.lblSaldo.Text =
                "Saldo:";

            // 
            // txtSaldo
            // 
            this.txtSaldo.Location =
                new System.Drawing.Point(180, 167);
            this.txtSaldo.Name =
                "txtSaldo";
            this.txtSaldo.Size =
                new System.Drawing.Size(250, 22);

            // 
            // lblCuotaManejo
            // 
            this.lblCuotaManejo.AutoSize = true;
            this.lblCuotaManejo.Location =
                new System.Drawing.Point(30, 215);
            this.lblCuotaManejo.Name =
                "lblCuotaManejo";
            this.lblCuotaManejo.Size =
                new System.Drawing.Size(115, 16);
            this.lblCuotaManejo.Text =
                "Cuota de manejo:";

            // 
            // txtCuotaManejo
            // 
            this.txtCuotaManejo.Location =
                new System.Drawing.Point(180, 212);
            this.txtCuotaManejo.Name =
                "txtCuotaManejo";
            this.txtCuotaManejo.Size =
                new System.Drawing.Size(250, 22);

            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location =
                new System.Drawing.Point(30, 260);
            this.lblTipoCuenta.Name =
                "lblTipoCuenta";
            this.lblTipoCuenta.Size =
                new System.Drawing.Size(90, 16);
            this.lblTipoCuenta.Text =
                "Tipo de cuenta:";

            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.Location =
                new System.Drawing.Point(180, 257);
            this.txtTipoCuenta.Name =
                "txtTipoCuenta";
            this.txtTipoCuenta.Size =
                new System.Drawing.Size(250, 22);

            // 
            // btnActualizar
            // 
            this.btnActualizar.Location =
                new System.Drawing.Point(180, 305);
            this.btnActualizar.Name =
                "btnActualizar";
            this.btnActualizar.Size =
                new System.Drawing.Size(120, 35);
            this.btnActualizar.Text =
                "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor =
                true;
            this.btnActualizar.Click +=
                new System.EventHandler(this.btnActualizar_Click);

            // 
            // GUIActualizarCuenta
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(600, 370);

            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.txtTitular);

            this.Controls.Add(this.lblFechaApertura);
            this.Controls.Add(this.txtFechaApertura);

            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.txtSaldo);

            this.Controls.Add(this.lblCuotaManejo);
            this.Controls.Add(this.txtCuotaManejo);

            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.txtTipoCuenta);

            this.Controls.Add(this.btnActualizar);

            this.Name =
                "GUIActualizarCuenta";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Actualizar Cuenta Corriente";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}