// HotelSOL.DataAccess/HotelSolContext.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess
{
    public class HotelSolContext : DbContext
    {
        // ——— DbSets existentes ———
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaHabitaciones> ReservaHabitaciones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<TipoHabitacion> TiposHabitaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        // ——— Módulo de compras/proveedores ———
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Albaran> Albaranes { get; set; }
        public DbSet<FacturaProveedor> FacturasProveedores { get; set; }

        // ——— Tipos de servicio ———
        public DbSet<TipoServicioEntity> TipoServicio { get; set; }

      

        public HotelSolContext(DbContextOptions<HotelSolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // ——————————————
            //  M A P E O   D E   T A B L A S
            // ——————————————

            mb.Entity<Proveedor>(b =>
            {
                b.ToTable("Proveedor");
                b.HasKey(p => p.IdProveedor);
            });

            mb.Entity<Stock>(b =>
            {
                b.ToTable("Stock");
                b.HasKey(s => s.id);
            });

            mb.Entity<Pedido>(b =>
            {
                b.ToTable("Pedidos");
                b.HasKey(p => p.Id);

                b.HasOne(p => p.Proveedor)
                 .WithMany(pr => pr.Pedidos)
                 .HasForeignKey(p => p.IdProveedor)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<Albaran>(b =>
            {
                b.ToTable("Albaranes");
                b.HasKey(a => a.Id);

                // Marca Id como IDENTITY
                b.Property(a => a.Id)
                 .UseIdentityColumn()    // SQL Server identity
                 .ValueGeneratedOnAdd(); // EF Core no lo incluye en el INSERT

                b.HasOne(a => a.Proveedor)
                 .WithMany(pr => pr.Albaranes)
                 .HasForeignKey(a => a.IdProveedor)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(a => a.Pedido)
                 .WithMany(p => p.Albaranes)
                 .HasForeignKey(a => a.IdPedido)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            mb.Entity<FacturaProveedor>(b =>
            {
                b.ToTable("FacturasProveedores");
                b.HasKey(fp => fp.Id);

                b.HasOne(fp => fp.Proveedor)
                 .WithMany(pr => pr.FacturasProveedores)
                 .HasForeignKey(fp => fp.IdProveedor)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(fp => fp.Pedido)
                 .WithMany(p => p.FacturasProveedores)
                 .HasForeignKey(fp => fp.IdPedido)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(fp => fp.Albaran)
                 .WithMany(a => a.FacturasProveedores)
                 .HasForeignKey(fp => fp.IdAlbaran)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<TipoServicioEntity>(b =>
            {
                b.ToTable("TipoServicio");
                b.HasKey(ts => ts.Id);
            });

            // ——————————————
            //  Relaciones varias de otros módulos
            // ——————————————

            mb.Entity<Servicio>(b =>
            {
                b.HasOne(s => s.TipoServicio)
                 .WithMany()
                 .HasForeignKey(s => s.TipoServicioId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<Cliente>(b =>
            {
                b.HasKey(c => c.ClienteId);
                b.HasOne(c => c.Usuario)
                 .WithOne(u => u.Cliente)
                 .HasForeignKey<Cliente>(c => c.UsuarioId);
            });

            mb.Entity<ReservaHabitaciones>(b =>
            {
                b.HasKey(rh => rh.Id);
                b.HasOne(rh => rh.Reserva)
                 .WithMany(r => r.ReservaHabitaciones)
                 .HasForeignKey(rh => rh.ReservaId);
                b.HasOne(rh => rh.Habitacion)
                 .WithMany(h => h.ReservaHabitaciones)
                 .HasForeignKey(rh => rh.HabitacionId);
            });

            mb.Entity<Reserva>(b =>
            {
                b.HasMany(r => r.ReservaHabitaciones)
                 .WithOne(rh => rh.Reserva)
                 .HasForeignKey(rh => rh.ReservaId)
                 .OnDelete(DeleteBehavior.Cascade);

                // Estado como int
                b.Property(r => r.Estado)
                 .HasConversion<int>();
            });

            mb.Entity<Habitacion>(b =>
            {
                b.HasOne(h => h.TipoHabitacion)
                 .WithMany(t => t.Habitaciones)
                 .HasForeignKey(h => h.TipoId);
            });


            base.OnModelCreating(mb);
        }
    }
}
