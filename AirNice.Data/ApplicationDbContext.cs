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
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //}
        public DbSet<NumberSequence> NumberSequences { get; set; }
        public DbSet<CoreProfile> UserProfiles { get; set; }
        public DbSet<AirLinesEnquiry> AirLinesEnquiries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingEnquiry> BookingEnquiries { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TicketClass> TicketClasses { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<AdditionalUser> AdditionalUsers { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<AirPort> AirPorts { get; set; }
        public DbSet<Plane> Plane { get; set; }
        public DbSet<AirPort> Airport { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<SeatMap> SeatMap { get; set; }
        public DbSet<PlaneSeatClass>  PlaneSeatClasse { get; set; }
        public DbSet< PassengerTicket> passengerTicket { get; set; }
        public  DbSet<PassengerType> PassengerType { get; set; }
        public DbSet<PlaneSeatClass> PlaneSeatClass { get; set; }
        public DbSet<SeatClass> SeatClass { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketFlight> TicketFlight { get; set; }
        public DbSet<TicketClass> TicketClass { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        







    }
}
