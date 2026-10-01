namespace POCCuentaCorriente
{
    partial class GUIAgregarCuenta
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
        private System.Windows.Forms.DateTimePicker dtpFechaApertura;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtCuotaManejo;
        private System.Windows.Forms.ComboBox cmbTipoCuenta;

        private System.Windows.Forms.Button button1;

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
            this.dtpFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtCuotaManejo = new System.Windows.Forms.TextBox();
            this.cmbTipoCuenta = new System.Windows.Forms.ComboBox();

            this.button1 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(40, 30);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(125, 16);
            this.lblNumeroCuenta.Text = "Número de cuenta:";

            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(190, 27);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(250, 22);

            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(40, 70);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(47, 16);
            this.lblTitular.Text = "Titular:";

            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(190, 67);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(250, 22);

            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Location = new System.Drawing.Point(40, 110);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(119, 16);
            this.lblFechaApertura.Text = "Fecha de apertura:";

            // 
            // dtpFechaApertura
            // 
            this.dtpFechaApertura.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtpFechaApertura.Location =
                new System.Drawing.Point(190, 106);

            this.dtpFechaApertura.Name =
                "dtpFechaApertura";

            this.dtpFechaApertura.Size =
                new System.Drawing.Size(250, 22);

            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(40, 150);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(45, 16);
            this.lblSaldo.Text = "Saldo:";

            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(190, 147);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(250, 22);

            // 
            // lblCuotaManejo
            // 
            this.lblCuotaManejo.AutoSize = true;
            this.lblCuotaManejo.Location = new System.Drawing.Point(40, 190);
            this.lblCuotaManejo.Name = "lblCuotaManejo";
            this.lblCuotaManejo.Size = new System.Drawing.Size(104, 16);
            this.lblCuotaManejo.Text = "Cuota de manejo:";

            // 
            // txtCuotaManejo
            // 
            this.txtCuotaManejo.Location = new System.Drawing.Point(190, 187);
            this.txtCuotaManejo.Name = "txtCuotaManejo";
            this.txtCuotaManejo.Size = new System.Drawing.Size(250, 22);

            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(40, 230);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(91, 16);
            this.lblTipoCuenta.Text = "Tipo de cuenta:";

            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbTipoCuenta.FormattingEnabled = true;

            this.cmbTipoCuenta.Items.AddRange(new object[]
            {
                "Empresarial",
                "Personal"
            });

            this.cmbTipoCuenta.Location =
                new System.Drawing.Point(190, 227);

            this.cmbTipoCuenta.Name =
                "cmbTipoCuenta";

            this.cmbTipoCuenta.Size =
                new System.Drawing.Size(250, 24);

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click +=
                new System.EventHandler(this.button1_Click);

            // 
            // GUIAgregarCuenta
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(500, 350);

            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);

            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.txtTitular);

            this.Controls.Add(this.lblFechaApertura);
            this.Controls.Add(this.dtpFechaApertura);

            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.txtSaldo);

            this.Controls.Add(this.lblCuotaManejo);
            this.Controls.Add(this.txtCuotaManejo);

            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.cmbTipoCuenta);

            this.Controls.Add(this.button1);

            this.Name = "GUIAgregarCuenta";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Agregar Cuenta Corriente";

            this.Load +=
                new System.EventHandler(this.GUIAgregarCuenta_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}