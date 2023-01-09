using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FActuración.Entidades;
using Microsoft.AspNetCore.Cors;

namespace APIFActuración.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactClientsController : ControllerBase
    {

        private readonly DbFacturacionContext _context;

        public FactClientsController(DbFacturacionContext context)
        {
            _context = context;
        }

        [EnableCors("MyAllowSpecificOrigins")]
        // GET: api/FactClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactClient>>> GetFactClients()
        {
            return await _context.FactClients.ToListAsync();
        }

        // GET: api/FactClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactClient>> GetFactClient(string id)
        {
            var factClient = await _context.FactClients.FindAsync(id);

            if (factClient == null)
            {
                return NotFound();
            }

            return factClient;
        }

        // PUT: api/FactClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactClient(string id, FactClient factClient)
        {
            if (id != factClient.CliIdentification)
            {
                return BadRequest();
            }

            _context.Entry(factClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactClientExists(id))
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

        // POST: api/FactClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactClient>> PostFactClient(FactClient factClient)
        {
            _context.FactClients.Add(factClient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FactClientExists(factClient.CliIdentification))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFactClient", new { id = factClient.CliIdentification }, factClient);
        }

        // DELETE: api/FactClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactClient(string id)
        {
            var factClient = await _context.FactClients.FindAsync(id);
            if (factClient == null)
            {
                return NotFound();
            }

            _context.FactClients.Remove(factClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactClientExists(string id)
        {
            return _context.FactClients.Any(e => e.CliIdentification == id);
        }
    }
}
