using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public SanphamsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Sanphams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sanpham_Model>>> GetProducts()
        {
            var sanpham = (from s in _context.Sanphams
                           join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                           select new Sanpham_Model()
                           {
                               MaSp = s.MaSp,
                               MaLoai = s.MaLoai,
                               HaBia = h.HaBia,
                               Ha1 = h.Ha1,
                               Ha2 = h.Ha2,
                               GiaSp = s.GiaSp,
                               TenSp = s.TenSp
                           });

            return await sanpham.ToListAsync();

            
        }

        // GET: api/Sanphams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sanpham_Model>> GetSanpham(string id)
        {
            var sanpham = (from s in _context.Sanphams
                           join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                           join hsx in _context.Hxs on s.MaHsx equals hsx.MaHsx
                           join l in _context.LoaiSps on s.MaLoai equals l.MaLoai
                           where s.MaSp == id
                           select new Sanpham_Model()
                           {
                               MaSp = s.MaSp,
                               MaLoai = s.MaLoai,
                               HaBia = h.HaBia,
                               Ha1 = h.Ha1,
                               Ha2 = h.Ha2,
                               GiaSp = s.GiaSp,
                               TenSp = s.TenSp,
                               TenHsx = hsx.TenHsx,
                               Tenloai = l.Tenloai,
                               Mota = s.Mota
                               
                           }).SingleOrDefault();

            return sanpham;
        }

        // PUT: api/Sanphams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanpham(string id, Sanpham sanpham)
        {
            if (id != sanpham.MaSp)
            {
                return BadRequest();
            }

            _context.Entry(sanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanphamExists(id))
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

        // POST: api/Sanphams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sanpham>> PostSanpham(Sanpham sanpham)
        {
          if (_context.Sanphams == null)
          {
              return Problem("Entity set 'LV_FashionStoreContext.Sanphams'  is null.");
          }
            _context.Sanphams.Add(sanpham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SanphamExists(sanpham.MaSp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSanpham", new { id = sanpham.MaSp }, sanpham);
        }

        // DELETE: api/Sanphams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanpham(string id)
        {
            if (_context.Sanphams == null)
            {
                return NotFound();
            }
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanphamExists(string id)
        {
            return (_context.Sanphams?.Any(e => e.MaSp == id)).GetValueOrDefault();
        }
        
    }
}
