using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models;

namespace JobPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostModeratorsController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public PostModeratorsController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/PostModerators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModerator>>> GetpostModerators()
        {
            return await _context.postModerators.ToListAsync();
        }

        // GET: api/PostModerators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostModerator>> GetPostModerator(int id)
        {
            var postModerator = await _context.postModerators.FindAsync(id);

            if (postModerator == null)
            {
                return NotFound();
            }

            return postModerator;
        }

        // PUT: api/PostModerators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostModerator(int id, PostModerator postModerator)
        {
            if (id != postModerator.Id)
            {
                return BadRequest();
            }

            _context.Entry(postModerator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostModeratorExists(id))
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

        // POST: api/PostModerators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostModerator>> PostPostModerator(PostModerator postModerator)
        {
            _context.postModerators.Add(postModerator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostModerator", new { id = postModerator.Id }, postModerator);
        }

        // DELETE: api/PostModerators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostModerator>> DeletePostModerator(int id)
        {
            var postModerator = await _context.postModerators.FindAsync(id);
            if (postModerator == null)
            {
                return NotFound();
            }

            _context.postModerators.Remove(postModerator);
            await _context.SaveChangesAsync();

            return postModerator;
        }

        private bool PostModeratorExists(int id)
        {
            return _context.postModerators.Any(e => e.Id == id);
        }
    }
}
