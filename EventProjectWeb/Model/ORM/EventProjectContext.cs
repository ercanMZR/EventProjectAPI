using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net.Sockets;

namespace EventProjectWeb.Model.ORM
{
    public class EventProjectContext : DbContext
    {
        public EventProjectContext(DbContextOptions<EventProjectContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<ActivityEventImages> Activities { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
