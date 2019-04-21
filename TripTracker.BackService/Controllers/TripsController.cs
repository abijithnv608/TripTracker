using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Data;
using TripTracker.BackService.Models;
namespace TripTracker.BackService.Controllers
{
    [Produces("application/json")]
    [Route("api/Trips")]
    public class TripsController : ControllerBase
    {

        private readonly TripContext _context;
        public TripsController(TripContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        // GET: api/Trips
        [HttpGet]
        public IActionResult Get()

        {
            var trips = _context.Trips.ToList();
            return Ok(trips);
        }

        // GET: api/Trips/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
           var trip= _context.Trips.Find(id);
            return Ok(trip);
        }
        
        // POST: api/Trips
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(value);
            _context.SaveChanges();
            return Ok();
        }
        
        // PUT: api/Trips/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Trip value)
        {
            if(!_context.Trips.Any(t=>t.Id==id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Update(value);
            _context.SaveChanges();
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _context.Trips.Find(id);
            if(myTrip==null)
            {
                return NotFound();
            }
            _context.Trips.Remove(myTrip);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
