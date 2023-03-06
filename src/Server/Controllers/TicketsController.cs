﻿using CanidateApp.Server.Infrastructure.Interfaces;
using CanidateApp.Server.Persistence;
using CanidateApp.Shared;
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

        [HttpGet("bySiteId")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsBySiteIdAsync(Guid siteId)
        {
            var result = await _ticketRepository.GetOpenTicketsBySiteId(siteId);

            if (result == null) return BadRequest("We had a problem getting tickets related to this site.");

            return Ok(result);
        }

        [HttpPost("createTicket")]
        public async Task<ActionResult> CreateTicket([FromBody] TicketDto ticketDto)
        {
            var result = await _ticketRepository.CreateTicket(ticketDto.SiteId, ticketDto.ReasonId, ticketDto.Details);

            if (!result) return BadRequest("We were unable to create your ticket.");

            return Ok();
        }
    }
}