using EShoppingAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
