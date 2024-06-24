using Microsoft.EntityFrameworkCore;
using BeverageInventoryManagement.Models;

namespace BeverageInventoryManagement.Data
{
    public class BeverageDbContext : DbContext
    {
        public BeverageDbContext(DbContextOptions<BeverageDbContext> options) : base(options)
        {
        }

        public DbSet<Beverage> Beverages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>()
               .HasKey(b => b.BeverageId);

            modelBuilder.Entity<Beverage>()
                .Property(b => b.BeverageId)
                .ValueGeneratedOnAdd();
        }
    }
}
