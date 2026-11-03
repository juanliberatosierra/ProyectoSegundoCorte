namespace POCCuentaCorriente
{
    partial class GUIListarMovimientos
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
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colIdMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfirmado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(20, 23);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.TabIndex = 0;
            this.lblNumeroCuenta.Text = "Número de cuenta:";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(155, 20);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(130, 22);
            this.txtNumeroCuenta.TabIndex = 1;
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(305, 23);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.TabIndex = 2;
            this.lblTipoMovimiento.Text = "Tipo de movimiento:";
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Items.AddRange(new object[] {
            "Todos",
            "DEPOSITO",
            "RETIRO"});
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(450, 20);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(150, 24);
            this.cmbTipoMovimiento.TabIndex = 3;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(620, 17);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(110, 28);
            this.btnListar.TabIndex = 4;
            this.btnListar.Text = "Filtrar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(740, 17);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(130, 28);
            this.btnLimpiarFiltros.TabIndex = 5;
            this.btnLimpiarFiltros.Text = "Quitar filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdMovimiento,
            this.colNumeroCuenta,
            this.colTitular,
            this.colTipoCuenta,
            this.colTipoMovimiento,
            this.colMonto,
            this.colFecha,
            this.colDescripcion,
            this.colConfirmado});
            this.dgvMovimientos.Location = new System.Drawing.Point(20, 60);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(960, 410);
            this.dgvMovimientos.TabIndex = 6;
            // 
            // colIdMovimiento
            // 
            this.colIdMovimiento.FillWeight = 45F;
            this.colIdMovimiento.HeaderText = "ID";
            this.colIdMovimiento.Name = "colIdMovimiento";
            this.colIdMovimiento.ReadOnly = true;
            // 
            // colNumeroCuenta
            // 
            this.colNumeroCuenta.FillWeight = 65F;
            this.colNumeroCuenta.HeaderText = "Cuenta";
            this.colNumeroCuenta.Name = "colNumeroCuenta";
            this.colNumeroCuenta.ReadOnly = true;
            // 
            // colTitular
            // 
            this.colTitular.FillWeight = 130F;
            this.colTitular.HeaderText = "Titular";
            this.colTitular.Name = "colTitular";
            this.colTitular.ReadOnly = true;
            // 
            // colTipoCuenta
            // 
            this.colTipoCuenta.FillWeight = 95F;
            this.colTipoCuenta.HeaderText = "Tipo de cuenta";
            this.colTipoCuenta.Name = "colTipoCuenta";
            this.colTipoCuenta.ReadOnly = true;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.FillWeight = 80F;
            this.colTipoMovimiento.HeaderText = "Tipo";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.ReadOnly = true;
            // 
            // colMonto
            // 
            this.colMonto.FillWeight = 95F;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.FillWeight = 115F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FillWeight = 160F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colConfirmado
            // 
            this.colConfirmado.FillWeight = 70F;
            this.colConfirmado.HeaderText = "Confirmado";
            this.colConfirmado.Name = "colConfirmado";
            this.colConfirmado.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(20, 485);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total de movimientos: 0";
            // 
            // GUIListarMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.lblNumeroCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.lblTipoMovimiento);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.lblTotal);
            this.MinimumSize = new System.Drawing.Size(1000, 520);
            this.Name = "GUIListarMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de movimientos bancarios";
            this.Load += new System.EventHandler(this.GUIListarMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitular;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfirmado;
        private System.Windows.Forms.Label lblTotal;
    }
}
