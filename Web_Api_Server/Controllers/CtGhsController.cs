using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;
using Model.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtGhsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public CtGhsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/CtGhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtGh>>> GetCtGhs()
        {
            return await _context.CtGhs.ToListAsync();
        }

        // GET: api/CtGhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CartItems>>> GetCtGh(string id)
        {

            var cartuser = (from s in _context.CtGhs
                           join h in _context.Giohangs on s.MaGh equals h.MaGh
                           join x in _context.Sanphams on s.MaSp equals x.MaSp
                           join l in _context.Hinhanhs on x.MaSp equals l.MaSp
                           join k in _context.Khuyenmais on x.MaSp equals k.MaSp
                           
                           where s.MaGh == id
                           select new CartItems()
                           {
                               MaSp = s.MaSp,
                               MaGh = s.MaGh,
                               MaKh = h.MaKh,
                               TenSp = x.TenSp,
                               HaBia = l.HaBia,
                               GiaSp = x.GiaSp,
                               Sl = s.Sl,
                               Thoigian = k.Thoigian,
                               Tile = k.Tile,
                               Ten_Mau = s.Mau,
                               Ten_Size = s.Size
                           });
            return await cartuser.ToListAsync();
        }
        //
        [HttpGet("getCartBySP")]
        public async Task<ActionResult<CartItems>> GetCartBySp(string id)
        {

            var cartuser = (from s in _context.CtGhs
                            join h in _context.Giohangs on s.MaGh equals h.MaGh
                            join x in _context.Sanphams on s.MaSp equals x.MaSp
                            join l in _context.Hinhanhs on x.MaSp equals l.MaSp
                            join k in _context.Khuyenmais on x.MaSp equals k.MaSp
                            
                            where x.MaSp == id
                            select new CartItems()
                            {
                                MaSp = s.MaSp,
                                MaGh = s.MaGh,
                                MaKh = h.MaKh,
                                TenSp = x.TenSp,
                                HaBia = l.HaBia,
                                GiaSp = x.GiaSp,
                                Sl = s.Sl,
                                Thoigian = k.Thoigian,
                                Tile = k.Tile,
                                Ten_Mau = s.Mau,
                                Ten_Size = s.Size
                            });
            return await cartuser.SingleOrDefaultAsync();
        }
        [HttpGet("GetCTGiohang")]
        public async Task<ActionResult<CtGioHangDto>> GetCtGiohang(string id, string id1)
        {

            var giohang = (from g in _context.CtGhs
                           where g.MaSp == id && g.MaGh == id1
                           select new CtGioHangDto()
                           {
                               MaGh = g.MaGh,
                               MaSp = g.MaSp,
                               Sl = g.Sl,
                               Size = g.Size,
                               Mau = g.Mau
                           }).SingleOrDefault();
            return giohang;
        }

        [HttpGet("GetCTGiohangSanpham")]
        public async Task<ActionResult<CtGioHangDto>> GetCtGiohangSanpham(string id)
        {

            var giohang = (from g in _context.CtGhs
                           where g.MaSp == id
                           select new CtGioHangDto()
                           {
                               MaGh = g.MaGh,
                               MaSp = g.MaSp,
                               Sl = g.Sl
                           }).SingleOrDefault();
            return giohang;
        }

        // PUT: api/CtGhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtGh(string id,string id1, [FromBody] CTGioHangDto ctGh)
        {

            if (id != ctGh.MaSp && id1 != ctGh.MaGh )
            {
                return BadRequest();
            }
            var temp = await _context.CtGhs.FindAsync(id, id1);
            if (temp == null)
                return NotFound(id);
            temp.MaGh = ctGh.MaGh;
            temp.MaSp = ctGh.MaSp;
            temp.Sl = ctGh.Sl;
            temp.Mau = ctGh.Mau;
            temp.Size = ctGh.Size;
            _context.CtGhs.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/CtGhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtGh>> PostCtGh([FromBody] CTGioHangDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ctgh = new CtGh()
            {
                MaSp = request.MaSp,
                MaGh = request.MaGh,
                Sl = request.Sl,
                Size = request.Size,
                Mau = request.Mau,
            };

            await _context.CtGhs.AddAsync(ctgh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtGh", new { id = ctgh.MaSp }, ctgh);
        }

        // DELETE: api/CtGhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtGh(string id,string id1)
        {

            var ctGh = await _context.CtGhs.FindAsync(id,id1);
            //var giohang = await _context.Giohangs.FindAsync(id1);
            if (ctGh == null)
            {
                return NotFound();
            }

            _context.CtGhs.Remove(ctGh);
            //_context.Giohangs.Remove(giohang);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool CtGhExists(string id)
        {
            return _context.CtGhs.Any(e => e.MaSp == id);
        }
    }
}
