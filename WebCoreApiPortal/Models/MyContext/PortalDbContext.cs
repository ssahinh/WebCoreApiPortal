using Microsoft.EntityFrameworkCore;

namespace WebCoreApiPortal.Models.MyContext
{
    public class PortalDbContext : DbContext
    {
        public DbSet<Parkkit> Parkkits { get; set; }
        public DbSet<CarWash> CarWashes { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<FoodKit> FoodKits { get; set; }
        public DbSet<Charge> Charges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DBNEW.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parkkit>().Ignore(b => b.Distance);
            modelBuilder.Entity<CarWash>().Ignore(b => b.Distance);
            modelBuilder.Entity<CarService>().Ignore(b => b.Distance);
        }
    }
}
