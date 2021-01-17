using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.AppUser;

namespace JJobPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public JobSeekersController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/JobSeekers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSeekerUser>>> GetjobSeekers()
        {
            return await _context.jobSeekerUsers.ToListAsync();
        }

        // GET: api/JobSeekers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeekerUser>> GetJobSeeker(int id)
        {
            var jobSeeker = await _context.jobSeekerUsers.FindAsync(id);

            if (jobSeeker == null)
            {
                return NotFound();
            }

            return jobSeeker;
        }

        // PUT: api/JobSeekers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSeeker(int id, JobSeekerUser jobSeeker)
        {
            if (id != jobSeeker.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobSeeker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerExists(id))
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

        // POST: api/JobSeekers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobSeekerUser>> PostJobSeeker(JobSeekerUser jobSeeker)
        {
            _context.jobSeekerUsers.Add(jobSeeker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobSeeker", new { id = jobSeeker.Id }, jobSeeker);
        }

        // DELETE: api/JobSeekers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobSeekerUser>> DeleteJobSeeker(int id)
        {
            var jobSeeker = await _context.jobSeekerUsers.FindAsync(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            _context.jobSeekerUsers.Remove(jobSeeker);
            await _context.SaveChangesAsync();

            return jobSeeker;
        }

        private bool JobSeekerExists(int id)
        {
            return _context.jobSeekerUsers.Any(e => e.Id == id);
        }
    }
}
