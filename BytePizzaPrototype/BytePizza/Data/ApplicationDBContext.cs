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
            });
        }




    }
}
