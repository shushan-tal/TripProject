using Dto.dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IService<CustumerDto> service;
        public CustomerController(IService<CustumerDto> service)
        {
            this.service = service;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public List<CustumerDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustumerDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public CustumerDto Post([FromForm] CustumerDto custumer)
        {
            return service.AddItem(custumer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] CustumerDto custumer)
        {
            service.Update(id, custumer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
