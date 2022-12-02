using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2016.Excel;
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
    public class DonDatHangsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public DonDatHangsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/DonDatHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dondathang>>> GetDondathangs()
        {
            return await _context.Dondathangs.ToListAsync();
        }

        [HttpGet("countDonDat")]
        public async Task<ActionResult<IEnumerable<DonDatDto>>> GetCountDondat()
        {
            var dondat = (from s in _context.Dondathangs
                           select new DonDatDto()
                           {
                              MaDdh = s.MaDdh,
                              TongDdh = s.TongDdh,
                              Diachi = s.Diachi,
                              MaKh = s.MaKh,
                              Thoigian = s.Thoigian,
                               TinhTrang = s.TinhTrang
                           });
            return await dondat.ToListAsync();
        }

        [HttpGet("getListByKh")]
        public async Task<ActionResult<IEnumerable<DonDatDto>>> GetListByKh(string id)
        {
            var dondat = (from d in _context.Dondathangs
                          where d.MaKh == id
                          select new DonDatDto()
                          {
                              MaDdh = d.MaDdh,
                              MaKh = d.MaKh,
                              TongDdh = d.TongDdh,
                              Diachi = d.Diachi,
                              Thoigian = d.Thoigian,
                              TinhTrang = d.TinhTrang
                          });
            return await dondat.ToListAsync();
        }
        [HttpGet("getKhByDonDat")]
        public async Task<ActionResult<IEnumerable<DonDatNewDto>>> GetKhByDD([FromQuery] PagingParameters paging)
        {
            var dondat = (from d in _context.Dondathangs
                          join k in _context.Khachhangs on d.MaKh equals k.MaKh
                          select new DonDatNewDto()
                          {
                              MaDdh = d.MaDdh,
                              MaKh = d.MaKh,
                              TongDdh = d.TongDdh,
                              Diachi = d.Diachi,
                              Thoigian = d.Thoigian,
                              TinhTrang = d.TinhTrang,
                              TenKh = k.TenKh
                          }).OrderBy(d=>d.Thoigian.Date).AsQueryable();
            var result = PagedList<DonDatNewDto>.ToPagedList(dondat, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }


        // GET: api/DonDatHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dondathang>> GetDondathang(string id)
        {
            var dondathang = await _context.Dondathangs.FindAsync(id);

            if (dondathang == null)
            {
                return NotFound();
            }

            return dondathang;
        }

        // PUT: api/DonDatHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDondathang(string id, [FromBody] DonDatDto dondathang)
        {
            if (id != dondathang.MaDdh)
            {
                return BadRequest();
            }
            var temp = await _context.Dondathangs.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.MaDdh = dondathang.MaDdh;
            temp.MaKh = dondathang.MaKh;
            temp.TongDdh = dondathang.TongDdh;
            temp.Diachi = dondathang.Diachi;
            temp.Thoigian = dondathang.Thoigian;
            temp.TinhTrang = dondathang.TinhTrang;
            _context.Dondathangs.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/DonDatHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dondathang>> PostDondathang([FromBody] DonDatDto request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dondat = new Dondathang()
            {
                MaDdh = request.MaDdh,
                TongDdh = request.TongDdh,
                Diachi = request.Diachi,
                MaKh = request.MaKh,
                Thoigian = request.Thoigian,
                TinhTrang = request.TinhTrang
            };

            await _context.Dondathangs.AddAsync(dondat);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDondathang", new { id = dondat.MaDdh }, dondat);
        }

        // DELETE: api/DonDatHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDondathang(string id)
        {
            var dondathang = await _context.Dondathangs.FindAsync(id);
            if (dondathang == null)
            {
                return NotFound();
            }

            _context.Dondathangs.Remove(dondathang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DondathangExists(string id)
        {
            return _context.Dondathangs.Any(e => e.MaDdh == id);
        }
    }
}
