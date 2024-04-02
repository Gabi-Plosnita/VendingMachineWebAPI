using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess.Entities;

namespace VendingMachine.DataAccess
{
    public class VendingMachineDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public VendingMachineDbContext(DbContextOptions<VendingMachineDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id); 

            modelBuilder.Entity<Product>()
                .HasAlternateKey(p => new { p.Id, p.Name }); 
        }


    }
}
