using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripControllers : ControllerBase
    {
        private readonly IService<TripDto> service;
        public TripControllers(IService<TripDto> service)
        {
            this.service = service;
        }
        // GET: api/<TripControllers>
        [HttpGet]
        public List<TripDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<TripControllers>/5
        [HttpGet("{id}")]
        public TripDto Get(int id)
        {
            return service.GetById(id);
        }
        [HttpGet("/getBy/{price}")]
        public List<TripDto> GetByPrice(int price)
        {
            return service.GetAll().Where(x=>x.Price<price).ToList();
        }

        // POST api/<TripControllers>
        [HttpPost]
        public TripDto Post([FromForm] TripDto trip)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Images", trip.file.FileName);
            using (var stream=new FileStream(path,FileMode.Create))
            {
                trip.file.CopyTo(stream);
            }
            return service.AddItem(trip);
        }

        // PUT api/<TripControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TripControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
