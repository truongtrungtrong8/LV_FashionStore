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
    public class CtHdsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public CtHdsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/CtHds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtHd>>> GetCtHds()
        {
            return await _context.CtHds.ToListAsync();
        }

        // GET: api/CtHds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtHd>> GetCtHd(string id)
        {
            var ctHd = await _context.CtHds.FindAsync(id);

            if (ctHd == null)
            {
                return NotFound();
            }

            return ctHd;
        }

        // PUT: api/CtHds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtHd(string id, CtHd ctHd)
        {
            if (id != ctHd.MaSp)
            {
                return BadRequest();
            }

            _context.Entry(ctHd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtHdExists(id))
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

        // POST: api/CtHds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtHd>> PostCtHd(CtHd ctHd)
        {
            _context.CtHds.Add(ctHd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CtHdExists(ctHd.MaSp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCtHd", new { id = ctHd.MaSp }, ctHd);
        }

        // DELETE: api/CtHds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtHd(string id)
        {
            var ctHd = await _context.CtHds.FindAsync(id);
            if (ctHd == null)
            {
                return NotFound();
            }

            _context.CtHds.Remove(ctHd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtHdExists(string id)
        {
            return _context.CtHds.Any(e => e.MaSp == id);
        }
    }
}
