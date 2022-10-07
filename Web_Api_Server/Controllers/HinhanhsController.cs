using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;
using Models.Page;
using Newtonsoft.Json;
using Web_Api_Server.Repositoreies;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhanhsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly LV_FashionStoreContext _context;

        public HinhanhsController(LV_FashionStoreContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: api/Hinhanhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Images_Model>>> GetHinhanhs()
        {
            var image = (from h in _context.Hinhanhs
                         join s in _context.Sanphams on h.MaSp equals s.MaSp
                         select new Images_Model()
                         {
                             MaHa = h.MaHa,
                             TenSp = s.TenSp,
                             MaSp = h.MaSp,
                             HaBia = h.HaBia,
                             Ha1 = h.Ha1,
                             Ha2 = h.Ha2
                         });
            return await image.ToListAsync();
        }

        // GET: api/Hinhanhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hinhanh>> GetHinhanh(int id)
        {
            var hinhanh = await _context.Hinhanhs.FindAsync(id);

            if (hinhanh == null)
            {
                return NotFound();
            }

            return hinhanh;
        }

        [HttpGet("pageImage")]
        public async Task<ActionResult<PagedList<Images_Model>>> GetProductPages([FromQuery] PagingParameters paging)
        {
            var image = (from h in _context.Hinhanhs
                         join s in _context.Sanphams on h.MaSp equals s.MaSp
                         select new Images_Model()
                         {
                             MaHa = h.MaHa,
                             TenSp = s.TenSp,
                             MaSp = h.MaSp,
                             HaBia = h.HaBia,
                             Ha1 = h.Ha1,
                             Ha2 = h.Ha2
                         }).AsQueryable();
            var result = PagedList<Images_Model>.ToPagedList(image, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }


        // PUT: api/Hinhanhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHinhanh(int id, Hinhanh hinhanh)
        {
            if (id != hinhanh.MaHa)
            {
                return BadRequest();
            }

            _context.Entry(hinhanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HinhanhExists(id))
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

        // POST: api/Hinhanhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hinhanh>> PostHinhanh(ImageDto hinhanh)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = new Hinhanh()
            { 
                
                MaSp = hinhanh.MaSp,
                HaBia = hinhanh.HaBia,
                Ha1 = hinhanh.Ha1,
                Ha2 = hinhanh.Ha2,
                Ha3 = hinhanh.Ha3,
            };

            await _context.Hinhanhs.AddAsync(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.MaHa }, image);
        }

        // DELETE: api/Hinhanhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHinhanh(int id)
        {
            var hinhanh = await _context.Hinhanhs.FindAsync(id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            _context.Hinhanhs.Remove(hinhanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HinhanhExists(int? id)
        {
            return _context.Hinhanhs.Any(e => e.MaHa == id);
        }
    }
}
