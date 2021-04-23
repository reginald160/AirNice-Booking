using AirNice.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirNice.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Permission> permissions  { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<NumberSequence> NumberSequences { get; set; }
        public DbSet<CoreProfile> UserProfiles { get; set; }
        public DbSet<AirLinesEnquiry> AirLinesEnquiries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingEnquiry> BookingEnquiries { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TicketClass> TicketClasses { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<AdditionalUser> AdditionalUsers { get; set; }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<AirPort> AirPorts { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Bank> Bank { get; set; }







    }
}
