using EventProjectWeb.DTO.Artist;
using EventProjectWeb.Model.DTO.Artist;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public ArtistController(EventProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllArtistResponseDTO> artist = _db.Artists.Where(x => x.IsDeleted == false).Select(x => new GetAllArtistResponseDTO
            {
                Id = x.Id,
                ArtistName = x.ArtistName,
            }).ToList();
            return Ok(artist);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _db.Artists.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                GetArtistResponseDTO model = new GetArtistResponseDTO
                {
                    Id = entity.Id,
                    ArtistName = entity.ArtistName,
                };
                return Ok(model);

            }
        }

        [HttpPost]
        public IActionResult Post(CreateArtistRequestDTO model)
        {
            var entity = new Artist
            {
                ArtistName = model.ArtistName,
            };
            _db.Artists.Add(entity);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Artists.FirstOrDefault(x => x.Id == id);
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
        public IActionResult Put(int id, UpdateArtistRequestDTO model)
        {
            var entity = _db.Artists.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.ArtistName = model.ArtistName;
                _db.SaveChanges();
                return Ok(model);
            }
        }
    }
}

