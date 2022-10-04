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
    public class TaikhoansController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public TaikhoansController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Taikhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taikhoan>>> GetTaikhoans()
        {
          if (_context.Taikhoans == null)
          {
              return NotFound();
          }
            return await _context.Taikhoans.ToListAsync();
        }

        // GET: api/Taikhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taikhoan>> GetTaikhoan(string id)
        {
          if (_context.Taikhoans == null)
          {
              return NotFound();
          }
            var taikhoan = await _context.Taikhoans.FindAsync(id);

            if (taikhoan == null)
            {
                return NotFound();
            }

            return taikhoan;
        }


        // PUT: api/Taikhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaikhoan(string id, Taikhoan taikhoan)
        {
            if (id != taikhoan.TenTk)
            {
                return BadRequest();
            }

            _context.Entry(taikhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaikhoanExists(id))
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

        // POST: api/Taikhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taikhoan>> PostTaikhoan(Taikhoan taikhoan)
        {
          if (_context.Taikhoans == null)
          {
              return Problem("Entity set 'LV_FashionStoreContext.Taikhoans'  is null.");
          }
            _context.Taikhoans.Add(taikhoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaikhoanExists(taikhoan.TenTk))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaikhoan", new { id = taikhoan.TenTk }, taikhoan);
        }

        // DELETE: api/Taikhoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaikhoan(string id)
        {
            if (_context.Taikhoans == null)
            {
                return NotFound();
            }
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            _context.Taikhoans.Remove(taikhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaikhoanExists(string id)
        {
            return (_context.Taikhoans?.Any(e => e.TenTk == id)).GetValueOrDefault();
        }


        [HttpGet("GetLogin")]
        public async Task<ActionResult<Taikhoan>> GetLogin(string id, string pwd)
        {
            if (_context.Taikhoans == null)
            {
                return NotFound();
            }
            var account = await _context.Taikhoans.Where(acc => acc.TenTk == id && acc.Matkhau == pwd).SingleOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }
    }
}
