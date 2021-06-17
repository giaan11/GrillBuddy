using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrillBuddy.DTO;

namespace GrillBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
     

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok();
            }
            catch(NotImplementedException e)
            {
                return NotFound();
            }
            
        }

        [HttpGet]
        [Route("GetSingleById{id:int}")]
        public IActionResult GetSingleById(int id)
        {
            try
            {
                return Ok();
            }
            catch (NotImplementedException e)
            {
                return NotFound();
                //_logger.LogError("" + e);
            }
        }


        [HttpPost]
        [Route("CreateNew")]
        public IActionResult Create(LocationDTO location)
        {
            try
            {
                return Ok();
            }
            catch (NotImplementedException e)
            {
                return NotFound();
                //_logger.LogError(""+e);
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(LocationDTO newLocation)
        {
            try
            {
                return Ok();
            }
            catch (NotImplementedException e)
            {
                return NotFound();
                //_logger.LogError("" + e);
            }
        }
        [HttpDelete]
        [Route("RemoveLocation")]
        public IActionResult Remove(LocationDTO toDelete)
        {
            try
            {
                return Ok();
            }
            catch (NotImplementedException e)
            {
                return NotFound();
                //_logger.LogError("" + e);
            }
        }

    }
}
