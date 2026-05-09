using Ejemplo5_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo5_EF.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Pokemon> Pokemons  { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
    }
}
