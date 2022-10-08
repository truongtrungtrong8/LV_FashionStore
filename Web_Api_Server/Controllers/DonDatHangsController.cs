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
                           });
            return await dondat.ToListAsync();
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
        public async Task<IActionResult> PutDondathang(string id, Dondathang dondathang)
        {
            if (id != dondathang.MaDdh)
            {
                return BadRequest();
            }

            _context.Entry(dondathang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DondathangExists(id))
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
