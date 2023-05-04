using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // string configurationString = ConfigurationManager.ConnectionStrings["MsSqlServerConnectionString"].ConnectionString;

            optionsBuilder
                .UseSqlServer("Server=localhost;Database=GamingPubsDatabase;User Id=Adi123;Password=123;TrustServerCertificate=True")
                .LogTo(Console.WriteLine);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<GamingPub> GamingPubs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GamingPlatform> GamingPlatforms { get; set; }
    }
}