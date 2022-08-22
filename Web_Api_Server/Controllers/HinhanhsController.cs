using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhanhsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public HinhanhsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Hinhanhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hinhanh>>> GetHinhanhs()
        {
          if (_context.Hinhanhs == null)
          {
              return NotFound();
          }
            return await _context.Hinhanhs.ToListAsync();
        }

        // GET: api/Hinhanhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hinhanh>> GetHinhanh(string id)
        {
          if (_context.Hinhanhs == null)
          {
              return NotFound();
          }
            var hinhanh = await _context.Hinhanhs.FindAsync(id);

            if (hinhanh == null)
            {
                return NotFound();
            }

            return hinhanh;
        }

        // PUT: api/Hinhanhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHinhanh(string id, Hinhanh hinhanh)
        {
            if (id != hinhanh.MaHa)
            {
                return BadRequest();
            }

            _context.Entry(hinhanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HinhanhExists(id))
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

        // POST: api/Hinhanhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hinhanh>> PostHinhanh(Hinhanh hinhanh)
        {
          if (_context.Hinhanhs == null)
          {
              return Problem("Entity set 'LV_FashionStoreContext.Hinhanhs'  is null.");
          }
            _context.Hinhanhs.Add(hinhanh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HinhanhExists(hinhanh.MaHa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHinhanh", new { id = hinhanh.MaHa }, hinhanh);
        }

        // DELETE: api/Hinhanhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHinhanh(string id)
        {
            if (_context.Hinhanhs == null)
            {
                return NotFound();
            }
            var hinhanh = await _context.Hinhanhs.FindAsync(id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            _context.Hinhanhs.Remove(hinhanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HinhanhExists(string id)
        {
            return (_context.Hinhanhs?.Any(e => e.MaHa == id)).GetValueOrDefault();
        }
    }
}
