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
    public class LoaiSpsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public LoaiSpsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSp>>> GetLoaiSps()
        {
            return await _context.LoaiSps.ToListAsync();
        }

        // GET: api/LoaiSps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSp>> GetLoaiSp(string id)
        {
            var loaiSp = await _context.LoaiSps.FindAsync(id);

            if (loaiSp == null)
            {
                return NotFound();
            }

            return loaiSp;
        }

        // PUT: api/LoaiSps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSp(string id, LoaiSp loaiSp)
        {
            if (id != loaiSp.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loaiSp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSpExists(id))
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

        // POST: api/LoaiSps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiSp>> PostLoaiSp(LoaiSp loaiSp)
        {
            _context.LoaiSps.Add(loaiSp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaiSpExists(loaiSp.MaLoai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaiSp", new { id = loaiSp.MaLoai }, loaiSp);
        }

        // DELETE: api/LoaiSps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiSp(string id)
        {
            var loaiSp = await _context.LoaiSps.FindAsync(id);
            if (loaiSp == null)
            {
                return NotFound();
            }

            _context.LoaiSps.Remove(loaiSp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiSpExists(string id)
        {
            return _context.LoaiSps.Any(e => e.MaLoai == id);
        }
    }
}
