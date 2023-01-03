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
    public class FactInvoiceDetailsController : ControllerBase
    {
        private readonly DbFacturacionContext _context;

        public FactInvoiceDetailsController(DbFacturacionContext context)
        {
            _context = context;
        }

        // GET: api/FactInvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactInvoiceDetail>>> GetFactInvoiceDetails()
        {
            return await _context.FactInvoiceDetails.ToListAsync();
        }

        // GET: api/FactInvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactInvoiceDetail>> GetFactInvoiceDetail(int id)
        {
            var factInvoiceDetail = await _context.FactInvoiceDetails.FindAsync(id);

            if (factInvoiceDetail == null)
            {
                return NotFound();
            }

            return factInvoiceDetail;
        }

        // PUT: api/FactInvoiceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactInvoiceDetail(int id, FactInvoiceDetail factInvoiceDetail)
        {
            if (id != factInvoiceDetail.InvoiceDetailId)
            {
                return BadRequest();
            }

            _context.Entry(factInvoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactInvoiceDetailExists(id))
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

        // POST: api/FactInvoiceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactInvoiceDetail>> PostFactInvoiceDetail(FactInvoiceDetail factInvoiceDetail)
        {
            _context.FactInvoiceDetails.Add(factInvoiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactInvoiceDetail", new { id = factInvoiceDetail.InvoiceDetailId }, factInvoiceDetail);
        }

        // DELETE: api/FactInvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactInvoiceDetail(int id)
        {
            var factInvoiceDetail = await _context.FactInvoiceDetails.FindAsync(id);
            if (factInvoiceDetail == null)
            {
                return NotFound();
            }

            _context.FactInvoiceDetails.Remove(factInvoiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactInvoiceDetailExists(int id)
        {
            return _context.FactInvoiceDetails.Any(e => e.InvoiceDetailId == id);
        }
    }
}
