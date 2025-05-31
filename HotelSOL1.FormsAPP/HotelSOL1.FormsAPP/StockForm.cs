using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL1.FormsAPP;
using System.ComponentModel;
using System;
namespace HotelSOL1.FormsAPP
{
    public partial class StockForm : Form
    {
        private readonly StockService _stockService;
        private BindingList<Stock> _listaStock = null!;

        public StockForm(StockService stockService)
        {
            InitializeComponent();
            _stockService = stockService;

            // Conectar eventos aquí (o en el diseñador)
            btnAnadir.Click += BtnAnadir_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnVolver.Click += (_, __) => Close();
            this.Load += StockForm_Load;
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            try
            {
                var stock = _stockService.ObtenerStock();
                _listaStock = new BindingList<Stock>(stock);
                stockBindingSource.DataSource = _listaStock;
                dgvStock.DataSource = stockBindingSource;

                // Configurar encabezados...
                if (dgvStock.Columns["id"] != null)
                    dgvStock.Columns["id"].HeaderText = "ID Stock";
                if (dgvStock.Columns["NombreProducto"] != null)
                    dgvStock.Columns["NombreProducto"].HeaderText = "Nombre Producto";
                if (dgvStock.Columns["Familia"] != null)
                    dgvStock.Columns["Familia"].HeaderText = "Tipo de producto";
                if (dgvStock.Columns["CantidadRestante"] != null)
                    dgvStock.Columns["CantidadRestante"].HeaderText = "Cantidad restante";
                if (dgvStock.Columns["Pvp"] != null)
                    dgvStock.Columns["Pvp"].HeaderText = "PVP";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el stock: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            using var dlg = new StockDialogForm();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            var nuevo = dlg.StockItem;
            _stockService.Add(nuevo);
            _listaStock.Add(nuevo);
            dgvStock.CurrentCell = dgvStock.Rows[^1].Cells[0];
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow == null) return;
            var original = (Stock)dgvStock.CurrentRow.DataBoundItem!;
            // Hacemos una copia para no tocar la lista si cancela:
            var copia = new Stock
            {
                id = original.id,
                NombreProducto = original.NombreProducto,
                Familia = original.Familia,
                CantidadRestante = original.CantidadRestante,
                Pvp = original.Pvp
            };

            using var dlg = new StockDialogForm(copia);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            // Volcar los cambios sobre el original:
            original.NombreProducto = dlg.StockItem.NombreProducto;
            original.Familia = dlg.StockItem.Familia;
            original.CantidadRestante = dlg.StockItem.CantidadRestante;
            original.Pvp = dlg.StockItem.Pvp;

            _stockService.Update(original);
            dgvStock.Refresh();  // Fuerza repaint
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow == null) return;
            var sel = (Stock)dgvStock.CurrentRow.DataBoundItem!;
            if (MessageBox.Show($"¿Eliminar «{sel.NombreProducto}»?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            _stockService.Delete(sel.id);
            _listaStock.Remove(sel);
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
