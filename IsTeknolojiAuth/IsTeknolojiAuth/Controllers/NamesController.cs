using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTeknolojiAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private List<string> DevTeam = new List<string> { "Osman", "Sedat", "Bertan", "Enes", "Onur", "Faiza", "Enech" };

        public NamesController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        // GET: api/Names
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return DevTeam;
        }

        // GET: api/Names/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            try
            {
                return DevTeam[id];
            }
            catch (Exception exp)
            {

                return "Check id "+" => Error : "+exp.Message;
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
