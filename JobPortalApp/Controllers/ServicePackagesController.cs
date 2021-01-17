using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.JobProviderAreas;

namespace JobPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackagesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public ServicePackagesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/ServicePackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packages>>> GetservicePackages()
        {
            return await _context.servicePackages.ToListAsync();
        }

        // GET: api/ServicePackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Packages>> GetServicePackages(int id)
        {
            var servicePackages = await _context.servicePackages.FindAsync(id);

            if (servicePackages == null)
            {
                return NotFound();
            }

            return servicePackages;
        }

        // PUT: api/ServicePackages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicePackages(int id, Packages servicePackages)
        {
            if (id != servicePackages.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicePackages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePackagesExists(id))
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

        // POST: api/ServicePackages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Packages>> PostServicePackages(Packages servicePackages)
        {
            _context.servicePackages.Add(servicePackages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicePackages", new { id = servicePackages.Id }, servicePackages);
        }

        // DELETE: api/ServicePackages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Packages>> DeleteServicePackages(int id)
        {
            var servicePackages = await _context.servicePackages.FindAsync(id);
            if (servicePackages == null)
            {
                return NotFound();
            }

            _context.servicePackages.Remove(servicePackages);
            await _context.SaveChangesAsync();

            return servicePackages;
        }

        private bool ServicePackagesExists(int id)
        {
            return _context.servicePackages.Any(e => e.Id == id);
        }
    }
}
