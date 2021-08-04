using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IsTeknolojiCustomAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;

        public NameController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }

        // GET: api/Name
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "New York", "New Jersey" };
        }

        // GET: api/Name/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "New Jersey";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = customAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
