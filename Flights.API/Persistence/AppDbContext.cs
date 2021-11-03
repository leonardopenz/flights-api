using Microsoft.EntityFrameworkCore;
using Flights.API.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Flights.API.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightPassenger> FlightPassengers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Airplane>().ToTable("airplanes");
            builder.Entity<Airplane>().HasKey(a => a.Id);
            builder.Entity<Airplane>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Airplane>().Property(a => a.Registration).IsRequired();

            builder.Entity<Airport>().ToTable("airports");
            builder.Entity<Airport>().HasKey(a => a.Id);
            builder.Entity<Airport>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Airport>().Property(a => a.Name).IsRequired();

            builder.Entity<Flight>().ToTable("flights");
            builder.Entity<Flight>().HasKey(f => f.FlightId);
            builder.Entity<Flight>().Property(f => f.FlightId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Flight>().Property(f => f.Number).IsRequired();
            builder.Entity<Flight>().HasMany(f => f.FlightPassengers);

            builder.Entity<Passenger>().ToTable("passengers");
            builder.Entity<Passenger>().HasKey(p => p.PassportNumber);
            builder.Entity<Passenger>().Property(p => p.PassportNumber).IsRequired();
            builder.Entity<Passenger>().Property(p => p.Name).IsRequired();
            builder.Entity<Passenger>().HasMany(p => p.FlightPassengers).WithOne(p => p.Passenger);

            builder.Entity<FlightPassenger>().ToTable("flight_passengers");
            builder.Entity<FlightPassenger>().HasKey(fp => new { fp.FlightId, fp.PassportNumber });  
            builder.Entity<FlightPassenger>().HasOne(fp => fp.Flight).WithMany(fp => fp.FlightPassengers).HasForeignKey(fp => fp.FlightId);  
            builder.Entity<FlightPassenger>().HasOne(fp => fp.Passenger).WithMany(fp => fp.FlightPassengers).HasForeignKey(fp => fp.PassportNumber);
        }
    }
}