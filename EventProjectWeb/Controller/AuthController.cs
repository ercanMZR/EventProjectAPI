using EventProjectWeb.DTO;
using EventProjectWeb.Model.Auth;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public AuthController(EventProjectContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Post(LoginRequestDTO model)
        {
            var user = _db.AdminUsers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }
            else
            {
                var token = EventTokenHandler.CreateToken(user.Email);
                return Ok(token);
            }
            
        }
    }
}
