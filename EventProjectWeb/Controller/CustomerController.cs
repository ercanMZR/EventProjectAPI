using EventProjectWeb.DTO.City;
using EventProjectWeb.DTO.Customer;
using EventProjectWeb.Model.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EventProjectContext _db;
        public CustomerController(EventProjectContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllCustomerResponseDTO> customers = _db.Customers
                .Where(x => !x.IsDeleted)
                .Select(x => new GetAllCustomerResponseDTO
                {
                    CustomerName = x.CustomerName,
                    Email = x.Email,
                    Phone = x.Phone,
                    Address = x.Address
                }).ToList();

            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (customer == null)
            {
                return NotFound();
            }

            GetCustomerResponseDTO model = new GetCustomerResponseDTO
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Post(CreateCustomerRequestDTO model)

        {
            var entity = new Customer
            {
                CustomerName=model.CustomerName,
                Email =model.Email,
                Address=model.Address
                
            };
            _db.Customers.Add(entity);
            _db.SaveChanges();
            return Ok(entity);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Customers.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.IsDeleted = true;
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCustomerRequestDTO model)
        {
            var entity = _db.Customers.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CustomerName = model.CustomerName;
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Address = model.Address;

            _db.SaveChanges();
            return Ok(model);
        }
    }
}
