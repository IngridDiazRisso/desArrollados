// FacturaProveedorDialogForm.Designer.cs
namespace HotelSOL1.FormsAPP
{
    partial class FacturaProveedorDialogForm
    {
        private System.ComponentModel.IContainer components;
        private DataGridView dgvPedidos;
        private DataGridView dgvAlbaranes;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPedidos = new DataGridView();
            this.dgvAlbaranes = new DataGridView();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbaranes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.Location = new Point(12, 12);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new Size(400, 200);
            this.dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.AutoGenerateColumns = true;
            // 
            // dgvAlbaranes
            // 
            this.dgvAlbaranes.Location = new Point(12, 230);
            this.dgvAlbaranes.Name = "dgvAlbaranes";
            this.dgvAlbaranes.Size = new Size(400, 200);
            this.dgvAlbaranes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlbaranes.MultiSelect = false;
            this.dgvAlbaranes.ReadOnly = true;
            this.dgvAlbaranes.AutoGenerateColumns = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new Point(430, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(100, 30);
            this.btnOK.Text = "Aceptar";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(430, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FacturaProveedorDialogForm
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(550, 450);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.dgvAlbaranes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "FacturaProveedorDialogForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nueva Factura Proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbaranes)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
