using GrillBuddy.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrillBuddy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetSingle")]
        public IActionResult GetSingle(string id)
        {
            try
            {
                return Ok(UserManager.GetSingle(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(UserManager.GetAll());
        }

    }
    
}
