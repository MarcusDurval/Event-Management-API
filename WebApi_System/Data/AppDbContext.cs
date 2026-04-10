using Microsoft.EntityFrameworkCore;
using WebApi_System.Models;

namespace WebApi_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
