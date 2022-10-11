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
    public class CtDnsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public CtDnsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/CtDns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtDn>>> GetCtDns()
        {
            return await _context.CtDns.ToListAsync();
        }

        // GET: api/CtDns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtDn>> GetCtDn(string id)
        {
            var ctDn = await _context.CtDns.FindAsync(id);

            if (ctDn == null)
            {
                return NotFound();
            }

            return ctDn;
        }

        // PUT: api/CtDns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtDn(string id, CtDn ctDn)
        {
            if (id != ctDn.MaDn)
            {
                return BadRequest();
            }

            _context.Entry(ctDn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtDnExists(id))
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

        // POST: api/CtDns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtDn>> PostCtDn(CtDn ctDn)
        {
            _context.CtDns.Add(ctDn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CtDnExists(ctDn.MaDn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCtDn", new { id = ctDn.MaDn }, ctDn);
        }

        // DELETE: api/CtDns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtDn(string id)
        {
            var ctDn = await _context.CtDns.FindAsync(id);
            if (ctDn == null)
            {
                return NotFound();
            }

            _context.CtDns.Remove(ctDn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtDnExists(string id)
        {
            return _context.CtDns.Any(e => e.MaDn == id);
        }
    }
}
