using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public class Ticket
    {
        /// <summary>
        /// The unique identifier for the ticket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier related to the site in question. This is used to retrieve tickets related to a specific site.
        /// </summary>
        public Guid SiteId { get; set; }

        /// <summary>
        /// The reason describing the current issue with the tower.
        /// </summary>
        public TicketReason Reason { get; set; } = null!;

        /// <summary>
        /// Details regarding the issue when the reason is not found in the list.
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// The date the ticket was created.
        /// </summary>
        public DateTime TicketCreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The date the ticket was created.
        /// </summary>
        /// <returns>Null when the ticket has not yet been resolved. This makes it easy to query unresolved tickets.</returns>
        public DateTime? TicketResolvedAt { get; set; } = null!;
    }
}
