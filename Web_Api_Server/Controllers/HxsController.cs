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
    public class HxsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public HxsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Hxs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hx>>> GetHxs()
        {
            return await _context.Hxs.ToListAsync();
        }

        // GET: api/Hxs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hx>> GetHx(string id)
        {
            var hx = await _context.Hxs.FindAsync(id);

            if (hx == null)
            {
                return NotFound();
            }

            return hx;
        }

        // PUT: api/Hxs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHx(string id, Hx hx)
        {
            if (id != hx.MaHsx)
            {
                return BadRequest();
            }

            _context.Entry(hx).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HxExists(id))
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

        // POST: api/Hxs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hx>> PostHx(Hx hx)
        {
            _context.Hxs.Add(hx);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HxExists(hx.MaHsx))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHx", new { id = hx.MaHsx }, hx);
        }

        // DELETE: api/Hxs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHx(string id)
        {
            var hx = await _context.Hxs.FindAsync(id);
            if (hx == null)
            {
                return NotFound();
            }

            _context.Hxs.Remove(hx);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HxExists(string id)
        {
            return _context.Hxs.Any(e => e.MaHsx == id);
        }
    }
}
