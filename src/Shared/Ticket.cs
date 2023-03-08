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
        public int ReasonId { get; set; } = 0;

        /// <summary>
        /// Details regarding the issue when the reason is not found in the list.
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// The current status of the ticket.
        /// </summary>
        public TicketStatusEnum Status { get; set; } = TicketStatusEnum.Unassigned;

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
