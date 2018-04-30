using System.Collections.Generic;
using AutoMapper;
using Haversine.Data;
using Haversine.Service;
using Haversine.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Haversine.WebApi.Controllers
{
    [Route("api/location")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repository;
        private readonly ILocator _locator;

        public LocationController(ILocationRepository repository, ILocator locator)
        {
            _repository = repository;
            _locator = locator;
        }

        // GET: api/location
        [HttpGet]
        public IActionResult Get()
        {
            var locationEntities = _repository.GetAllLocations();

            if (locationEntities == null)
            {
                return NotFound();
            }

            var locations = Mapper.Map<IEnumerable<Location>>(locationEntities);

            return Ok(locations);
        }

        // GET: api/location/chesterfield
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var locationEntity = _repository.GetLocation(name);

            if (locationEntity == null)
            {
                return NotFound();
            }

            var location = Mapper.Map<Location>(locationEntity);

            return Ok(location);
        }

        // GET: api/location/nearest?latitude=53.235048&longitude=-1.421629
        [HttpGet("nearest")]
        public IActionResult GetNearestTo([FromQuery] Origin origin)
        {
            if (origin == null) return BadRequest();

            var coordinate = Mapper.Map<Service.Models.Coordinate>(origin);
            var locationEntities = _repository.GetAllLocations();

            if (locationEntities == null)
            {
                return NotFound();
            }

            var locations = Mapper.Map<IEnumerable<Service.Models.Location>>(locationEntities);

            var destination = _locator.GetNearestTo(coordinate, locations);

            var result = Mapper.Map<Destination>(destination);

            return Ok(result);
        }

        // GET: api/location/farthest?latitude=53.235048&longitude=-1.421629
        [HttpGet("farthest")]
        public IActionResult GetFarthestFrom([FromQuery] Origin origin)
        {
            if (origin == null) return BadRequest();

            var coordinate = Mapper.Map<Service.Models.Coordinate>(origin);
            var locationEntities = _repository.GetAllLocations();

            if (locationEntities == null)
            {
                return NotFound();
            }

            var locations = Mapper.Map<IEnumerable<Service.Models.Location>>(locationEntities);

            var destination = _locator.GetFarthestFrom(coordinate, locations);

            var result = Mapper.Map<Destination>(destination);

            return Ok(result);
        }
    }
}
