using System;
using System.ComponentModel;
using System.Windows.Forms;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class AlbaranDialogForm : Form
    {
        private readonly PedidoService _pedidoSvc;
        private readonly AlbaranService _albaranSvc;
        private BindingList<Pedido> _pedidos = null!;

        /// <summary>
        /// El albarán recién creado.
        /// </summary>
        public Albaran AlbaranItem { get; private set; } = null!;

        public AlbaranDialogForm(PedidoService pedidoService, AlbaranService albaranService)
        {
            InitializeComponent();
            _pedidoSvc = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
            _albaranSvc = albaranService ?? throw new ArgumentNullException(nameof(albaranService));

            Load += AlbaranDialogForm_Load;
            btnCrearAlbaran.Click += BtnCrearAlbaran_Click;
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
        }

        private void AlbaranDialogForm_Load(object sender, EventArgs e)
        {
            var lista = _pedidoSvc.GetAll();
            _pedidos = new BindingList<Pedido>(lista);
            pedidoBindingSource.DataSource = _pedidos;
            dgvPedidos.DataSource = pedidoBindingSource;
        }

        private void BtnCrearAlbaran_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona primero un pedido.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selPedido = (Pedido)dgvPedidos.CurrentRow.DataBoundItem!;
            // Crear albarán con IdPedido y IdProveedor del pedido
            var nuevo = new Albaran
            {
                IdPedido = selPedido.Id,
                IdProveedor = selPedido.IdProveedor
            };

            // Llamamos al servicio
            AlbaranItem = _albaranSvc.Add(nuevo);
            DialogResult = DialogResult.OK;
        }
    }
}
