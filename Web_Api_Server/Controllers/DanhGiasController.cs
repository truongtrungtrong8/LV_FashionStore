using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiasController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public DanhGiasController(LV_FashionStoreContext context)
        {
            _context = context;
        }
        [HttpGet("getListByProduct")]
        public async Task<ActionResult<IEnumerable<DanhGiaDto>>> GetListDanhGia(string id)
        {
            var review = (from r in _context.DanhgiaSanphams
                          where r.MaSp == id
                          select new DanhGiaDto()
                          {
                              Id = r.Id,
                              TenKh = r.TenKh,
                              DanhGia = r.DanhGia,
                              NgayDanhGia = r.NgayDanhGia,
                              BinhChon = r.BinhChon,
                              MaSp = r.MaSp,
                          });
            return await review.ToListAsync();
        }

        //
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, [FromBody] DanhGiaDto review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }
            var temp = await _context.DanhgiaSanphams.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.Id = review.Id;
            temp.TenKh = review.TenKh;
            temp.DanhGia = review.DanhGia;
            temp.NgayDanhGia = review.NgayDanhGia;
            temp.BinhChon = review.BinhChon;
            temp.MaSp = review.MaSp;
            _context.DanhgiaSanphams.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //
        [HttpPost]
        public async Task<ActionResult<DanhgiaSanpham>> PostLoaiSp([FromBody] DanhGiaDto review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new DanhgiaSanpham()
            {
                TenKh = review.TenKh,
                DanhGia = review.DanhGia,
                NgayDanhGia = review.NgayDanhGia,
                BinhChon = review.BinhChon,
                MaSp = review.MaSp
            };
            await _context.DanhgiaSanphams.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLoaiSp", new { id = review.Id }, review);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var review = await _context.DanhgiaSanphams.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.DanhgiaSanphams.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
