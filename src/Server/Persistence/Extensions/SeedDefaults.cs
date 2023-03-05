using CanidateApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CanidateApp.Server.Persistence.Extensions
{
    public static class SeedDefaults
    {
        /// <summary>
        /// Function used to seed default data such as ticket reasons.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static ModelBuilder SeedDefaultData(this ModelBuilder modelBuilder)
        {
            // If no ticket reasons exist, populate with defaults.
            modelBuilder.Entity<TicketReason>().HasData(
                new TicketReason(1, "Tower connection is failing."),
                new TicketReason(2, "Tower has trouble lasting through 4-hour loadshedding."),
                new TicketReason(3, "Tower has trouble lasting through 2-hour loadshedding."),
                new TicketReason(4, "Tower connection is slow."),
                new TicketReason(5, "Tower connection is unstable.")
            );
            return modelBuilder;
        }
    }
}
