using Project2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using System.Data.Entity;

namespace Project2.Data
{

    // We use AppDbContext in our code to interact with our database
    // Previously, with ADO, we created a Data Access Object related to the entity in SQL
    // Now we just need the AppDbContext object
    public class AppDbContext : DbContext
    {
        // This constructor is used by EF to create the needed DB Context based on our provided models
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        // We provide the models through DbSet<ModelName> fields
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        // We have to override the default behavior to ensure the foreign key constraint is established
        // If we don't do this, then the columns will still be created but the constrain is not
        // enforced
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many relationship
            modelBuilder.Entity<User>()
                .HasMany(p => p.Purchases)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
        }
    }
}