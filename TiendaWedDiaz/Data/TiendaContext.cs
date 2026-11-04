using Microsoft.EntityFrameworkCore;
using TiendaWedDiaz.Models;

namespace TiendaWedDiaz.Data

{
    
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
    
    {
    }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
     new Usuario { Id = 1, Nombre = "Carlos Díaz", Correo = "admin@tienda.com", Rol = Roles.Administrador, Celular = "3101234567" },
     new Usuario { Id = 2, Nombre = "María Gómez", Correo = "cajero@tienda.com", Rol = Roles.Cajero, Celular = "3209876543" },
     new Usuario { Id = 3, Nombre = "Luis Pérez", Correo = "bodeguero@tienda.com", Rol = Roles.Bodeguero, Celular = "3154567890" },
     new Usuario { Id = 4, Nombre = "Ana Martínez", Correo = "ana@correo.com", Rol = Roles.Cliente, Celular = "3001112233" },
     new Usuario { Id = 5, Nombre = "Jorge Rodríguez", Correo = "jorge@correo.com", Rol = Roles.Cliente, Celular = "3176543210" }
 );

        }

    }
}



