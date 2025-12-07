/// Entity Framework database context. Defines all DB tables & configures SQLite connection. Will be 
/// modified each time a new data model or data table is added. 
using Microsoft.EntityFrameworkCore;
using BytePizza.Models;

namespace BytePizza.Data
{
    public class ApplicationDBContext : DbContext
    {
        ///<summary>
        ///Database connection config
        ///</summary>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { 
        }
        /// <summary>
        /// Represents individual DB tables for each entity
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<DrinkOrder> DrinkOrders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // All properties pulled directly from customer.cs model
            modelBuilder.Entity<Customer>(entity =>
            {
                //Unique index qualities. Each customerID is associated with one user and
                //each phone number must be associated with only one customer
                entity.HasKey(c => c.CustomerId);
                entity.HasIndex(c => c.Phone).IsUnique();
                //Properties of a customer. Configures the columns of the table
                entity.Property(c => c.Phone).IsRequired().HasMaxLength(10);
                entity.Property(c => c.Password).IsRequired().HasMaxLength(15);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(60);
                entity.Property(c => c.Address).HasMaxLength(200);

                entity.HasMany(c => c.Order)
                      .WithOne(o => o.Customer!)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(m => m.MenuItemId);
                entity.Property(m => m.Name).IsRequired().HasMaxLength(15);
                entity.Property(m => m.Category).IsRequired().HasMaxLength(15);
                entity.Property(m => m.MenuItemPrice)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);

                entity.Property(o => o.CustomerId).IsRequired();
                entity.Property(o => o.Orderdate)
                      .IsRequired()
                      .HasDefaultValueSql("datetime('now')");

                entity.Property(o => o.OrderType)
                      .IsRequired()
                      .HasMaxLength(10)
                      .HasDefaultValue("Pickup");

                entity.Property(o => o.OrderStatus)
                      .IsRequired()
                      .HasMaxLength(10)
                      .HasDefaultValue("Pending");

                entity.Property(o => o.Subtotal)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)")
                      .HasDefaultValue(0.00m);

                entity.Property(o => o.Tax)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)")
                      .HasDefaultValue(0.00m);

                entity.Property(o => o.Total)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)")
                      .HasDefaultValue(0.00m);

                // One-to-One: Order → PizzaOrder
                entity.HasOne(o => o.Pizza)
                      .WithOne(p => p.Order!)
                      .HasForeignKey<PizzaOrder>(p => p.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);

                // One-to-Many: Order → DrinkOrders
                entity.HasMany(o => o.Drinks)
                      .WithOne(d => d.Order!)
                      .HasForeignKey(d => d.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(p => p.PizzaOrderId);
                entity.Property(p => p.PizzaSize).IsRequired().HasMaxLength(20);
                entity.Property(p => p.Crust).IsRequired().HasMaxLength(10);
                entity.Property(p => p.Sauce).IsRequired().HasMaxLength(20);
                entity.Property(p => p.Toppings).HasMaxLength(200);
                entity.Property(p => p.PizzaOrderPrice)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<DrinkOrder>(entity =>
            {
                entity.HasKey(d => d.DrinkOrderId);

                entity.Property(d => d.DrinkType).IsRequired().HasMaxLength(15);
                entity.Property(d => d.DrinkSize).IsRequired().HasMaxLength(10);
                entity.Property(d => d.DrinkQuantity)
                      .IsRequired()
                      .HasDefaultValue(1);

                entity.Property(d => d.DrinkOrderPrice)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)")
                      .HasDefaultValue(0.00m);
            });
        }
    }
}
