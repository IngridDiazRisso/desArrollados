// HotelSOL.DataAccess/Services/PagoService.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class PagoService
    {
        private readonly HotelSolContext _context;

        public PagoService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Registra un pago de la factura y marca la factura como pagada si corresponde.
        /// </summary>
        public void RegistrarPago(int facturaId, string metodoPago)
        {
            using var tx = _context.Database.BeginTransaction();

            // 1) Cargar la factura con sus pagos asociados
            var factura = _context.Facturas
                                  .Include(f => f.Pagos)
                                  .FirstOrDefault(f => f.Id == facturaId)
                          ?? throw new ArgumentException($"Factura {facturaId} no encontrada.");

            // 2) Crear el pago
            var pago = new Pago
            {
                FacturaId = facturaId,
                Monto = factura.MontoTotal,
                MetodoPago = metodoPago,
                FechaPago = DateTime.Now
            };
            _context.Pagos.Add(pago);
            _context.SaveChanges();

            // 3) Marcar factura como pagada si el total pagado (incluyendo este) cubre el monto total
            var totalPagado = factura.Pagos.Sum(p => p.Monto) + pago.Monto;
            if (totalPagado >= factura.MontoTotal)
            {
                factura.Pagada = true;
                _context.SaveChanges();
            }

            tx.Commit();
        }

        /// <summary>
        /// Obtiene una factura junto con sus pagos.
        /// </summary>
        public Factura ObtenerFacturaPorId(int facturaId)
        {
            return _context.Facturas
                           .Include(f => f.Pagos)
                           .FirstOrDefault(f => f.Id == facturaId)
                   ?? throw new ArgumentException($"Factura {facturaId} no encontrada.");
        }

        /// <summary>
        /// Obtiene todos los pagos asociados a una factura.
        /// </summary>
        public List<Pago> ObtenerPagosPorFactura(int facturaId)
        {
            return _context.Pagos
                           .Where(p => p.FacturaId == facturaId)
                           .ToList();
        }

        // … aquí podrías añadir otros métodos relacionados con pagos si los necesitas …
    }
}
