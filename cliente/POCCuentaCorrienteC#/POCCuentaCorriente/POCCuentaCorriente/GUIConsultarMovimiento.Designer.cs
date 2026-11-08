namespace POCCuentaCorriente
{
    partial class GUIConsultarMovimiento
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
            this.lblIdMovimiento = new System.Windows.Forms.Label();
            this.txtIdMovimiento = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.txtTipoMovimiento = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFechaMovimiento = new System.Windows.Forms.Label();
            this.txtFechaMovimiento = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblConfirmado = new System.Windows.Forms.Label();
            this.txtConfirmado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(30, 28);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.TabIndex = 0;
            this.lblNumeroCuenta.Text = "Número de cuenta:";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(190, 25);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(220, 22);
            this.txtNumeroCuenta.TabIndex = 1;
            this.txtNumeroCuenta.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // lblIdMovimiento
            // 
            this.lblIdMovimiento.AutoSize = true;
            this.lblIdMovimiento.Location = new System.Drawing.Point(30, 68);
            this.lblIdMovimiento.Name = "lblIdMovimiento";
            this.lblIdMovimiento.TabIndex = 2;
            this.lblIdMovimiento.Text = "ID del movimiento:";
            // 
            // txtIdMovimiento
            // 
            this.txtIdMovimiento.Location = new System.Drawing.Point(190, 65);
            this.txtIdMovimiento.Name = "txtIdMovimiento";
            this.txtIdMovimiento.Size = new System.Drawing.Size(220, 22);
            this.txtIdMovimiento.TabIndex = 3;
            this.txtIdMovimiento.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(425, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.Location = new System.Drawing.Point(30, 115);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.TabIndex = 5;
            this.lblSeccion.Text = "Información del movimiento";
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(30, 148);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.TabIndex = 6;
            this.lblTipoMovimiento.Text = "Tipo de movimiento:";
            // 
            // txtTipoMovimiento
            // 
            this.txtTipoMovimiento.Location = new System.Drawing.Point(190, 145);
            this.txtTipoMovimiento.Name = "txtTipoMovimiento";
            this.txtTipoMovimiento.ReadOnly = true;
            this.txtTipoMovimiento.Size = new System.Drawing.Size(335, 22);
            this.txtTipoMovimiento.TabIndex = 7;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(30, 188);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.TabIndex = 8;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(190, 185);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(335, 22);
            this.txtMonto.TabIndex = 9;
            // 
            // lblFechaMovimiento
            // 
            this.lblFechaMovimiento.AutoSize = true;
            this.lblFechaMovimiento.Location = new System.Drawing.Point(30, 228);
            this.lblFechaMovimiento.Name = "lblFechaMovimiento";
            this.lblFechaMovimiento.TabIndex = 10;
            this.lblFechaMovimiento.Text = "Fecha del movimiento:";
            // 
            // txtFechaMovimiento
            // 
            this.txtFechaMovimiento.Location = new System.Drawing.Point(190, 225);
            this.txtFechaMovimiento.Name = "txtFechaMovimiento";
            this.txtFechaMovimiento.ReadOnly = true;
            this.txtFechaMovimiento.Size = new System.Drawing.Size(335, 22);
            this.txtFechaMovimiento.TabIndex = 11;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(30, 268);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(190, 265);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(335, 22);
            this.txtDescripcion.TabIndex = 13;
            // 
            // lblConfirmado
            // 
            this.lblConfirmado.AutoSize = true;
            this.lblConfirmado.Location = new System.Drawing.Point(30, 308);
            this.lblConfirmado.Name = "lblConfirmado";
            this.lblConfirmado.TabIndex = 14;
            this.lblConfirmado.Text = "Confirmado:";
            // 
            // txtConfirmado
            // 
            this.txtConfirmado.Location = new System.Drawing.Point(190, 305);
            this.txtConfirmado.Name = "txtConfirmado";
            this.txtConfirmado.ReadOnly = true;
            this.txtConfirmado.Size = new System.Drawing.Size(335, 22);
            this.txtConfirmado.TabIndex = 15;
            // 
            // GUIConsultarMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 345);
            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.lblIdMovimiento);
            this.Controls.Add(this.txtIdMovimiento);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.lblTipoMovimiento);
            this.Controls.Add(this.txtTipoMovimiento);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblFechaMovimiento);
            this.Controls.Add(this.txtFechaMovimiento);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblConfirmado);
            this.Controls.Add(this.txtConfirmado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUIConsultarMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultar movimiento bancario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.Label lblIdMovimiento;
        private System.Windows.Forms.TextBox txtIdMovimiento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.TextBox txtTipoMovimiento;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblFechaMovimiento;
        private System.Windows.Forms.TextBox txtFechaMovimiento;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblConfirmado;
        private System.Windows.Forms.TextBox txtConfirmado;
    }
}
