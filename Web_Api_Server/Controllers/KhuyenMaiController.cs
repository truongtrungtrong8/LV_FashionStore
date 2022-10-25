using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using Newtonsoft.Json;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public KhuyenMaiController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenMaiDtoList>>> GetKhuyenMais()
        {
            var khuyenmai = (from k in _context.Khuyenmais
                             join s in _context.Sanphams on k.MaSp equals s.MaSp
                               select new KhuyenMaiDtoList()
                               {
                                  Id = k.Id,
                                  Thoigian = k.Thoigian,
                                  MaSp = k.MaSp,
                                  Tile = k.Tile,
                                  TenSp = s.TenSp
                               });
            return await khuyenmai.ToListAsync();
        }
        //Page
        [HttpGet("pageKhuyenMai")]
        public async Task<ActionResult<IEnumerable<KhuyenMaiDtoList>>> GetPageKhuyenMai([FromQuery] PagingParameters paging)
        {
            var khuyenMais= (from k in _context.Khuyenmais
                               join s in _context.Sanphams on k.MaSp equals s.MaSp
                               select new KhuyenMaiDtoList()
                               {
                                   Id = k.Id,
                                   Thoigian = k.Thoigian,
                                   MaSp = k.MaSp,
                                   Tile = k.Tile,
                                   TenSp = s.TenSp
                               }).AsQueryable();
            var result = PagedList<KhuyenMaiDtoList>.ToPagedList(khuyenMais, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KhuyenMaiDtoList>> GetKhuyenMai(int id)
        {
            var khuyenmai = (from k in _context.Khuyenmais
                             join s in _context.Sanphams on k.MaSp equals s.MaSp
                             where k.Id == id
                             select new KhuyenMaiDtoList()
                             {
                                 Id = k.Id,
                                 Thoigian = k.Thoigian,
                                 MaSp = k.MaSp,
                                 Tile = k.Tile,
                                 TenSp = s.TenSp
                             }).SingleOrDefault();
            return khuyenmai;
        }
        [HttpGet("getByProduct")]
        public async Task<ActionResult<KhuyenMaiDto>> GetByProduct(string id)
        {
            var khuyenmai = (from k in _context.Khuyenmais
                             where k.MaSp == id
                             select new KhuyenMaiDto()
                             {
                                 Id = k.Id,
                                 Thoigian = k.Thoigian,
                                 MaSp = k.MaSp,
                                 Tile = k.Tile
                             }).SingleOrDefault();
            return khuyenmai;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuyenMai(int id, [FromBody] KhuyenMaiDto khuyenMai)
        {
            if (id != khuyenMai.Id)
            {
                return BadRequest();
            }
            var temp = await _context.Khuyenmais.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.Id = khuyenMai.Id;
            temp.Thoigian = khuyenMai.Thoigian;
            temp.MaSp = khuyenMai.MaSp;
            temp.Tile = khuyenMai.Tile;
            _context.Khuyenmais.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<Khuyenmai>> PostLoaiSp([FromBody] KhuyenMaiDto khuyenMai)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Khuyenmai()
            {
                //Id = khuyenMai.Id,
                Thoigian = khuyenMai.Thoigian,
                MaSp = khuyenMai.MaSp,
                Tile = khuyenMai.Tile,
            };
            await _context.Khuyenmais.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetKhuyenmai", new { id = khuyenMai.Id }, khuyenMai);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhuyenMai(int id)
        {
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            if (khuyenmai == null)
            {
                return NotFound();
            }

            _context.Khuyenmais.Remove(khuyenmai);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
