using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        private string _dbPath;

        public DbSet<AutoMarka> AutoMarkas { get; set; }
        public DbSet<AutoSzin> AutoSzins { get; set; }
        public DbSet<AutoTipus> AutoTipuses { get; set; }
        public DbSet<Flotta> Flottas { get; set; }

        public AppDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, "autok.db");

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + _dbPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flotta>()
                            .HasOne(f => f.Szin)
                                .WithOne(sz => sz.Flotta)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flotta>()
                            .HasOne(f => f.Tipus)
                                .WithOne(sz => sz.Flotta)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flotta>()
                            .HasOne(f => f.Marka)
                                .WithOne(sz => sz.Flotta)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
