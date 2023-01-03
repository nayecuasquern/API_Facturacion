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
    public class FactPayTypesController : ControllerBase
    {
        private readonly DbFacturacionContext _context;

        public FactPayTypesController(DbFacturacionContext context)
        {
            _context = context;
        }

        // GET: api/FactPayTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactPayType>>> GetFactPayTypes()
        {
            return await _context.FactPayTypes.ToListAsync();
        }

        // GET: api/FactPayTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactPayType>> GetFactPayType(int id)
        {
            var factPayType = await _context.FactPayTypes.FindAsync(id);

            if (factPayType == null)
            {
                return NotFound();
            }

            return factPayType;
        }

        // PUT: api/FactPayTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactPayType(int id, FactPayType factPayType)
        {
            if (id != factPayType.TypId)
            {
                return BadRequest();
            }

            _context.Entry(factPayType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactPayTypeExists(id))
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

        // POST: api/FactPayTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactPayType>> PostFactPayType(FactPayType factPayType)
        {
            _context.FactPayTypes.Add(factPayType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactPayType", new { id = factPayType.TypId }, factPayType);
        }

        // DELETE: api/FactPayTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactPayType(int id)
        {
            var factPayType = await _context.FactPayTypes.FindAsync(id);
            if (factPayType == null)
            {
                return NotFound();
            }

            _context.FactPayTypes.Remove(factPayType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactPayTypeExists(int id)
        {
            return _context.FactPayTypes.Any(e => e.TypId == id);
        }
    }
}
