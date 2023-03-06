using CanidateApp.Shared;

namespace CanidateApp.Server.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository used to manage ticket-related database functions.
    /// </summary>
    /// <param name="dataContext"></param>
    public interface ITicketRepository
    {
        /// <summary>
        /// Find all open/unresolved tickets related to a specific site.
        /// </summary>
        /// <param name="siteId">The site in question.</param>
        /// <returns>A list of open tickets.</returns>
        Task<IEnumerable<Ticket>?> GetOpenTicketsBySiteId(Guid siteId);

        /// <summary>
        /// Create a new ticket.
        /// </summary>
        /// <param name="siteId">Site the ticket is in relation to.</param>
        /// <param name="reasonId">The unique identifier linked to the reason the ticket is being created.</param>
        /// <param name="details">Optional details when a new reason is found.</param>
        /// <returns>True if the ticket has been added, false if the ticket couldn't be saved.</returns>
        Task<bool> CreateTicket(Guid siteId, int reasonId, string? details);
    }
}