using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.AddressManagement;

namespace JobPortalApp.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceStationsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public PoliceStationsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/PoliceStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliceStation>>> GetpoliceStations()
        {
            return await _context.policeStations.ToListAsync();
        }

        // GET: api/PoliceStations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoliceStation>> GetPoliceStation(int id)
        {
            var policeStation = await _context.policeStations.FindAsync(id);

            if (policeStation == null)
            {
                return NotFound();
            }

            return policeStation;
        }

        // PUT: api/PoliceStations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliceStation(int id, PoliceStation policeStation)
        {
            if (id != policeStation.Id)
            {
                return BadRequest();
            }

            _context.Entry(policeStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceStationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PoliceStations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PoliceStation>> PostPoliceStation(PoliceStation policeStation)
        {
            _context.policeStations.Add(policeStation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoliceStation", new { id = policeStation.Id }, policeStation);
        }

        // DELETE: api/PoliceStations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PoliceStation>> DeletePoliceStation(int id)
        {
            var policeStation = await _context.policeStations.FindAsync(id);
            if (policeStation == null)
            {
                return NotFound();
            }

            _context.policeStations.Remove(policeStation);
            await _context.SaveChangesAsync();

            return policeStation;
        }

        private bool PoliceStationExists(int id)
        {
            return _context.policeStations.Any(e => e.Id == id);
        }
    }
}
