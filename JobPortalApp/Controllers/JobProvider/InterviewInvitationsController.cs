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
    public class InterviewInvitationsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public InterviewInvitationsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/InterviewInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewInvitation>>> GetinterviewInvitations()
        {
            return await _context.interviewInvitations.ToListAsync();
        }

        // GET: api/InterviewInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewInvitation>> GetInterviewInvitation(int id)
        {
            var interviewInvitation = await _context.interviewInvitations.FindAsync(id);

            if (interviewInvitation == null)
            {
                return NotFound();
            }

            return interviewInvitation;
        }

        // PUT: api/InterviewInvitations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewInvitation(int id, InterviewInvitation interviewInvitation)
        {
            if (id != interviewInvitation.Id)
            {
                return BadRequest();
            }

            _context.Entry(interviewInvitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewInvitationExists(id))
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

        // POST: api/InterviewInvitations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InterviewInvitation>> PostInterviewInvitation(InterviewInvitation interviewInvitation)
        {
            _context.interviewInvitations.Add(interviewInvitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewInvitation", new { id = interviewInvitation.Id }, interviewInvitation);
        }

        // DELETE: api/InterviewInvitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InterviewInvitation>> DeleteInterviewInvitation(int id)
        {
            var interviewInvitation = await _context.interviewInvitations.FindAsync(id);
            if (interviewInvitation == null)
            {
                return NotFound();
            }

            _context.interviewInvitations.Remove(interviewInvitation);
            await _context.SaveChangesAsync();

            return interviewInvitation;
        }

        private bool InterviewInvitationExists(int id)
        {
            return _context.interviewInvitations.Any(e => e.Id == id);
        }
    }
}
