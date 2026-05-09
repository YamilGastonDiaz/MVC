using Ejemplo6_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo6_EF.Data
{
    public class DiscoDbContext : DbContext
    {
        public DiscoDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<TipoEdicion> TiposEdicion { get; set; }
        public DbSet<Disco> Discos { get; set; }
    }
}
