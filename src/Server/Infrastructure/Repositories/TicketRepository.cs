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

        public async Task<bool> CreateTicket(Guid siteId, int reasonId, string? details)
        {
            try
            {
                var reason = await _dataContext.TicketReasons.Where(r => r.Id == reasonId).FirstAsync();
                var ticket = new Ticket
                {
                    SiteId = siteId,
                    Reason = reason,
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
    }
}
