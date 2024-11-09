using Microsoft.EntityFrameworkCore;
using MyFirstApi.EFCore.Entities;

namespace MyFirstApi.EFCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(a => a.ProductID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

            // Configure Customer-Address relationship (One-to-Many)
            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressID);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CustomerID);

            // Configure Customer's Shipping and Billing Addresses (One-to-One)
            modelBuilder.Entity<Customer>()
                .HasKey(a => a.CustomerID);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ShippingAddress)
                .WithMany()
                .HasForeignKey(c => c.ShippingAddressID)
                .OnDelete(DeleteBehavior.Restrict); //

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.BillingAddress)
                .WithMany()
                .HasForeignKey(c => c.BillingAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Order relationships
            modelBuilder.Entity<Order>()
                .HasKey(a => a.OrderID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShipAddress)
                .WithMany()
                .HasForeignKey(o => o.ShipAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure OrderItem relationships
            modelBuilder.Entity<OrderItem>()
                .HasKey(a => a.OrderID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductID);

            modelBuilder.Entity<Administrator>()
                .HasKey(a=>a.AdminID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
