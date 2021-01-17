using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.JobSeekerInfo;

namespace JobPortalApp.Controllers.JobSeeker
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public EducationLevelsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/EducationLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationLevel>>> GeteducationLevels()
        {
            return await _context.educationLevels.ToListAsync();
        }

        // GET: api/EducationLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevel>> GetEducationLevel(int id)
        {
            var educationLevel = await _context.educationLevels.FindAsync(id);

            if (educationLevel == null)
            {
                return NotFound();
            }

            return educationLevel;
        }

        // PUT: api/EducationLevels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel(int id, EducationLevel educationLevel)
        {
            if (id != educationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
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

        // POST: api/EducationLevels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EducationLevel>> PostEducationLevel(EducationLevel educationLevel)
        {
            _context.educationLevels.Add(educationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.Id }, educationLevel);
        }

        // DELETE: api/EducationLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationLevel>> DeleteEducationLevel(int id)
        {
            var educationLevel = await _context.educationLevels.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _context.educationLevels.Remove(educationLevel);
            await _context.SaveChangesAsync();

            return educationLevel;
        }

        private bool EducationLevelExists(int id)
        {
            return _context.educationLevels.Any(e => e.Id == id);
        }
    }
}
