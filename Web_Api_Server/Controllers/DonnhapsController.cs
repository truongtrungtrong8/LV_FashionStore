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
    public class DonnhapsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public DonnhapsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Donnhaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donnhap>>> GetDonnhaps()
        {
            return await _context.Donnhaps.ToListAsync();
        }

        // GET: api/Donnhaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donnhap>> GetDonnhap(string id)
        {
            var donnhap = await _context.Donnhaps.FindAsync(id);

            if (donnhap == null)
            {
                return NotFound();
            }

            return donnhap;
        }

        // PUT: api/Donnhaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonnhap(string id, Donnhap donnhap)
        {
            if (id != donnhap.MaDn)
            {
                return BadRequest();
            }

            _context.Entry(donnhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonnhapExists(id))
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

        // POST: api/Donnhaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donnhap>> PostDonnhap(Donnhap donnhap)
        {
            _context.Donnhaps.Add(donnhap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonnhapExists(donnhap.MaDn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonnhap", new { id = donnhap.MaDn }, donnhap);
        }

        // DELETE: api/Donnhaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonnhap(string id)
        {
            var donnhap = await _context.Donnhaps.FindAsync(id);
            if (donnhap == null)
            {
                return NotFound();
            }

            _context.Donnhaps.Remove(donnhap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonnhapExists(string id)
        {
            return _context.Donnhaps.Any(e => e.MaDn == id);
        }
    }
}
