using CanidateApp.Server.Persistence.Extensions;
using CanidateApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CanidateApp.Server.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TicketReason> TicketReasons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SiteAssignment> SiteAssignments { get; set; }

        /// <summary>
        /// Seed data on model creation.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDefaultData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
