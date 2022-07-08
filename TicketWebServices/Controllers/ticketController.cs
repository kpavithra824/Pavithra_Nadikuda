using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWebServices.ViewModel;

namespace TicketWebServices.Controllers
{
    [Route("api/1.0/flight/ticket")]
    [ApiController]
    public class ticketController : ControllerBase
    {

        private readonly IBus bus;
        public ticketController(IBus _bus)
        {
            bus = _bus;
        }

        [HttpGet]
        //[Route("getData")]
        public IActionResult getData(int pnr)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.BookedOn = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/ticketqueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(endpoint);
                return Ok();
            }

            return BadRequest();
        }


    }
}
