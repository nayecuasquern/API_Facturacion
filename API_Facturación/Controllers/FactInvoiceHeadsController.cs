using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FActuración.Entidades;

namespace API_FActuración.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactInvoiceHeadsController : ControllerBase
    {
        private readonly DbFacturacionContext _context;

        public FactInvoiceHeadsController(DbFacturacionContext context)
        {
            _context = context;
        }

        // GET: api/FactInvoiceHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactInvoiceHead>>> GetFactInvoiceHeads()
        {
            return await _context.FactInvoiceHeads.ToListAsync();
        }

        // GET: api/FactInvoiceHeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactInvoiceHead>> GetFactInvoiceHead(int id)
        {
            var factInvoiceHead = await _context.FactInvoiceHeads.FindAsync(id);

            if (factInvoiceHead == null)
            {
                return NotFound();
            }

            return factInvoiceHead;
        }

        // PUT: api/FactInvoiceHeads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactInvoiceHead(int id, FactInvoiceHead factInvoiceHead)
        {
            if (id != factInvoiceHead.InvoiceHeadId)
            {
                return BadRequest();
            }

            _context.Entry(factInvoiceHead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactInvoiceHeadExists(id))
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

        // POST: api/FactInvoiceHeads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactInvoiceHead>> PostFactInvoiceHead(FactInvoiceHead factInvoiceHead)
        {
            _context.FactInvoiceHeads.Add(factInvoiceHead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactInvoiceHead", new { id = factInvoiceHead.InvoiceHeadId }, factInvoiceHead);
        }

        // DELETE: api/FactInvoiceHeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactInvoiceHead(int id)
        {
            var factInvoiceHead = await _context.FactInvoiceHeads.FindAsync(id);
            if (factInvoiceHead == null)
            {
                return NotFound();
            }

            _context.FactInvoiceHeads.Remove(factInvoiceHead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactInvoiceHeadExists(int id)
        {
            return _context.FactInvoiceHeads.Any(e => e.InvoiceHeadId == id);
        }
    }
}
