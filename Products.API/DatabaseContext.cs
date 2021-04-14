using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace Products.API
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}