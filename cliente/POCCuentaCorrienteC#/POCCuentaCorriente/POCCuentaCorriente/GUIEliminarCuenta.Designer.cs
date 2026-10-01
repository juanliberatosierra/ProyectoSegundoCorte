namespace POCCuentaCorriente
{
    partial class GUIEliminarCuenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblNumeroCuenta = new System.Windows.Forms.Label();
            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();

            this.lblTitular = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();

            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.txtFechaApertura = new System.Windows.Forms.TextBox();

            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();

            this.lblCuotaManejo = new System.Windows.Forms.Label();
            this.txtCuotaManejo = new System.Windows.Forms.TextBox();

            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();

            this.btnEliminar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(30, 30);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(110, 15);
            this.lblNumeroCuenta.Text = "Número de cuenta:";

            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(150, 27);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(180, 23);

            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(345, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 27);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(30, 75);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(42, 15);
            this.lblTitular.Text = "Titular:";

            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(150, 72);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.ReadOnly = true;
            this.txtTitular.Size = new System.Drawing.Size(285, 23);

            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Location = new System.Drawing.Point(30, 115);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(105, 15);
            this.lblFechaApertura.Text = "Fecha de apertura:";

            // 
            // txtFechaApertura
            // 
            this.txtFechaApertura.Location = new System.Drawing.Point(150, 112);
            this.txtFechaApertura.Name = "txtFechaApertura";
            this.txtFechaApertura.ReadOnly = true;
            this.txtFechaApertura.Size = new System.Drawing.Size(285, 23);

            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(30, 155);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(38, 15);
            this.lblSaldo.Text = "Saldo:";

            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(150, 152);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(285, 23);

            // 
            // lblCuotaManejo
            // 
            this.lblCuotaManejo.AutoSize = true;
            this.lblCuotaManejo.Location = new System.Drawing.Point(30, 195);
            this.lblCuotaManejo.Name = "lblCuotaManejo";
            this.lblCuotaManejo.Size = new System.Drawing.Size(94, 15);
            this.lblCuotaManejo.Text = "Cuota de manejo:";

            // 
            // txtCuotaManejo
            // 
            this.txtCuotaManejo.Location = new System.Drawing.Point(150, 192);
            this.txtCuotaManejo.Name = "txtCuotaManejo";
            this.txtCuotaManejo.ReadOnly = true;
            this.txtCuotaManejo.Size = new System.Drawing.Size(285, 23);

            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(30, 235);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(85, 15);
            this.lblTipoCuenta.Text = "Tipo de cuenta:";

            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.Location = new System.Drawing.Point(150, 232);
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.ReadOnly = true;
            this.txtTipoCuenta.Size = new System.Drawing.Size(285, 23);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(150, 280);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(285, 35);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // GUIEliminarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 350);

            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtTipoCuenta);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.txtCuotaManejo);
            this.Controls.Add(this.lblCuotaManejo);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.txtFechaApertura);
            this.Controls.Add(this.lblFechaApertura);
            this.Controls.Add(this.txtTitular);
            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.lblNumeroCuenta);

            this.Name = "GUIEliminarCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Cuenta Corriente";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.Button btnBuscar;

        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.TextBox txtTitular;

        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.TextBox txtFechaApertura;

        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtSaldo;

        private System.Windows.Forms.Label lblCuotaManejo;
        private System.Windows.Forms.TextBox txtCuotaManejo;

        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.TextBox txtTipoCuenta;

        private System.Windows.Forms.Button btnEliminar;
    }
}