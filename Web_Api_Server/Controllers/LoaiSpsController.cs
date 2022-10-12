using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using Newtonsoft.Json;

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
        [HttpGet("count")]
        public async Task<ActionResult<IEnumerable<LoaiSp>>> GetCountLoai()
        {
            return await _context.LoaiSps.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiDto>>> GetLoaiSps()
        {
            var loaisanpham = (from l in _context.LoaiSps
                               select new LoaiDto()
                               {
                                   MaLoai = l.MaLoai,
                                   Tenloai = l.Tenloai
                               });
            return await loaisanpham.ToListAsync();
        }

        // GET: api/LoaiSps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiDto>> GetLoaiSp(string id)
        {
            var loaisanpham = (from l in _context.LoaiSps
                               where l.MaLoai == id
                               select new LoaiDto()
                               {
                                   MaLoai = l.MaLoai,
                                   Tenloai = l.Tenloai
                               }).SingleOrDefault();
            return loaisanpham;
        }

        //Page
        [HttpGet("pageLoaiSp")]
        public async Task<ActionResult<IEnumerable<LoaiDto>>> GetLoaiSpPage([FromQuery] PagingParameters paging)
        {
            var loaisanpham = (from l in _context.LoaiSps
                               select new LoaiDto()
                               {
                                   MaLoai = l.MaLoai,
                                   Tenloai = l.Tenloai
                               }).AsQueryable();
            var result = PagedList<LoaiDto>.ToPagedList(loaisanpham, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }

        // PUT: api/LoaiSps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSp(string id,[FromBody] LoaiSp loaiSp)
        {
            if (id != loaiSp.MaLoai)
            {
                return BadRequest();
            }
            var temp = await _context.LoaiSps.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.MaLoai = loaiSp.MaLoai;
            temp.Tenloai = loaiSp.Tenloai;
            _context.LoaiSps.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/LoaiSps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiSp>> PostLoaiSp([FromBody] LoaiDto loaiSp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new LoaiSp()
            {
                MaLoai = loaiSp.MaLoai,
                Tenloai = loaiSp.Tenloai
            };
            await _context.LoaiSps.AddAsync(temp);
            await _context.SaveChangesAsync();
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
