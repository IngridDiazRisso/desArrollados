using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Service
{
    public class AlbaranService
    {
        private readonly HotelSolContext _ctx;

        public AlbaranService(HotelSolContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        /// <summary>
        /// Devuelve todos los albaranes, incluyendo sus pedidos y proveedores.
        /// </summary>
        public List<Albaran> GetAll()
            => _ctx.Albaranes
                   .Include(a => a.Pedido)
                   .Include(a => a.Proveedor)
                   .OrderBy(a => a.Id)
                   .ToList();

        /// <summary>
        /// Devuelve todos los albaranes asociados a un pedido.
        /// </summary>
        public List<Albaran> GetByPedidoId(int pedidoId)
            => _ctx.Albaranes
                   .Where(a => a.IdPedido == pedidoId)
                   .Include(a => a.Pedido)
                   .Include(a => a.Proveedor)
                   .OrderBy(a => a.Id)
                   .ToList();

        /// <summary>
        /// Busca un albarán por su Id, incluyendo sus relaciones.
        /// </summary>
        public Albaran? GetById(int id)
            => _ctx.Albaranes
                   .Include(a => a.Pedido)
                   .Include(a => a.Proveedor)
                   .SingleOrDefault(a => a.Id == id);

        /// <summary>
        /// Crea un nuevo albarán y devuelve la entidad con Id generado por la base de datos.
        /// </summary>
        public Albaran Add(Albaran albaran)
        {
            if (albaran == null)
                throw new ArgumentNullException(nameof(albaran));

            // No asignes albaran.Id: debe quedar en 0 para que SQL Server lo genere
            _ctx.Albaranes.Add(albaran);
            _ctx.SaveChanges();
            return albaran;
        }

        /// <summary>
        /// Elimina un albarán por su Id.
        /// </summary>
        public void Delete(int id)
        {
            var existente = _ctx.Albaranes.Find(id);
            if (existente == null) return;

            _ctx.Albaranes.Remove(existente);
            _ctx.SaveChanges();
        }
    }
}
