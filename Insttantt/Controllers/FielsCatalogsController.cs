using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insttantt.Context;
using Insttantt.Models;

namespace Insttantt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FielsCatalogsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FielsCatalogsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/FielsCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FielsCatalog>>> GetFielsCatalogs()
        {
          if (_context.FielsCatalogs == null)
          {
              return NotFound();
          }
            return await _context.FielsCatalogs.ToListAsync();
        }

        // GET: api/FielsCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FielsCatalog>> GetFielsCatalog(Guid id)
        {
          if (_context.FielsCatalogs == null)
          {
              return NotFound();
          }
            var fielsCatalog = await _context.FielsCatalogs.FindAsync(id);

            if (fielsCatalog == null)
            {
                return NotFound();
            }

            return fielsCatalog;
        }

        // PUT: api/FielsCatalogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFielsCatalog(Guid id, FielsCatalog fielsCatalog)
        {
            if (id != fielsCatalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(fielsCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FielsCatalogExists(id))
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

        // POST: api/FielsCatalogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FielsCatalog>> PostFielsCatalog(FielsCatalog fielsCatalog)
        {
          if (_context.FielsCatalogs == null)
          {
              return Problem("Entity set 'ApplicationContext.FielsCatalogs'  is null.");
          }
            _context.FielsCatalogs.Add(fielsCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFielsCatalog", new { id = fielsCatalog.Id }, fielsCatalog);
        }

        // DELETE: api/FielsCatalogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFielsCatalog(Guid id)
        {
            if (_context.FielsCatalogs == null)
            {
                return NotFound();
            }
            var fielsCatalog = await _context.FielsCatalogs.FindAsync(id);
            if (fielsCatalog == null)
            {
                return NotFound();
            }

            _context.FielsCatalogs.Remove(fielsCatalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FielsCatalogExists(Guid id)
        {
            return (_context.FielsCatalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
