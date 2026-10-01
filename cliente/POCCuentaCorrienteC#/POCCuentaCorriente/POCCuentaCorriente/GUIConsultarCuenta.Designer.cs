namespace POCCuentaCorriente
{
    partial class GUIConsultarCuenta
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

        private System.Windows.Forms.Button btnConsultar;

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

            this.btnConsultar = new System.Windows.Forms.Button();

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
            // btnConsultar
            // 
            this.btnConsultar.Location =
                new System.Drawing.Point(450, 25);
            this.btnConsultar.Name =
                "btnConsultar";
            this.btnConsultar.Size =
                new System.Drawing.Size(120, 30);
            this.btnConsultar.Text =
                "Consultar";
            this.btnConsultar.UseVisualStyleBackColor =
                true;
            this.btnConsultar.Click +=
                new System.EventHandler(this.btnConsultar_Click);

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
            this.txtTitular.ReadOnly =
                true;
            this.txtTitular.Size =
                new System.Drawing.Size(390, 22);

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
            this.txtFechaApertura.ReadOnly =
                true;
            this.txtFechaApertura.Size =
                new System.Drawing.Size(390, 22);

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
            this.txtSaldo.ReadOnly =
                true;
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
            this.txtCuotaManejo.ReadOnly =
                true;
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
            this.txtTipoCuenta.ReadOnly =
                true;
            this.txtTipoCuenta.Size =
                new System.Drawing.Size(250, 22);

            // 
            // GUIConsultarCuenta
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(620, 320);

            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.btnConsultar);

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

            this.Name =
                "GUIConsultarCuenta";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Consultar Cuenta Corriente";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}