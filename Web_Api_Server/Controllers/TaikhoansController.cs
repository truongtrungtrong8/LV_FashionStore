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
using NuGet.Protocol;
using Web_Api_Server.Repositoreies;

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

        [HttpGet("gettaikhoan")]
        public async Task<ActionResult<IEnumerable<Taikhoan>>> GetLoaiSelectTaikhoan()
        {
            return await _context.Taikhoans.ToListAsync();
        }

        // GET: api/Taikhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaikhoanDto>>> GetTaikhoans()
        {
            var taikhoan = (from t in _context.Taikhoans
                            select new TaikhoanDto()
                            {
                                TenTk = t.TenTk,
                                Matkhau = t.Matkhau,
                                Quyensd = t.Quyensd,
                            });
            return await taikhoan.ToListAsync();
        }
        [HttpGet("getTkbyID")]
        public async Task<ActionResult<IEnumerable<TaikhoanDto>>> GetTaikhoanByID(string id)
        {
            var taikhoan = (from t in _context.Taikhoans
                            where t.TrangThai == id
                            select new TaikhoanDto()
                            {
                                TenTk = t.TenTk,
                                Matkhau = t.Matkhau,
                                Quyensd = t.Quyensd,
                                TrangThai = t.TrangThai,
                            }).ToListAsync();
            return await taikhoan;
        }


        [HttpGet("pageTaikhoan")]
        public async Task<ActionResult<IEnumerable<TaikhoanDto>>> GetTaikhoanPage([FromQuery] PagingParameters paging)
        {
            var taikhoan = (from t in _context.Taikhoans
                            select new TaikhoanDto()
                            {
                                TenTk = t.TenTk,
                                Matkhau = t.Matkhau,
                                Quyensd = t.Quyensd,
                            }).Search(paging.SearchTerm).AsQueryable();
            var result = PagedList<TaikhoanDto>.ToPagedList(taikhoan, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }
        // GET: api/Taikhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaikhoanDto>> GetTaikhoan(string id)
        {
            var taikhoan = (from t in _context.Taikhoans
                            where t.TenTk == id
                            select new TaikhoanDto()
                            {
                                TenTk = t.TenTk,
                                Matkhau = t.Matkhau,
                                Quyensd = t.Quyensd,
                            }).SingleOrDefault();
            return taikhoan;
        }


        // PUT: api/Taikhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaikhoan(string id,[FromBody] TaikhoanDto taikhoan)
        {
           if(id!= taikhoan.TenTk)
            {
                return BadRequest();
            }
            var temp = await _context.Taikhoans.FindAsync(id);
            if(temp == null)
                return NotFound(id);
            temp.TenTk = taikhoan.TenTk;
            temp.Matkhau = taikhoan.Matkhau;
            temp.Quyensd = taikhoan.Quyensd;

            _context.Taikhoans.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Taikhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("page")]
        public async Task<ActionResult<Taikhoan>> PostTaikhoanPage([FromBody] TaikhoanDto taikhoan)
        {
          if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Taikhoan()
            {
                TenTk = taikhoan.TenTk,
                Matkhau = taikhoan.Matkhau,
                Quyensd = taikhoan.Quyensd,
                TrangThai = taikhoan.TrangThai,
            };
            await _context.Taikhoans.AddAsync(temp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaikhoan", new { id = taikhoan.TenTk }, taikhoan);
        }

        [HttpPost]
        public async Task<ActionResult<Taikhoan>> PostTaikhoan(Taikhoan taikhoan)
        {
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
