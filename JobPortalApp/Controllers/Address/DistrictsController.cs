using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.AddressManagement;
using Microsoft.AspNetCore.Authorization;

namespace JobPortalApp.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]    
    public class DistrictsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public DistrictsController(jobdbcontext context)
        {
            _context = context;
        }


        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> Getdistricts()
        {
            return await _context.districts.ToListAsync();
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(int id)
        {
            var district = await _context.districts.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }

        // PUT: api/Districts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict(int id, District district)
        {
            if (id != district.Id)
            {
                return BadRequest();
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
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

        // POST: api/Districts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
            _context.districts.Add(district);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistrict", new { id = district.Id }, district);
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<District>> DeleteDistrict(int id)
        {
            var district = await _context.districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.districts.Remove(district);
            await _context.SaveChangesAsync();

            return district;
        }

        private bool DistrictExists(int id)
        {
            return _context.districts.Any(e => e.Id == id);
        }
    }
}
