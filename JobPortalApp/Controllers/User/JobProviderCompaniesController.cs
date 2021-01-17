using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models.AppUser;

namespace JobPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProviderCompaniesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public JobProviderCompaniesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/JobProviderCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobProviderUser>>> GetjobProviderCompanies()
        {
            return await _context.jobProviderCompanies.ToListAsync();
        }

        // GET: api/JobProviderCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobProviderUser>> GetJobProviderCompany(int id)
        {
            var jobProviderCompany = await _context.jobProviderCompanies.FindAsync(id);

            if (jobProviderCompany == null)
            {
                return NotFound();
            }

            return jobProviderCompany;
        }

        // PUT: api/JobProviderCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobProviderCompany(int id, JobProviderUser jobProviderCompany)
        {
            if (id != jobProviderCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobProviderCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobProviderCompanyExists(id))
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

        // POST: api/JobProviderCompanies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobProviderUser>> PostJobProviderCompany(JobProviderUser jobProviderCompany)
        {
            _context.jobProviderCompanies.Add(jobProviderCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobProviderCompany", new { id = jobProviderCompany.Id }, jobProviderCompany);
        }

        // DELETE: api/JobProviderCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobProviderUser>> DeleteJobProviderCompany(int id)
        {
            var jobProviderCompany = await _context.jobProviderCompanies.FindAsync(id);
            if (jobProviderCompany == null)
            {
                return NotFound();
            }

            _context.jobProviderCompanies.Remove(jobProviderCompany);
            await _context.SaveChangesAsync();

            return jobProviderCompany;
        }

        private bool JobProviderCompanyExists(int id)
        {
            return _context.jobProviderCompanies.Any(e => e.Id == id);
        }
    }
}
