using System;
using Haversine.Data;
using Haversine.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Haversine.WebApi.Controllers
{
    [Route("api/location")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repository;

        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var locations = _repository.GetAllLocations();

                return Ok(locations);
            }
            catch (Exception ex)
            {
                // TODO: Log the exception...
            }

            // If all else fails...
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get(double latitude, double longitude)
        {

        }
    }
}
