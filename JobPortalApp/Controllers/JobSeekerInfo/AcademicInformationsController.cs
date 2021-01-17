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
    public class AcademicInformationsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public AcademicInformationsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/AcademicInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicInformation>>> GetacademicInformation()
        {
            return await _context.academicInformation.ToListAsync();
        }

        // GET: api/AcademicInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicInformation>> GetAcademicInformation(int id)
        {
            var academicInformation = await _context.academicInformation.FindAsync(id);

            if (academicInformation == null)
            {
                return NotFound();
            }

            return academicInformation;
        }

        // PUT: api/AcademicInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicInformation(int id, AcademicInformation academicInformation)
        {
            if (id != academicInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(academicInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicInformationExists(id))
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

        // POST: api/AcademicInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AcademicInformation>> PostAcademicInformation(AcademicInformation academicInformation)
        {
            _context.academicInformation.Add(academicInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicInformation", new { id = academicInformation.Id }, academicInformation);
        }

        // DELETE: api/AcademicInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicInformation>> DeleteAcademicInformation(int id)
        {
            var academicInformation = await _context.academicInformation.FindAsync(id);
            if (academicInformation == null)
            {
                return NotFound();
            }

            _context.academicInformation.Remove(academicInformation);
            await _context.SaveChangesAsync();

            return academicInformation;
        }

        private bool AcademicInformationExists(int id)
        {
            return _context.academicInformation.Any(e => e.Id == id);
        }
    }
}
