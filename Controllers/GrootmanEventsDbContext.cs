using Microsoft.EntityFrameworkCore;

namespace GrootmanEvents.Models
{
    public class GrootmanEventsDbContext : DbContext
    {
        public GrootmanEventsDbContext(
            DbContextOptions<GrootmanEventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}