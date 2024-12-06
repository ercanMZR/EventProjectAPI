using EventProjectWeb.DTO.Event;
using EventProjectWeb.DTO.Ticket;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public TicketController(EventProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllTicketsResponseDto> model = _db.Tickets.Where(x => x.IsDeleted == false).Select(x => new GetAllTicketsResponseDto
            {
                 TicketType = x.TicketType,
                  Availability = x.Availability,
                   Price = x.Price,
                    SeatNo = x.SeatNo               
            }).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ticket = _db.Tickets.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (ticket == null)
            {
                return NotFound();
            }

            GetTicketResponseDto model = new GetTicketResponseDto();
            model.TicketType = ticket.TicketType;
            model.Availability = ticket.Availability;
            model.Price = ticket.Price;
            model.SeatNo = ticket.SeatNo;

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateTicketRequestDto model)
        {
            var entity = new Ticket
            {
                 TicketType= model.TicketType,
                  SeatNo= model.SeatNo,
                   Price= model.Price,
                    Availability= model.Availability
            };

            _db.Tickets.Add(entity);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Tickets.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.IsDeleted = true;
                _db.SaveChanges();

                return Ok();
            }
        }


        [HttpPut("{id}")] 
        public IActionResult Update(int id, UpdateTicketRequestDto model)
        {
            var ticket = _db.Tickets.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                ticket.TicketType = model.TicketType;
                _db.SaveChanges();

                return Ok(model);
            }
        }
    }
}
