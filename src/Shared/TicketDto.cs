using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public class TicketDto
    {
        /// <summary>
        /// The unique identifier related to the site in question. This is used to retrieve tickets related to a specific site.
        /// </summary>
        public Guid SiteId { get; set; }

        /// <summary>
        /// The id related to the reason describing the current issue with the tower.
        /// </summary>
        public int ReasonId { get; set; }

        /// <summary>
        /// Details regarding the issue when the reason is not found in the list.
        /// </summary>
        public string? Details { get; set; }
    }
}
