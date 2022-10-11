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
    public class CuahangsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public CuahangsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Cuahangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuahang>>> GetCuahangs()
        {
            return await _context.Cuahangs.ToListAsync();
        }

        // GET: api/Cuahangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuahang>> GetCuahang(string id)
        {
            var cuahang = await _context.Cuahangs.FindAsync(id);

            if (cuahang == null)
            {
                return NotFound();
            }

            return cuahang;
        }

        // PUT: api/Cuahangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuahang(string id, Cuahang cuahang)
        {
            if (id != cuahang.MaCh)
            {
                return BadRequest();
            }

            _context.Entry(cuahang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuahangExists(id))
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

        // POST: api/Cuahangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuahang>> PostCuahang(Cuahang cuahang)
        {
            _context.Cuahangs.Add(cuahang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CuahangExists(cuahang.MaCh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCuahang", new { id = cuahang.MaCh }, cuahang);
        }

        // DELETE: api/Cuahangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuahang(string id)
        {
            var cuahang = await _context.Cuahangs.FindAsync(id);
            if (cuahang == null)
            {
                return NotFound();
            }

            _context.Cuahangs.Remove(cuahang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuahangExists(string id)
        {
            return _context.Cuahangs.Any(e => e.MaCh == id);
        }
    }
}
