namespace HotelSOL1.FormsAPP
{
    partial class AlbaranDialogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.BindingSource pedidoBindingSource;
        private System.Windows.Forms.Button btnCrearAlbaran;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnCrearAlbaran = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            var colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            var colProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            var colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoBindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AutoGenerateColumns = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // Id
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID Pedido";
            colId.Width = 80;
            // IdProveedor
            colProv.DataPropertyName = "IdProveedor";
            colProv.HeaderText = "ID Proveedor";
            colProv.Width = 100;
            // PrecioTotal
            colTotal.DataPropertyName = "PrecioTotal";
            colTotal.HeaderText = "Importe";
            colTotal.Width = 120;
            // añadir columnas
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colId, colProv, colTotal
            });
            this.dgvPedidos.DataSource = this.pedidoBindingSource;
            this.dgvPedidos.Location = new System.Drawing.Point(12, 12);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.Size = new System.Drawing.Size(360, 200);
            this.dgvPedidos.TabIndex = 0;

            // 
            // btnCrearAlbaran
            // 
            this.btnCrearAlbaran.Location = new System.Drawing.Point(12, 230);
            this.btnCrearAlbaran.Name = "btnCrearAlbaran";
            this.btnCrearAlbaran.Size = new System.Drawing.Size(120, 35);
            this.btnCrearAlbaran.TabIndex = 1;
            this.btnCrearAlbaran.Text = "Crear Albarán";
            this.btnCrearAlbaran.UseVisualStyleBackColor = true;

            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(252, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;

            // 
            // AlbaranDialogForm
            // 
            this.AcceptButton = this.btnCrearAlbaran;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnCrearAlbaran);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlbaranDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Pedido";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoBindingSource)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
