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
    public class JobPostsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public JobPostsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/JobPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPost>>> GetjobPosts()
        {
            return await _context.jobPosts.ToListAsync();
        }

        // GET: api/JobPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPost>> GetJobPost(int id)
        {
            var jobPost = await _context.jobPosts.FindAsync(id);

            if (jobPost == null)
            {
                return NotFound();
            }

            return jobPost;
        }

        // PUT: api/JobPosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPost(int id, JobPost jobPost)
        {
            if (id != jobPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostExists(id))
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

        // POST: api/JobPosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobPost>> PostJobPost(JobPost jobPost)
        {
            _context.jobPosts.Add(jobPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPost", new { id = jobPost.Id }, jobPost);
        }

        // DELETE: api/JobPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobPost>> DeleteJobPost(int id)
        {
            var jobPost = await _context.jobPosts.FindAsync(id);
            if (jobPost == null)
            {
                return NotFound();
            }

            _context.jobPosts.Remove(jobPost);
            await _context.SaveChangesAsync();

            return jobPost;
        }

        private bool JobPostExists(int id)
        {
            return _context.jobPosts.Any(e => e.Id == id);
        }
    }
}
