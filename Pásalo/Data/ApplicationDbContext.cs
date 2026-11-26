using Microsoft.EntityFrameworkCore;
using Pásalo.Models;

namespace Pásalo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Articulo> Articulos { get; set; }
    }
}