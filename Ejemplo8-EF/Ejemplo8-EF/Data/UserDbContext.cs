using Ejemplo8_EF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo8_EF.Data
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Auto> Autos { get; set; }
    }
}
