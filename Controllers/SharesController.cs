using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETradingAPI.models;

namespace ETradingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private readonly UserContext _context;

        public SharesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Shares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Share>>> GetShares()
        {
            return await _context.Shares.ToListAsync();
        }

        // GET: api/Shares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Share>> GetShares(int id)
        {
            var shares = await _context.Shares.FindAsync(id);

            if (shares == null)
            {
                return NotFound();
            }

            return shares;
        }

        // PUT: api/Shares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShares(int id, Share shares)
        {
            if (id != shares.ShareId)
            {
                return BadRequest();
            }

            _context.Entry(shares).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SharesExists(id))
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

        // POST: api/Shares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Share>> PostShares(Share shares)
        {
            _context.Shares.Add(shares);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShares", new { id = shares.ShareId }, shares);
        }

        // DELETE: api/Shares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShares(int id)
        {
            var shares = await _context.Shares.FindAsync(id);
            if (shares == null)
            {
                return NotFound();
            }

            _context.Shares.Remove(shares);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SharesExists(int id)
        {
            return _context.Shares.Any(e => e.ShareId == id);
        }
    }
}
