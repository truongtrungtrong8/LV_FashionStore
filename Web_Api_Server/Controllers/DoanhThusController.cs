using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhThusController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public DoanhThusController(LV_FashionStoreContext context)
        {
            _context = context;
        }
        [HttpGet("getMonthByID")]
        public async Task<ActionResult<DoanhThuThang>> GetDoanhThuThangById(int id)
        {
            var doanhThu = await _context.DoanhThuThangs.Where(d=>d.Thang == id).SingleOrDefaultAsync();

            if (doanhThu == null)
            {
                return NotFound();
            }

            return doanhThu;
        }
        [HttpGet("getYearByID")]
        public async Task<ActionResult<DoanhThuNam>> GetDoanhThuYearById(int id)
        {
            var doanhThu = await _context.DoanhThuNams.Where(d => d.Nam == id).SingleOrDefaultAsync();

            if (doanhThu == null)
            {
                return NotFound();
            }

            return doanhThu;
        }
        [HttpGet("getQuyByID")]
        public async Task<ActionResult<DoanhThuQuy>> GetDoanhThuQuyById(int id)
        {
            var doanhThu = await _context.DoanhThuQuies.Where(d => d.Quy == id).SingleOrDefaultAsync();

            if (doanhThu == null)
            {
                return NotFound();
            }

            return doanhThu;
        }
        [HttpGet("getByMonth")]
        public async Task<ActionResult<IEnumerable<DoanhThuThang>>> GetDoanhthuThang()
        {
            var doanhthu = _context.DoanhThuThangs.ToListAsync();
            return await doanhthu;
        }
        [HttpGet("getByYear")]
        public async Task<ActionResult<IEnumerable<DoanhThuNam>>> GetDoanhthuNam()
        {
            var doanhthu = _context.DoanhThuNams.ToArrayAsync();
            return await doanhthu;
        }
        [HttpGet("getByQuy")]
        public async Task<ActionResult<IEnumerable<DoanhThuQuy>>> GetDoanhthuQuy()
        {
            var doanhthu = _context.DoanhThuQuies.ToListAsync();
            return await doanhthu;
        }
        [HttpPost]
        public async Task<ActionResult<DoanhThuThang>> PostDoanhThuThang([FromBody] DoanhThuThang request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doanhthu = new DoanhThuThang()
            {
                TongTien = request.TongTien,
                Thang = request.Thang,
            };
            await _context.DoanhThuThangs.AddAsync(doanhthu);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDoanhthu", new { id = doanhthu.Thang }, doanhthu);
        }
        [HttpPut("putByMonth")]
        public async Task<IActionResult> PutByMonth(int id, [FromBody] DoanhThuThang doanhthu)
        {
            if (id != doanhthu.Thang)
            {
                return BadRequest();
            }
            var temp = await _context.DoanhThuThangs.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.TongTien = doanhthu.TongTien;
            temp.Thang = doanhthu.Thang;
            _context.DoanhThuThangs.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("postByYear")]
        public async Task<ActionResult<DoanhThuNam>> PostDoanhThuNam([FromBody] DoanhThuNam request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doanhthu = new DoanhThuNam()
            {
                TongTien = request.TongTien,
                Nam = request.Nam,
            };
            await _context.DoanhThuNams.AddAsync(doanhthu);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDoanhthu", new { id = doanhthu.Nam }, doanhthu);
        }
        [HttpPut("putByYear")]
        public async Task<IActionResult> PutByYear(int id, [FromBody] DoanhThuNam doanhthu)
        {
            if (id != doanhthu.Nam)
            {
                return BadRequest();
            }
            var temp = await _context.DoanhThuNams.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.TongTien = doanhthu.TongTien;
            temp.Nam = doanhthu.Nam;
            _context.DoanhThuNams.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("postByQuy")]
        public async Task<ActionResult<DoanhThuQuy>> PostDoanhThuQuy([FromBody] DoanhThuQuy request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doanhthu = new DoanhThuQuy()
            {
                TongTien = request.TongTien,
                Quy = request.Quy,
            };
            await _context.DoanhThuQuies.AddAsync(doanhthu);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDoanhthu", new { id = doanhthu.Quy }, doanhthu);
        }
        [HttpPut("putByQuy")]
        public async Task<IActionResult> PutByQuy(int id, [FromBody] DoanhThuQuy doanhthu)
        {
            if (id != doanhthu.Quy)
            {
                return BadRequest();
            }
            var temp = await _context.DoanhThuQuies.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.TongTien = doanhthu.TongTien;
            temp.Quy = doanhthu.Quy;
            _context.DoanhThuQuies.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
