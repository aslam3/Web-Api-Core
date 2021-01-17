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
    public class DegreeInfoesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public DegreeInfoesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/DegreeInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DegreeInfo>>> GetdegreeInfos()
        {
            return await _context.degreeInfos.ToListAsync();
        }

        // GET: api/DegreeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DegreeInfo>> GetDegreeInfo(int id)
        {
            var degreeInfo = await _context.degreeInfos.FindAsync(id);

            if (degreeInfo == null)
            {
                return NotFound();
            }

            return degreeInfo;
        }

        // PUT: api/DegreeInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDegreeInfo(int id, DegreeInfo degreeInfo)
        {
            if (id != degreeInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(degreeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeInfoExists(id))
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

        // POST: api/DegreeInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DegreeInfo>> PostDegreeInfo(DegreeInfo degreeInfo)
        {
            _context.degreeInfos.Add(degreeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDegreeInfo", new { id = degreeInfo.Id }, degreeInfo);
        }

        // DELETE: api/DegreeInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DegreeInfo>> DeleteDegreeInfo(int id)
        {
            var degreeInfo = await _context.degreeInfos.FindAsync(id);
            if (degreeInfo == null)
            {
                return NotFound();
            }

            _context.degreeInfos.Remove(degreeInfo);
            await _context.SaveChangesAsync();

            return degreeInfo;
        }

        private bool DegreeInfoExists(int id)
        {
            return _context.degreeInfos.Any(e => e.Id == id);
        }
    }
}
