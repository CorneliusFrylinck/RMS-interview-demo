using CanidateApp.Client.Pages;
using CanidateApp.Server.Infrastructure.Interfaces;
using CanidateApp.Server.Persistence;
using CanidateApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CanidateApp.Server.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _dataContext;

        public TicketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Ticket>?> GetOpenTickets()
        {
            try
            {
                var result = await _dataContext.Tickets.Where(t => t.TicketResolvedAt == null).ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Ticket>?> GetOpenTicketsBySiteId(Guid siteId)
        {
            try
            {
                var result = await _dataContext.Tickets.Where(t => t.TicketResolvedAt == null && t.SiteId == siteId).ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Ticket>?> GetOpenTicketsByContractor(string contractor)
        {
            try
            {
                var sites = _dataContext.SiteAssignments.Where(s => s.Contractor == contractor).Select(s => s.SiteId);
                var result = await _dataContext.Tickets.Where(t => t.TicketResolvedAt == null && sites.Contains(t.SiteId)).ToListAsync();

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateTicket(Guid siteId, int reasonId, string? details)
        {
            try
            {
                var ticket = new Ticket
                {
                    SiteId = siteId,
                    ReasonId = reasonId,
                    Details = details
                };
                await _dataContext.Tickets.AddAsync(ticket);

                var changes = await _dataContext.SaveChangesAsync();

                return changes > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<TicketReason>?> GetTicketReasons()
        {
            try
            {
                var result = await _dataContext.TicketReasons.ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<SiteAssignment>?> GetSiteAssignments()
        {
            try
            {
                var result = await _dataContext.SiteAssignments.ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AssignTickets(TicketAssignmentDto ticketAssignmentDto)
        {
            try
            {
                var siteAssignment = new SiteAssignment
                {
                    SiteId = ticketAssignmentDto.SiteId,
                    Contractor = ticketAssignmentDto.Contractor!
                };
                await _dataContext.SiteAssignments.AddAsync(siteAssignment);

                var siteTickets = await _dataContext.Tickets.Where(t => t.SiteId ==  ticketAssignmentDto.SiteId && ticketAssignmentDto.Status == TicketStatusEnum.Unassigned).ToListAsync();

                foreach (var ticket in siteTickets)
                {
                    ticket.Status = TicketStatusEnum.Assigned;
                }

                var changes = await _dataContext.SaveChangesAsync();

                return changes > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTicketStatus(int ticketId, TicketStatusEnum newStatus)
        {
            try
            {
                var ticket = await _dataContext.Tickets.FirstAsync(t => t.Id == ticketId);
                ticket!.Status = newStatus;

                if (newStatus == TicketStatusEnum.Resolved)
                {
                    ticket!.TicketResolvedAt = DateTime.UtcNow;
                }

                var changes = await _dataContext.SaveChangesAsync();

                return changes > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
