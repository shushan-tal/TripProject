using Dto.dtos;
using Dto.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service1.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IService<CustumerDto> service;
        private readonly IUserLogin login;
        private readonly IConfiguration config;
        public CustomerController(IService<CustumerDto> service, IUserLogin login, IConfiguration config)
        {
            this.service = service;
            this.login = login;
            this.config = config;
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
        [HttpPost("/login")]
        public IActionResult Login([FromForm] UserLogin user)
        {
            //אימות
            CustumerDto user1 = Authenticate(user);
            if (user1 != null)
            {
                string token = GenerateToken(user1);
                return Ok(token);
            }
            return BadRequest("user not found");
        }

        private string GenerateToken(CustumerDto user1)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user1.Name),
            new Claim(ClaimTypes.Email,user1.Mail),
            new Claim(ClaimTypes.PostalCode,user1.Password),
            
            };
            var token = new JwtSecurityToken(config["Jwt:Issure"], config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private CustumerDto Authenticate(UserLogin user)
        {
            return login.getUserBy(user.Name, user.Password);
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
