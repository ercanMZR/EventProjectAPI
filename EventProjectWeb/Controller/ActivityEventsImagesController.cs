using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using EventProjectWeb.DTO.Activity;
using EventProjectWeb.Model.ORM;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityEventsImagesController : ControllerBase
    {
        private readonly EventProjectContext _db;
        private readonly IWebHostEnvironment _env;

        public ActivityEventsImagesController(EventProjectContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpPost]
        public IActionResult Post(CreateActivityRequestDTO model)
        {
            List<string> imagePaths = new List<string>();
            foreach (var image in model.Images)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(_env.WebRootPath, "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                imagePaths.Add(fileName);
            }
            return Ok(new { imagePaths });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var imagesDirectory = Path.Combine(_env.WebRootPath, "images");
            var imageFiles = Directory.GetFiles(imagesDirectory);
            var imagePaths = new List<string>();

            foreach (var imageFile in imageFiles)
            {
                var fileName = Path.GetFileName(imageFile);
                var fileUrl = $"/images/{fileName}";
                imagePaths.Add(fileUrl);
            }

            return Ok(new { imagePaths });
        }
    }
}