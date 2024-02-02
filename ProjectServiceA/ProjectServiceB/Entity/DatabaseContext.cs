using Microsoft.EntityFrameworkCore;
using ProjectServiceB.Models;

namespace ProjectServiceB.Entity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            modelBuilder.Entity<OrderDetail>().HasKey(x => x.Id);
        }
    }
}
