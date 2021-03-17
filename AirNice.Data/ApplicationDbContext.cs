using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text;
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
        public DbSet<AirLinesEnquiry> AirLinesEnquiries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingEnquiry> BookingEnquiries { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TicketClass> TicketClasses { get; set; }
        public DbSet<Passenger> Passengers { get; set; }







    }
}
