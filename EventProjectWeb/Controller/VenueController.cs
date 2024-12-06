using EventProjectWeb.DTO.Ticket;
using EventProjectWeb.DTO.Venue;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public VenueController(EventProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllVenuesResponseDto> model = _db.Venues.Where(x => x.IsDeleted == false).Select(x => new GetAllVenuesResponseDto
            {
                 VenueName=x.VenueName,
                  Capacity=x.Capacity,
                   Location=x.Location
            }).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venue = _db.Venues.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (venue == null)
            {
                return NotFound();
            }

            GetVenueResponseDto model = new GetVenueResponseDto();
            model.VenueName= venue.VenueName; 
            model.Capacity= venue.Capacity; 
            model.Location= venue.Location;

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateVenueRequestDto model)
        {
            var entity = new Venue
            {
                VenueName = model.VenueName,
                Capacity = model.Capacity,
                Location = model.Location
            };

            _db.Venues.Add(entity);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Venues.FirstOrDefault(x => x.Id == id);

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
        public IActionResult Update(int id, UpdateVenueRequestDto model)
        {
            var venue = _db.Venues.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                venue.VenueName = model.VenueName;
                _db.SaveChanges();

                return Ok(model);
            }
        }
    }
}
