using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;

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
                           where h.MaKh == id
                           select new CartItems()
                           {
                               MaSp = l.MaSp,
                               MaGh = s.MaGh,
                               MaKh = h.MaKh,
                               TenSp = x.TenSp,
                               HaBia = l.HaBia,
                               GiaSp = x.GiaSp,
                               Sl = s.Sl,
                           });

            return await cartuser.ToListAsync();
        }

        // PUT: api/CtGhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtGh(string id, CtGh ctGh)
        {
            if (id != ctGh.MaSp)
            {
                return BadRequest();
            }

            _context.Entry(ctGh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtGhExists(id))
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
