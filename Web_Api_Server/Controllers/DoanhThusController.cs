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
        public async Task<ActionResult<DoanhThuNam>> GetDoanhThuYearById(string id, int id1)
        {
            var doanhThu = await _context.DoanhThuNams.Where(d => d.Thang == id && d.Nam == id1).SingleOrDefaultAsync();

            if (doanhThu == null)
            {
                return NotFound();
            }

            return doanhThu;
        }
        [HttpGet("getQuyByID")]
        public async Task<ActionResult<DoanhThuQuy>> GetDoanhThuQuyById(string id, int id1)
        {
            var doanhThu = await _context.DoanhThuQuies.Where(d => d.Quy == id && d.Nam == id1).SingleOrDefaultAsync();
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
        public async Task<ActionResult<IEnumerable<DoanhThuNam>>> GetDoanhthuNam(int nam)
        {
            var doanhthu = _context.DoanhThuNams.Where(d=>d.Nam == nam).OrderBy(d=>d.Id).ToListAsync();
            return await doanhthu;
        }
        [HttpGet("getByQuy")]
        public async Task<ActionResult<IEnumerable<DoanhThuQuy>>> GetDoanhthuQuy(int nam)
        {
            var doanhthu = _context.DoanhThuQuies.Where(d=>d.Nam == nam).OrderBy(d=>d.Id).ToListAsync();
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
        [HttpPut("putByYear")]
        public async Task<IActionResult> PutByYear(string id, int id1,int id2,[FromBody] DoanhThuNam doanhthu)
        {
            if (id != doanhthu.Thang && id1 != doanhthu.Nam && doanhthu.Id != id2)
            {
                return BadRequest();
            }
            var temp = await _context.DoanhThuNams.FindAsync(id,id1,id2);
            if (temp == null)
                return NotFound(id);
            temp.Id = doanhthu.Id;
            temp.Thang = doanhthu.Thang;
            temp.Nam = doanhthu.Nam;
            temp.DoanhThu = doanhthu.DoanhThu;
            _context.DoanhThuNams.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("putByQuy")]
        public async Task<IActionResult> PutByQuy(int id,string id1, int id2, [FromBody] DoanhThuQuy doanhthu)
        {
            if (id != doanhthu.Id && id1 != doanhthu.Quy && id2 != doanhthu.Nam)
            {
                return BadRequest();
            }
            var temp = await _context.DoanhThuQuies.FindAsync(id,id1,id2);
            if (temp == null)
                return NotFound(id);
            temp.Id = doanhthu.Id;
            temp.Quy = doanhthu.Quy;
            temp.Nam = doanhthu.Nam;
            temp.DoanhThu = doanhthu.DoanhThu;
            _context.DoanhThuQuies.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
