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
    public class BusinessCategoriesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public BusinessCategoriesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/BusinessCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessCategory>>> GetbusinessCategories()
        {
            return await _context.businessCategories.ToListAsync();
        }

        // GET: api/BusinessCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCategory>> GetBusinessCategory(int id)
        {
            var businessCategory = await _context.businessCategories.FindAsync(id);

            if (businessCategory == null)
            {
                return NotFound();
            }

            return businessCategory;
        }

        // PUT: api/BusinessCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessCategory(int id, BusinessCategory businessCategory)
        {
            if (id != businessCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessCategoryExists(id))
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

        // POST: api/BusinessCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessCategory>> PostBusinessCategory(BusinessCategory businessCategory)
        {
            _context.businessCategories.Add(businessCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessCategory", new { id = businessCategory.Id }, businessCategory);
        }

        // DELETE: api/BusinessCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessCategory>> DeleteBusinessCategory(int id)
        {
            var businessCategory = await _context.businessCategories.FindAsync(id);
            if (businessCategory == null)
            {
                return NotFound();
            }

            _context.businessCategories.Remove(businessCategory);
            await _context.SaveChangesAsync();

            return businessCategory;
        }

        private bool BusinessCategoryExists(int id)
        {
            return _context.businessCategories.Any(e => e.Id == id);
        }
    }
}
