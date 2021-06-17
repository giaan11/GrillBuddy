using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppo8.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPut]
        [Route("UpdateUsername")]
        public IActionResult UpdateUsername(string username, string email, string password)
        {
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmail")]
        public IActionResult UpdateEmail(string username, string nuovaemail)
        {
            return Ok();
        }


        [HttpPut]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string newpassword, string oldpassword, string username)
        {
            return Ok();
        }

        [HttpPut]
        [Route("AggiungiATeam")]
        public IActionResult AggiungiATeam(string username, int TeamId)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetSingle")]
        public IActionResult GetSingle(string username)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetSingleWithEventi/{username}")] // non funziona il mapper 
        public IActionResult GetSingleWithEventi(string username)
        {
            return Ok();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("GetAllWithEventi")]  //non funziona il mapper
        public IActionResult GetAllWithEventi()
        {
            return Ok();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetSingleWithPunteggi/{username}")]
        public IActionResult GetSingleWithPunteggi(string username)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAllWithPunteggi")]
        public IActionResult GetAllWithPunteggi()
        {
            return Ok();
        }


    }
    
}
