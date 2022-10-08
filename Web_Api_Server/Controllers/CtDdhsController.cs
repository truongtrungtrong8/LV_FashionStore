using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtDdhsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public CtDdhsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/CtDdhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtDdh>>> GetCtDdhs()
        {
            return await _context.CtDdhs.ToListAsync();
        }

        // GET: api/CtDdhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtDdh>> GetCtDdh(string id)
        {
            var ctDdh = await _context.CtDdhs.FindAsync(id);

            if (ctDdh == null)
            {
                return NotFound();
            }

            return ctDdh;
        }

        // PUT: api/CtDdhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtDdh(string id, CtDdh ctDdh)
        {
            if (id != ctDdh.MaDdh)
            {
                return BadRequest();
            }

            _context.Entry(ctDdh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtDdhExists(id))
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

        // POST: api/CtDdhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtDdh>> PostCtDdh([FromBody] CtDonDatDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var CTdondat = new CtDdh()
            {
                MaSp = request.MaSp,
                MaDdh = request.MaDdh,
                Sl = request.Sl,
                Dg = request.Dg,
            };

            await _context.CtDdhs.AddAsync(CTdondat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtDdh", new { id = CTdondat.MaDdh }, CTdondat);
        }

        // DELETE: api/CtDdhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtDdh(string id)
        {
            var ctDdh = await _context.CtDdhs.FindAsync(id);
            if (ctDdh == null)
            {
                return NotFound();
            }

            _context.CtDdhs.Remove(ctDdh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtDdhExists(string id)
        {
            return _context.CtDdhs.Any(e => e.MaDdh == id);
        }
    }
}
