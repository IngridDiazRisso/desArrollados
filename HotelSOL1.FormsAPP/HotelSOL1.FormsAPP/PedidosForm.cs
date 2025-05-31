// HotelSOL1.FormsAPP/PedidosForm.cs
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore; // <- para Include, si lo necesitaras aquí

namespace HotelSOL1.FormsAPP
{
    public partial class PedidosForm : Form
    {
        private readonly PedidoService _service;
        private readonly BindingSource _bs = new BindingSource();
        private BindingList<Pedido> _lista = null!;

        public PedidosForm(PedidoService service)
        {
            InitializeComponent();
            _service = service;

            this.Load += PedidosForm_Load;
            btnCrearPedido.Click += BtnCrearPedido_Click;
            btnEliminarPedido.Click += BtnEliminarPedido_Click;
            btnVolver.Click += (_, __) => Close();
        }

        private void PedidosForm_Load(object sender, EventArgs e)
        {
            // 1) obtenemos ya con Include(proveedor)
            var datos = _service.GetAll();
            _lista = new BindingList<Pedido>(datos);
            _bs.DataSource = _lista;
            dgvPedidos.DataSource = _bs;

            // 2) Ajustes de columnas
            if (dgvPedidos.Columns["Id"] != null)
                dgvPedidos.Columns["Id"].HeaderText = "ID";

            // Esta columna la vamos a enlazar al Nombre del proveedor
            if (dgvPedidos.Columns["Proveedor"] != null)
            {
                var colProv = dgvPedidos.Columns["Proveedor"];
                colProv.HeaderText = "Proveedor";
                colProv.DataPropertyName = "Proveedor.Nombre";
            }

            // Ocultamos las propiedades de navegación que no hacen falta
            if (dgvPedidos.Columns["Albaranes"] != null)
                dgvPedidos.Columns["Albaranes"].Visible = false;
            if (dgvPedidos.Columns["FacturasProveedores"] != null)
                dgvPedidos.Columns["FacturasProveedores"].Visible = false;
        }

        private void BtnCrearPedido_Click(object sender, EventArgs e)
        {
            using var dlg = new PedidoDialogForm(_service);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _service.Add(dlg.PedidoItem);
                _lista.Add(dlg.PedidoItem);
            }
        }

        private void BtnEliminarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;
            var sel = (Pedido)dgvPedidos.CurrentRow.DataBoundItem!;
            if (MessageBox.Show(
                    $"¿Eliminar pedido #{sel.Id}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                _service.Delete(sel.Id);
                _lista.Remove(sel);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
