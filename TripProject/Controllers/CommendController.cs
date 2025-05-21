using Dto.dtos;
using Microsoft.AspNetCore.Mvc;
using Service1.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CommendController : ControllerBase
    {
        private readonly IService<CommendDto> service;
        public CommendController(IService<CommendDto> service)
        {
            this.service = service;
        }
        // GET: api/<CommendController>
        [HttpGet]
        public List<CommendDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<CommendController>/5
        [HttpGet("{id}")]
        public CommendDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CommendController>
        [HttpPost]
        public CommendDto Post([FromForm] CommendDto commend)
        {
            return service.AddItem(commend);
        }

        // PUT api/<CommendController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] CommendDto commend)
        {
             service.Update(id,commend);
           
        }

        // DELETE api/<CommendController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
