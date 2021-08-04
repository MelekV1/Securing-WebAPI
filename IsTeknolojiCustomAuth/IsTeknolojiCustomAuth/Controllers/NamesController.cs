using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTeknolojiCustomAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTeknolojiCustomAuth.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NamesController : ControllerBase
    {
        //private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly ICustomAuthenticationManager customAuthenticationManager;
        private List<string> DevTeam = new List<string> { "Osman", "Sedat", "Bertan", "Enes", "Onur", "Faiza", "Enech" };

        public NamesController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
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

                return "Check id " + " => Error : " + exp.Message;
            }
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
