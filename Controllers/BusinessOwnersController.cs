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
    public class BusinessOwnersController : ControllerBase
    {
        private readonly UserContext _context;

        public BusinessOwnersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/BusinessOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessOwner>>> GetBusinessOwners()
        {
            return await _context.BusinessOwners.ToListAsync();
        }

        // GET: api/BusinessOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessOwner>> GetBusinessOwner(int id)
        {
            var businessOwner = await _context.BusinessOwners.FindAsync(id);

            if (businessOwner == null)
            {
                return NotFound();
            }

            return businessOwner;
        }

        // PUT: api/BusinessOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessOwner(int id, BusinessOwner businessOwner)
        {
            if (id != businessOwner.BusinessOwnerId)
            {
                return BadRequest();
            }

            _context.Entry(businessOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessOwnerExists(id))
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

        // POST: api/BusinessOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessOwner>> PostBusinessOwner(BusinessOwner businessOwner)
        {
            _context.BusinessOwners.Add(businessOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessOwner", new { id = businessOwner.BusinessOwnerId }, businessOwner);
        }

        // DELETE: api/BusinessOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessOwner(int id)
        {
            var businessOwner = await _context.BusinessOwners.FindAsync(id);
            if (businessOwner == null)
            {
                return NotFound();
            }

            _context.BusinessOwners.Remove(businessOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessOwnerExists(int id)
        {
            return _context.BusinessOwners.Any(e => e.BusinessOwnerId == id);
        }
    }
}
