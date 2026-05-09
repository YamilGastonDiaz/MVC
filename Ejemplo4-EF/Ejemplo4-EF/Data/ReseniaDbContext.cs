using Ejemplo4_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ejemplo4_EF.Data
{
    public class ReseniaDbContext : DbContext
    {
        public ReseniaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Resenia> Resenias { get; set; }
    }
}
