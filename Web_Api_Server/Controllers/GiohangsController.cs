using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiohangsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public GiohangsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Giohangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giohang>>> GetGiohangs()
        {
            return await _context.Giohangs.ToListAsync();
        }

        // GET: api/Giohangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giohang>> GetGiohang(string id)
        {
            var giohang = await _context.Giohangs.FindAsync(id);

            if (giohang == null)
            {
                return NotFound();
            }

            return giohang;
        }

        // PUT: api/Giohangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiohang(string id, Giohang giohang)
        {
            if (id != giohang.MaGh)
            {
                return BadRequest();
            }

            _context.Entry(giohang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiohangExists(id))
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

        // POST: api/Giohangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giohang>> PostGiohang([FromBody] GioHangDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var giohang = new Giohang()
            {
                MaGh = request.MaGh,
                Tongtien = request.Tongtien,
                Ngaydat = request.Ngaydat,
                
            };

            await _context.Giohangs.AddAsync(giohang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiohang", new { id = giohang.MaGh }, giohang);
        }

        // DELETE: api/Giohangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiohang(string id)
        {
            var giohang = await _context.Giohangs.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }

            _context.Giohangs.Remove(giohang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiohangExists(string id)
        {
            return _context.Giohangs.Any(e => e.MaGh == id);
        }
    }
}
