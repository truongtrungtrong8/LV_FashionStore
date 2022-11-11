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
    public class NhanviensController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public NhanviensController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        //GetCount
        [HttpGet("countnhanvien")]
        public async Task<ActionResult<IEnumerable<Nhanvien>>> GetCountNhanVien()
        {
            return await _context.Nhanviens.ToListAsync();
        }


        // GET: api/Nhanviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanvienDto>>> GetNhanviens()
        {
            var nhanvien = (from n in _context.Nhanviens
                            select new NhanvienDto()
                            {
                                MaNv = n.MaNv,
                                TenTk = n.TenTk,
                                MaCh = n.MaCh,
                                HtenNv = n.HtenNv,
                                GtNv = n.GtNv,
                                NsNv = n.NsNv,
                                DcNv = n.DcNv,
                                ChucvuNv = n.ChucvuNv,
                                LuongNv = n.LuongNv,
                            });
            return await nhanvien.ToListAsync();
        }
        [HttpGet("pageNhanvien")]
        public async Task<ActionResult<IEnumerable<NhanvienDto>>> GetNhanvienPage([FromQuery] PagingParameters paging)
        {
            var nhanvien = (from n in _context.Nhanviens
                            select new NhanvienDto()
                            {
                                MaNv = n.MaNv,
                                TenTk = n.TenTk,
                                MaCh = n.MaCh,
                                HtenNv = n.HtenNv,
                                GtNv = n.GtNv,
                                NsNv = n.NsNv,
                                DcNv = n.DcNv,
                                ChucvuNv = n.ChucvuNv,
                                LuongNv = n.LuongNv,
                            }).AsQueryable();
            var result = PagedList<NhanvienDto>.ToPagedList(nhanvien, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }
        //getNhanvienByTK
        [HttpGet("getNhanvienByTk")]
        public async Task<ActionResult<NhanvienDto>> GetNhanvienByTK(string id)
        {
            var nhanvien = (from n in _context.Nhanviens
                            where n.TenTk == id
                            select new NhanvienDto()
                            {
                                MaNv = n.MaNv,
                                TenTk = n.TenTk,
                                MaCh = n.MaCh,
                                HtenNv = n.HtenNv,
                                GtNv = n.GtNv,
                                NsNv = n.NsNv,
                                DcNv = n.DcNv,
                                ChucvuNv = n.ChucvuNv,
                                LuongNv = n.LuongNv,
                            }).SingleOrDefault();
            return nhanvien;
        }
        // GET: api/Nhanviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanvienDto>> GetNhanvien(string id)
        {
            if (_context.Nhanviens == null)
                return NotFound();
            var nhanvien = (from n in _context.Nhanviens
                            where n.MaNv == id
                            select new NhanvienDto()
                            {
                                MaNv = n.MaNv,
                                TenTk = n.TenTk,
                                MaCh = n.MaCh,
                                HtenNv = n.HtenNv,
                                GtNv = n.GtNv,
                                NsNv = n.NsNv,
                                DcNv = n.DcNv,
                                ChucvuNv = n.ChucvuNv,
                                LuongNv = n.LuongNv,
                            }).SingleOrDefault();
            if (nhanvien == null)
                return NotFound();
            return nhanvien;
        }

        // PUT: api/Nhanviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanvien(string id,[FromBody] NhanvienDto nhanvien)
        {
            if (id != nhanvien.MaNv)
            {
                return BadRequest();
            }
            var temp = await _context.Nhanviens.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.MaNv = nhanvien.MaNv;
            temp.HtenNv = nhanvien.HtenNv;
            temp.TenTk = nhanvien.TenTk;
            temp.MaCh = nhanvien.MaCh;
            temp.GtNv = nhanvien.GtNv;
            temp.NsNv = nhanvien.NsNv;
            temp.DcNv = nhanvien.DcNv;
            temp.ChucvuNv = nhanvien.ChucvuNv;
            temp.LuongNv = nhanvien.LuongNv;
            _context.Nhanviens.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Nhanviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nhanvien>> PostNhanvien([FromBody] NhanvienDto nhanvien)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Nhanvien()
            {
                MaNv = nhanvien.MaNv,
                HtenNv = nhanvien.HtenNv,
                TenTk = nhanvien.TenTk,
                MaCh = nhanvien.MaCh,
                GtNv = nhanvien.GtNv,
                NsNv = nhanvien.NsNv,
                DcNv = nhanvien.DcNv,
                ChucvuNv = nhanvien.ChucvuNv,
                LuongNv = nhanvien.LuongNv,
            };
            await _context.Nhanviens.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetNhanvien", new { id = nhanvien.MaNv }, nhanvien);
        }

        // DELETE: api/Nhanviens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanvien(string id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanvienExists(string id)
        {
            return _context.Nhanviens.Any(e => e.MaNv == id);
        }
    }
}
