using EventProjectWeb.DTO.Artist;
using EventProjectWeb.DTO.City;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public CityController(EventProjectContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllCityResponseDTO> cities = _db.Cities.Where(x => x.IsDeleted == false).Select(x => new GetAllCityResponseDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _db.Cities.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                GetCityResponseDTO model = new GetCityResponseDTO
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
                return Ok(model);
            }
        }
        [HttpPost]
        public IActionResult Post(CreateCityRequestDTO model)
        {
            var entity = new City
            {
                Name = model.Name
            };

            _db.Cities.Add(entity);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Cities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _db.Cities.Remove(entity);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCityRequestDTO model)
        {
            var entity = _db.Cities.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            _db.SaveChanges();
            return Ok(model);
        }
    }
}
