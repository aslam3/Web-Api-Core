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
    public class InvoicesController : ControllerBase
    {
        private readonly jobdbcontext _context;

        public InvoicesController(jobdbcontext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> Getinvoices()
        {
            return await _context.invoices.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            var invoice = await _context.invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(int id)
        {
            return _context.invoices.Any(e => e.Id == id);
        }
    }
}
