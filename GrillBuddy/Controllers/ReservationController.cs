using GrillBuddy.DTO;
using GrillBuddy.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrillBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ReservationManager.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                return Ok(ReservationManager.GetSingle(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(ReservationDTO reservation)
        {
            return Ok(ReservationManager.Create(reservation));
        }

        [HttpPut("{id}{reservation}")]
        public IActionResult Put(int id, ReservationDTO reservation)
        {
            return Ok(ReservationManager.Edit(id, reservation));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(ReservationManager.Delete(id));
        }
    }
}
