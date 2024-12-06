using EventProjectWeb.Model.ORM;

namespace EventProjectWeb.DTO.Activity
{
    public class CreateActivityRequestDTO
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}