using Microsoft.EntityFrameworkCore;
using ProjectServiceA.Models;
using System.Numerics;

namespace ProjectServiceA.Entity
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

            // Inserting record in OurHero table
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728950e",
                    Name = "Vu Duc Long",
                    Address = "Nam Định",
                    Avatar = "https://d1hjkbq40fs2x4.cloudfront.net/2017-08-21/files/landscape-photography_1645-t.jpg",
                    Email = "vuduclong3010@gmail.com",
                    PhoneNumber = "0886632254",
                    IsDeleted = false,
                }
            );

            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728951a",
                    Name = "Áo dài",
                    Description = "Description",
                    IsDelete = false,
                    Node = "Khong co gi",
                    Price = 100000,
                    Qty = 10
                },
                new Product
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728951b",
                    Name = "Áo thu đông",
                    Description = "Description",
                    IsDelete = false,
                    Node = "Khong co gi",
                    Price = 100000,
                    Qty = 10
                }
            );

            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728951s",
                    Address = "Nam Định",
                    Email = "vuduclong3010@gmail.com",
                    Node = " Khonc co gi",
                    IsActive = "Dang giao",
                    CustomerId = "0f8fad5b-d9cb-469f-a165-70867728950e",
                    IsDelete = false,
                    NameReciver = "Vu Duc Long",
                    OrderDate = new DateTime(2000, 10, 30),
                    Phone = "0886632254",
                    TotalMoney = 200000,
                }
            );

            modelBuilder.Entity<OrderDetail>().HasKey(x => x.Id);

            //// Inserting record in OurHero table
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728952a",
                    IdProduct = "0f8fad5b-d9cb-469f-a165-70867728951a",
                    OrderId = "0f8fad5b-d9cb-469f-a165-70867728951s",
                    Price = 100000,
                    Qty = 1,
                    Total = 100000,
                    ReturnQty = 0,
                },
                new OrderDetail
                {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728952b",
                    IdProduct = "0f8fad5b-d9cb-469f-a165-70867728951b",
                    OrderId = "0f8fad5b-d9cb-469f-a165-70867728951s",
                    Price = 100000,
                    Qty = 1,
                    Total = 100000,
                    ReturnQty = 0,
                }
            );
        }
    }
}
