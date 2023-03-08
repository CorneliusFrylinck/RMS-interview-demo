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
        /// Find all open/unresolved tickets.
        /// </summary>
        /// <returns>A list of open tickets.</returns>
        Task<IEnumerable<Ticket>?> GetOpenTickets();

        /// <summary>
        /// Find all open/unresolved tickets related to a specific site.
        /// </summary>
        /// <param name="siteId">The site in question.</param>
        /// <returns>A list of open tickets.</returns>
        Task<IEnumerable<Ticket>?> GetOpenTicketsBySiteId(Guid siteId);

        /// <summary>
        /// Find all open/unresolved tickets for a specific constractor.
        /// </summary>
        /// <returns>A list of open tickets.</returns>
        Task<IEnumerable<Ticket>?> GetOpenTicketsByContractor(string contractor);

        /// <summary>
        /// Retrieve a list of site assignments.
        /// </summary>
        /// <returns>A list of site assignments.</returns>
        Task<IEnumerable<SiteAssignment>?> GetSiteAssignments();

        /// <summary>
        /// Retrieve a list of ticket reasons.
        /// </summary>
        /// <returns>A list of ticket reasons.</returns>
        Task<IEnumerable<TicketReason>?> GetTicketReasons();

        /// <summary>
        /// Create a new ticket assignment.
        /// </summary>
        /// <param name="ticketAssignmentDto">Dto with details related to ticket assignment.</param>
        /// <returns>True if the ticket assignment has been added, false if the ticket assignment couldn't be saved.</returns>
        Task<bool> AssignTickets(TicketAssignmentDto ticketAssignmentDto);

        /// <summary>
        /// Create a new ticket.
        /// </summary>
        /// <param name="siteId">Site the ticket is in relation to.</param>
        /// <param name="reasonId">The unique identifier linked to the reason the ticket is being created.</param>
        /// <param name="details">Optional details when a new reason is found.</param>
        /// <returns>True if the ticket has been added, false if the ticket couldn't be saved.</returns>
        Task<bool> UpdateTicketStatus(int ticketId, TicketStatusEnum newStatus);

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