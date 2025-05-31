using System.ComponentModel;

namespace HotelSOL1.FormsAPP
{
    partial class FacturaProveedorForm
    {
        private System.ComponentModel.IContainer components;
        private DataGridView dgvFacturasProv;
        private Button btnGenerarFact;
        private Button btnVerFactura;
        private Button btnVolver;
        private BindingSource facturaProveedorBindingSource;
        private Button btnNuevoAlbaran;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FacturaProveedorForm));
            facturaProveedorBindingSource = new BindingSource(components);
            dgvFacturasProv = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnGenerarFact = new Button();
            btnVerFactura = new Button();
            btnVolver = new Button();
            btnNuevoAlbaran = new Button();
            ((ISupportInitialize)facturaProveedorBindingSource).BeginInit();
            ((ISupportInitialize)dgvFacturasProv).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturasProv
            // 
            dgvFacturasProv.AutoGenerateColumns = false;
            dgvFacturasProv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturasProv.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvFacturasProv.DataSource = facturaProveedorBindingSource;
            dgvFacturasProv.Location = new Point(24, 56);
            dgvFacturasProv.Name = "dgvFacturasProv";
            dgvFacturasProv.RowHeadersWidth = 51;
            dgvFacturasProv.Size = new Size(970, 505);
            dgvFacturasProv.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // btnGenerarFact
            // 
            btnGenerarFact.Location = new Point(1019, 66);
            btnGenerarFact.Name = "btnGenerarFact";
            btnGenerarFact.Size = new Size(140, 40);
            btnGenerarFact.TabIndex = 1;
            btnGenerarFact.Text = "Generar factura";
            btnGenerarFact.UseVisualStyleBackColor = true;
            // 
            // btnVerFactura
            // 
            btnVerFactura.Location = new Point(1019, 126);
            btnVerFactura.Name = "btnVerFactura";
            btnVerFactura.Size = new Size(140, 40);
            btnVerFactura.TabIndex = 2;
            btnVerFactura.Text = "Ver factura";
            btnVerFactura.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(1019, 186);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(140, 40);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnNuevoAlbaran
            // 
            btnNuevoAlbaran.Location = new Point(1019, 244);
            btnNuevoAlbaran.Name = "btnNuevoAlbaran";
            btnNuevoAlbaran.Size = new Size(140, 40);
            btnNuevoAlbaran.TabIndex = 4;
            btnNuevoAlbaran.Text = "Ver Albaranes";
            btnNuevoAlbaran.UseVisualStyleBackColor = true;
            // 
            // FacturaProveedorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1258, 626);
            Controls.Add(dgvFacturasProv);
            Controls.Add(btnGenerarFact);
            Controls.Add(btnVerFactura);
            Controls.Add(btnVolver);
            Controls.Add(btnNuevoAlbaran);
            Name = "FacturaProveedorForm";
            Text = "Facturas de Proveedores";
            ((ISupportInitialize)facturaProveedorBindingSource).EndInit();
            ((ISupportInitialize)dgvFacturasProv).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
