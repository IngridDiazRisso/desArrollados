// FacturaProveedorDialogForm.cs
using System;
using System.Windows.Forms;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class FacturaProveedorDialogForm : Form
    {
        private readonly PedidoService _pedidoService;
        private readonly AlbaranService _albaranService;

        public FacturaProveedor FacturaItem { get; private set; }

        public FacturaProveedorDialogForm(
            PedidoService pedidoService,
            AlbaranService albaranService)
        {
            InitializeComponent();

            _pedidoService = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
            _albaranService = albaranService ?? throw new ArgumentNullException(nameof(albaranService));

            // 1) Suscribimos evento de selección antes de asignar DataSource
            dgvPedidos.SelectionChanged += DgvPedidos_SelectionChanged;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            // 2) Cargamos pedidos
            dgvPedidos.DataSource = _pedidoService.GetAll();
        }

        private void DgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow?.DataBoundItem is Pedido pedido)
            {
                // 3) Cuando cambia el pedido, recargamos los albaranes
                dgvAlbaranes.DataSource = _albaranService.GetByPedidoId(pedido.Id);
            }
            else
            {
                dgvAlbaranes.DataSource = null;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!(dgvPedidos.CurrentRow?.DataBoundItem is Pedido selPedido))
            {
                MessageBox.Show("Debes seleccionar un pedido.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(dgvAlbaranes.CurrentRow?.DataBoundItem is Albaran selAlbaran))
            {
                MessageBox.Show("Debes seleccionar un albarán.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FacturaItem = new FacturaProveedor
            {
                IdProveedor = selPedido.IdProveedor,
                IdPedido = selPedido.Id,
                IdAlbaran = selAlbaran.Id
            };
            DialogResult = DialogResult.OK;
        }
    }
}
