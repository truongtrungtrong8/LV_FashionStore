using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;
using Model.Dto;

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
        public async Task<IActionResult> DeleteLoaiSp(string id)
        {
            var tonkho = await _context.Tonkhos.FindAsync(id);
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
