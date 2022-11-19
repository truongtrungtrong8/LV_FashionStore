using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using Newtonsoft.Json;
using Web_Api_Server.Repositoreies;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public KhachhangsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Khachhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khachhang>>> GetKhachhangs()
        {
            return await _context.Khachhangs.ToListAsync();
        }
        [HttpGet("pageKhachhang")]
        public async Task<ActionResult<IEnumerable<Khachhang>>> GetKhachhangPage([FromQuery] PagingParameters paging)
        {
            var khachhang = _context.Khachhangs.Search(paging.SearchTerm).AsQueryable();
            var result = PagedList<Khachhang>.ToPagedList(khachhang, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }
        // GET: api/Khachhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khachhang>> GetKhachhang(string id)
        {
            if (_context.Khachhangs == null)
            {
                return NotFound();
            }
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return khachhang;
        }
        [HttpGet("getKhID")]
        public async Task<ActionResult<KhachHangDto>> GetKhachhangID(string id)
        {
            var khachhang = (from k in _context.Khachhangs
                             join t in _context.Taikhoans on k.TenTk equals t.TenTk
                             where t.TenTk == id
                             select new KhachHangDto()
                             {
                                 TenTk = t.TenTk,
                                 TenKh = k.TenKh,
                                 MaKh = k.MaKh,
                                 Email_Kh = k.EmailKh
                             });
            return await khachhang.SingleOrDefaultAsync();
        }

        // PUT: api/Khachhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachhang( string id, [FromBody] KhachHangDto khachhang)
        {
            if (id != khachhang.MaKh)
            {
                return BadRequest();
            }

            var temp = await _context.Khachhangs.FindAsync(id);
            if (temp == null)
                return NotFound($"{id} is not found");

            temp.MaKh = khachhang.MaKh;
            temp.TenKh = khachhang.TenKh;
            temp.TenTk = khachhang.TenTk;
            temp.SdtKh = khachhang.SdtKh;
            temp.DiachiKh = khachhang.DiachiKh;
            temp.EmailKh = khachhang.Email_Kh;

            _context.Khachhangs.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Khachhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khachhang>> PostKhachhang(Khachhang khachhang)
        {
            _context.Khachhangs.Add(khachhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhachhangExists(khachhang.MaKh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhachhang", new { id = khachhang.MaKh }, khachhang);
        }

        // DELETE: api/Khachhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachhang(string id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }

            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhachhangExists(string id)
        {
            return _context.Khachhangs.Any(e => e.MaKh == id);
        }
    }
}
