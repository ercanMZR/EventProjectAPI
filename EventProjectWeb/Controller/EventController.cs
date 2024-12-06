using EventProjectWeb.DTO.Event;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventProjectContext _db;

        public EventController(EventProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllEventsResponseDto> model = _db.Events
                .Where(x => !x.IsDeleted)
                .Select(x => new GetAllEventsResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    DetailedDescription = x.DetailedDescription,
                    GoogleMapLink = x.GoogleMapLink
                })
                .ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _event = _db.Events.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (_event == null)
            {
                return NotFound();
            }

            GetEventResponseDto model = new GetEventResponseDto
            {
                Id = _event.Id,
                Name = _event.Name,
                Address = _event.Address,
                DetailedDescription = _event.DetailedDescription,
                GoogleMapLink = _event.GoogleMapLink
            };

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateEventRequestDto model)
        {
            List<string> imagePaths = new List<string>();

            foreach (var image in model.Images)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                imagePaths.Add(image.FileName);
            }

            var entity = new Event
            {
                Name = model.Name,
                DetailedDescription = model.DetailedDescription,
                Address = model.Address
            };

            _db.Events.Add(entity);
            _db.SaveChanges();

            foreach (var imagePath in imagePaths)
            {
                var eventImage = new ActivityEventImages 
                {
                    EventId = entity.Id,
                    ImagePath = imagePath
                };

                _db.Activities.Add(eventImage);
            }

            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Events.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.IsDeleted = true;
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateEventRequestDto model)
        {
            var _event = _db.Events.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (_event == null)
            {
                return NotFound();
            }

            _event.Name = model.Name;
            _db.SaveChanges();

            return Ok(model);
        }
    }
}
