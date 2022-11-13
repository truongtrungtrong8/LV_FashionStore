using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanlyNVController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public QuanlyNVController(LV_FashionStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanLyNv>>> GetCountLoai()
        {
            return await _context.QuanLyNvs.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<QuanLyNv>> PostQuanLyNV([FromBody] QuanLyNv nv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new QuanLyNv()
            {
                TenNv = nv.TenNv,
                Chucvu = nv.Chucvu,
            };
            await _context.QuanLyNvs.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetQuanLyNV", new { id = nv.Id}, nv);
        }
    }
}
