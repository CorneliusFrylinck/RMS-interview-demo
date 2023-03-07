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
                new TicketReason(1, TicketReasonEnum.Fail, "Tower connection is failing"),
                new TicketReason(2, TicketReasonEnum.Battery_Capacity, "Tower has trouble lasting through 4-hour loadshedding"),
                new TicketReason(3, TicketReasonEnum.Battery_Quality, "Tower has trouble lasting through 2-hour loadshedding"),
                new TicketReason(4, TicketReasonEnum.Slow_Connection, "Tower connection is slow"),
                new TicketReason(5, TicketReasonEnum.Unstable_Connection, "Tower connection is unstable"),
                new TicketReason(6, TicketReasonEnum.Other, "Other")
            );
            return modelBuilder;
        }
    }
}
