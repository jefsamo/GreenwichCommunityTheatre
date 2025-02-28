using GreenwichCommunityTheatre.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenwichCommunityTheatre.Infrastructure.Context
{
    public class GctDbContext : IdentityDbContext<User, Role, Guid>
    {

        public GctDbContext(DbContextOptions<GctDbContext> options) : base(options)
        {
        }

        public GctDbContext()
        {

        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(u => u.Reservations).WithOne(r => r.User).IsRequired();
            modelBuilder.Entity<User>().HasMany(u => u.Reviews).WithOne(r => r.User).IsRequired();

            modelBuilder.Entity<Reservation>().HasMany(r => r.Tickets).WithOne(r => r.Reservation).HasForeignKey(r => r.ReservationId).IsRequired();
            //modelBuilder.Entity<Reservation>().HasOne(r => r.Shipment).WithOne(s => s.Reservation).HasForeignKey<Shipment>(s => s.ReservationId).IsRequired();

            modelBuilder.Entity<Seat>().HasMany(r => r.Tickets).WithOne(r => r.Seat).HasForeignKey(r => r.SeatId).IsRequired();

            modelBuilder.Entity<Play>().HasMany(p => p.Tickets).WithOne(p => p.Play).HasForeignKey(p => p.PlayId).IsRequired();
            modelBuilder.Entity<Play>().HasMany(p => p.Reviews).WithOne(p => p.Play).HasForeignKey(p => p.PlayId).IsRequired();


            SeedData<Review>(modelBuilder,"reviews.json");
            SeedData<Seat>(modelBuilder, "seats.json");
            SeedData<Play>(modelBuilder, "plays.json");
        }

        private void SeedData<T>(ModelBuilder modelBuilder, string filePath) where T : class
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string dataJson = File.ReadAllText(filePath);
            List<T> datas = System.Text.Json.JsonSerializer.Deserialize<List<T>>(dataJson)!;

            foreach (var data in datas)
            {
                modelBuilder.Entity<T>().HasData(data);
            }
        }
    }
}
