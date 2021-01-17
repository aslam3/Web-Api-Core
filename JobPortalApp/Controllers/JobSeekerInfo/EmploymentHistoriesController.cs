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
    public class EmploymentHistoriesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public EmploymentHistoriesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/EmploymentHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentHistory>>> GetemploymentHistories()
        {
            return await _context.employmentHistories.ToListAsync();
        }

        // GET: api/EmploymentHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentHistory>> GetEmploymentHistory(int id)
        {
            var employmentHistory = await _context.employmentHistories.FindAsync(id);

            if (employmentHistory == null)
            {
                return NotFound();
            }

            return employmentHistory;
        }

        // PUT: api/EmploymentHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentHistory(int id, EmploymentHistory employmentHistory)
        {
            if (id != employmentHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(employmentHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentHistoryExists(id))
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

        // POST: api/EmploymentHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmploymentHistory>> PostEmploymentHistory(EmploymentHistory employmentHistory)
        {
            _context.employmentHistories.Add(employmentHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentHistory", new { id = employmentHistory.Id }, employmentHistory);
        }

        // DELETE: api/EmploymentHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmploymentHistory>> DeleteEmploymentHistory(int id)
        {
            var employmentHistory = await _context.employmentHistories.FindAsync(id);
            if (employmentHistory == null)
            {
                return NotFound();
            }

            _context.employmentHistories.Remove(employmentHistory);
            await _context.SaveChangesAsync();

            return employmentHistory;
        }

        private bool EmploymentHistoryExists(int id)
        {
            return _context.employmentHistories.Any(e => e.Id == id);
        }
    }
}
