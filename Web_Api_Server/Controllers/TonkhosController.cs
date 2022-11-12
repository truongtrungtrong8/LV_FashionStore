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
    public class TonkhosController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;
        public TonkhosController(LV_FashionStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TonkhoDto>>> GetTonkhos()
        {
            var tonkho = (from t in _context.Tonkhos
                          select new TonkhoDto()
                          {
                              MaSp = t.MaSp,
                              MaCh = t.MaCh,
                              Sl = t.Sl,
                              Dg = t.Dg
                          });
            return await tonkho.ToListAsync();
        }
        [HttpGet("getThongke")]
        public async Task<ActionResult<IEnumerable<ThongKeDto>>> GetThongke()
        {
            var tonkho = (from t in _context.Tonkhos
                          join c in _context.Cuahangs on t.MaCh equals c.MaCh
                          join s in _context.Sanphams on t.MaSp equals s.MaSp
                          join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                          select new ThongKeDto()
                          {
                              MaSp = t.MaSp,
                              MaCh = t.MaCh,
                              Sl = t.Sl,
                              Dg = t.Dg,
                              TenCh = c.TenCh,
                              TenSp = s.TenSp,
                              HaBia = h.HaBia
                          });
            return await tonkho.ToListAsync();
        }
        // GET: api/Tonkhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TonkhoDto>> GetTonkho(string id)
        {
            var tonkho = (from t in _context.Tonkhos
                          where t.MaSp == id
                          select new TonkhoDto()
                          {
                              MaSp = t.MaSp,
                              MaCh = t.MaCh,
                              Sl = t.Sl,
                              Dg = t.Dg
                          }).SingleOrDefault();
            return tonkho;
        }


        [HttpGet("pageTonkho")]
        public async Task<ActionResult<IEnumerable<TonkhoDtoList>>> GetTonkhoPage([FromQuery] PagingParameters paging)
        {
            var tonkho = (from t in _context.Tonkhos
                          join c in _context.Cuahangs on t.MaCh equals c.MaCh
                          join s in _context.Sanphams on t.MaSp equals s.MaSp

                          select new TonkhoDtoList()
                          {
                              MaSp = t.MaSp,
                              MaCh = t.MaCh,
                              Sl = t.Sl,
                              Dg = t.Dg,
                              TenCh = c.TenCh,
                              TenSp = s.TenSp
                          }).AsQueryable();
            var result = PagedList<TonkhoDtoList>.ToPagedList(tonkho, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTonkho(string id,string id2 ,[FromBody] TonkhoDto tonkho)
        {
            if (id != tonkho.MaSp && id2 != tonkho.MaCh)
            {
                return BadRequest();
            }
            var temp = await _context.Tonkhos.FindAsync(id,id2);
            if (temp == null)
                return NotFound(id);
            temp.MaSp = tonkho.MaSp;
            temp.MaCh = tonkho.MaCh;
            temp.Sl = tonkho.Sl;
            temp.Dg = tonkho.Dg;
            _context.Tonkhos.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

       [HttpPost]
        public async Task<ActionResult<Tonkho>> PostLoaiSp([FromBody] TonkhoDto tonkho)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Tonkho()
            {
                MaSp = tonkho.MaSp,
                MaCh = tonkho.MaCh,
                Sl = tonkho.Sl,
                Dg = tonkho.Dg
            };
            await _context.Tonkhos.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLoaiSp", new { id = tonkho.MaSp }, tonkho);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTonkho(string id, string id1)
        {
            var tonkho = await _context.Tonkhos.FindAsync(id,id1);
            if (tonkho == null)
            {
                return NotFound();
            }

            _context.Tonkhos.Remove(tonkho);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
