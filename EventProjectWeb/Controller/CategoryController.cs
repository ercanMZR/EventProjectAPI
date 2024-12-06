using EventProjectWeb.DTO.Category;
using EventProjectWeb.DTO.City;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EventProjectContext _db;

        public CategoryController(EventProjectContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllCategoriesResponseDto> categories = _db.Categories.Where(x => x.IsDeleted == false).Select(x => new GetAllCategoriesResponseDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(categories);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (entity == null)
            {
                return NotFound();
            }

            else
            {
                GetCategoryResponseDto model = new GetCategoryResponseDto
                {
                    Id = entity.Id,
                    Name = entity.Name
                };


                return Ok(model);
            }
        }
        //[Authorize]
        [HttpPost]
        public IActionResult Post(CreateCategoryRequestDTO model)
        {
            var entity = new Category
            {
                Name = model.Name,
                

            };

            _db.Categories.Add(entity);
            _db.SaveChanges();
            return Ok(entity);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(entity);
            _db.SaveChanges();
            return Ok();


        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, UpdateCategoryRequestDto model)

        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (entity == null)
            { return NotFound(); }

            else
            {
                entity.Name = model.Name;
                _db.SaveChanges();
                return Ok(model);
            }
        }
    }
}


