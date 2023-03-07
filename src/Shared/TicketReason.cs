using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    /// <summary>
    /// Preset reasons for tickets. The user creating the ticket should be able to select one of these reasons.
    /// </summary>
    public class TicketReason
    {
        public TicketReason(int id, TicketReasonEnum reason, string title)
        {
            Id = id;
            Reason = reason;
            Title = title;
        }

        /// <summary>
        /// The unique identifier for the ticket reason.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// An enum used to verify that the ticket reason is.
        /// </summary>
        public TicketReasonEnum Reason { get; set; }

        /// <summary>
        /// The reason title. This is what the user sees in the list.
        /// </summary>
        public string Title { get; set; } = null!;
    }
}
