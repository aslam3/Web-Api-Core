using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.JobSeekerInfo;

namespace JobPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerInformationsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public CareerInformationsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/CareerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareerInformation>>> GetcareerInformation()
        {
            return await _context.careerInformation.ToListAsync();
        }

        // GET: api/CareerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareerInformation>> GetCareerInformation(int id)
        {
            var careerInformation = await _context.careerInformation.FindAsync(id);

            if (careerInformation == null)
            {
                return NotFound();
            }

            return careerInformation;
        }

        // PUT: api/CareerInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerInformation(int id, CareerInformation careerInformation)
        {
            if (id != careerInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(careerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerInformationExists(id))
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

        // POST: api/CareerInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CareerInformation>> PostCareerInformation(CareerInformation careerInformation)
        {
            _context.careerInformation.Add(careerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerInformation", new { id = careerInformation.Id }, careerInformation);
        }

        // DELETE: api/CareerInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CareerInformation>> DeleteCareerInformation(int id)
        {
            var careerInformation = await _context.careerInformation.FindAsync(id);
            if (careerInformation == null)
            {
                return NotFound();
            }

            _context.careerInformation.Remove(careerInformation);
            await _context.SaveChangesAsync();

            return careerInformation;
        }

        private bool CareerInformationExists(int id)
        {
            return _context.careerInformation.Any(e => e.Id == id);
        }
    }
}
