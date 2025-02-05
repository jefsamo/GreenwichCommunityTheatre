using GreenwichCommunityTheatre.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenwichCommunityTheatre.Infrastructure.Context
{
    public class GctDbContext : IdentityDbContext<User, Role, string>
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
        public DbSet<Shipment> Shipments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasMany(u => u.Reservations).WithOne(r => r.User).IsRequired();
            modelBuilder.Entity<User>().HasMany(u => u.Reviews).WithOne(r => r.User).IsRequired();


            modelBuilder.Entity<Reservation>().HasMany(r => r.Tickets).WithOne(r => r.Reservation).HasForeignKey(r => r.ReservationId).IsRequired();
            modelBuilder.Entity<Reservation>().HasOne(r => r.Shipment).WithOne(s => s.Reservation).HasForeignKey<Shipment>(s => s.ReservationId).IsRequired();

            modelBuilder.Entity<Seat>().HasMany(r => r.Tickets).WithOne(r => r.Seat).HasForeignKey(r => r.SeatId).IsRequired();

            modelBuilder.Entity<Play>().HasMany(p => p.Tickets).WithOne(p => p.Play).HasForeignKey(p => p.PlayId).IsRequired();
            modelBuilder.Entity<Play>().HasMany(p => p.Reviews).WithOne(p => p.Play).HasForeignKey(p => p.PlayId).IsRequired();
        }
    }
}
