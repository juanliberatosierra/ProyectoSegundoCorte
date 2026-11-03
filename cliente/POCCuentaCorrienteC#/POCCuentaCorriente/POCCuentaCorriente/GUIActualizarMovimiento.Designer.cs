namespace POCCuentaCorriente
{
    partial class GUIActualizarMovimiento
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
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFechaMovimiento = new System.Windows.Forms.Label();
            this.dtpFechaMovimiento = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.chkConfirmado = new System.Windows.Forms.CheckBox();
            this.btnActualizar = new System.Windows.Forms.Button();
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
            this.lblSeccion.Text = "Datos del movimiento (editables)";
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(30, 148);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.TabIndex = 6;
            this.lblTipoMovimiento.Text = "Tipo de movimiento:";
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Items.AddRange(new object[] {
            "DEPOSITO",
            "RETIRO"});
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(190, 145);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(220, 22);
            this.cmbTipoMovimiento.TabIndex = 7;
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
            this.txtMonto.Size = new System.Drawing.Size(220, 22);
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
            // dtpFechaMovimiento
            // 
            this.dtpFechaMovimiento.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaMovimiento.Location = new System.Drawing.Point(190, 225);
            this.dtpFechaMovimiento.Name = "dtpFechaMovimiento";
            this.dtpFechaMovimiento.Size = new System.Drawing.Size(220, 22);
            this.dtpFechaMovimiento.TabIndex = 11;
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
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(335, 22);
            this.txtDescripcion.TabIndex = 13;
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.AutoSize = true;
            this.chkConfirmado.Location = new System.Drawing.Point(190, 307);
            this.chkConfirmado.Name = "chkConfirmado";
            this.chkConfirmado.TabIndex = 14;
            this.chkConfirmado.Text = "Movimiento confirmado";
            this.chkConfirmado.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(190, 355);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 32);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.Text = "Guardar cambios";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // GUIActualizarMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 420);
            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.lblIdMovimiento);
            this.Controls.Add(this.txtIdMovimiento);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.lblTipoMovimiento);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblFechaMovimiento);
            this.Controls.Add(this.dtpFechaMovimiento);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.chkConfirmado);
            this.Controls.Add(this.btnActualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUIActualizarMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar movimiento bancario";
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
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblFechaMovimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaMovimiento;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkConfirmado;
        private System.Windows.Forms.Button btnActualizar;
    }
}
