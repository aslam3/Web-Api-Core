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
    public class ApplyJobsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public ApplyJobsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/ApplyJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplyJob>>> GetapplyJobs()
        {
            return await _context.applyJobs.ToListAsync();
        }

        // GET: api/ApplyJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplyJob>> GetApplyJob(int id)
        {
            var applyJob = await _context.applyJobs.FindAsync(id);

            if (applyJob == null)
            {
                return NotFound();
            }

            return applyJob;
        }

        // PUT: api/ApplyJobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplyJob(int id, ApplyJob applyJob)
        {
            if (id != applyJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(applyJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplyJobExists(id))
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

        // POST: api/ApplyJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApplyJob>> PostApplyJob(ApplyJob applyJob)
        {
            _context.applyJobs.Add(applyJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplyJob", new { id = applyJob.Id }, applyJob);
        }


        // DELETE: api/ApplyJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplyJob>> DeleteApplyJob(int id)
        {
            var applyJob = await _context.applyJobs.FindAsync(id);
            if (applyJob == null)
            {
                return NotFound();
            }

            _context.applyJobs.Remove(applyJob);
            await _context.SaveChangesAsync();

            return applyJob;
        }

        private bool ApplyJobExists(int id)
        {
            return _context.applyJobs.Any(e => e.Id == id);
        }
    }
}
