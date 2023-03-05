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
        public TicketReason(int id, string title)
        {
            Id = id;
            Title = title;
        }

        /// <summary>
        /// The unique identifier for the ticket reason.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The reason title. This is what the user sees in the list.
        /// </summary>
        public string Title { get; set; } = null!;
    }
}
