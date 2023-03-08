using CanidateApp.Server.Infrastructure.Interfaces;
using CanidateApp.Server.Persistence;
using CanidateApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanidateApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet("getTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsBySiteIdAsync()
        {
            var result = await _ticketRepository.GetOpenTickets();

            if (result == null) return BadRequest("We had a problem getting tickets.");

            return Ok(result);
        }

        [HttpGet("getTicketsBySiteId")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsBySiteIdAsync(Guid siteId)
        {
            var result = await _ticketRepository.GetOpenTicketsBySiteId(siteId);

            if (result == null) return BadRequest("We had a problem getting tickets related to this site.");

            return Ok(result);
        }

        [HttpGet("getTicketAssignments")]
        public async Task<ActionResult<IEnumerable<TicketAssignmentDto>>> GetTicketAssignments()
        {
            List<TicketAssignmentDto> ticketAssignmentDtos = new List<TicketAssignmentDto>();

            var tickets = await _ticketRepository.GetOpenTickets();
            if (tickets == null) return BadRequest("We had a problem getting tickets.");

            var assignments = await _ticketRepository.GetSiteAssignments();
            if (assignments == null) return BadRequest("We had a problem getting assignments.");

            foreach (var ticket in tickets)
            {
                var assignment = assignments.FirstOrDefault(a => a.SiteId == ticket.SiteId);
                var contractor = assignment == null ? null : assignment.Contractor;
                ticketAssignmentDtos.Add(new TicketAssignmentDto
                {
                    TicketId = ticket.Id,
                    Details = ticket.Details,
                    ReasonId = ticket.ReasonId,
                    SiteId = ticket.SiteId,
                    Status = ticket.Status,
                    Contractor = contractor
                });
            }

            return Ok(ticketAssignmentDtos);
        }

        [HttpPost("createTicket")]
        public async Task<ActionResult> CreateTicketAsync([FromBody] TicketDto ticketDto)
        {
            var result = await _ticketRepository.CreateTicket(ticketDto.SiteId, ticketDto.ReasonId, ticketDto.Details);

            if (!result) return BadRequest("We were unable to create your ticket.");

            return Ok();
        }

        [HttpPost("createAssignment")]
        public async Task<ActionResult> CreateAssignmentAsync([FromBody] TicketAssignmentDto ticketAssignmentDto)
        {
            var result = await _ticketRepository.AssignTickets(ticketAssignmentDto);

            if (!result) return BadRequest("We were unable to assign tickets.");

            return Ok();
        }

        [HttpPost("submitTicket")]
        public async Task<ActionResult> SubmitTicketAsync([FromBody] int ticketId)
        {
            var result = await _ticketRepository.UpdateTicketStatus(ticketId, TicketStatusEnum.Submitted);

            if (!result) return BadRequest("We were unable to update your ticket.");

            return Ok();
        }

        [HttpPost("resolveTicket")]
        public async Task<ActionResult> ResolveTicketAsync([FromBody] int ticketId)
        {
            var result = await _ticketRepository.UpdateTicketStatus(ticketId, TicketStatusEnum.Resolved);

            if (!result) return BadRequest("We were unable to update your ticket.");

            return Ok();
        }

        [HttpGet("reasons")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketReasonsAsync()
        {
            var result = await _ticketRepository.GetTicketReasons();

            if (result == null) return BadRequest("We had a problem getting ticket reasons from the database.");

            return Ok(result);
        }
    }
}
