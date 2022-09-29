using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;

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
        public async Task<ActionResult<IEnumerable<Hinhanh>>> GetHinhanhs()
        {
            return await _context.Hinhanhs.ToListAsync();
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
        public async Task<ActionResult<Hinhanh>> PostHinhanh(Hinhanh hinhanh, List<IFormFile> myfiles)
        {
         
             if (myfiles.Count > 0)
            {
                int i = 0;
                string[] fileName = new string[myfiles.Count];
                foreach (IFormFile f in myfiles)
                {
                    string fullPath = Path.Combine("https://localhost:7268", "wwwroot", "images", f.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        f.CopyToAsync(file);
                    }
                    fileName[i] = f.FileName;
                    i++;
                }
                if (myfiles.Count == 3)
                {
                    hinhanh.HaBia = fileName[0];
                    hinhanh.Ha1 = fileName[1];
                    hinhanh.Ha2 = fileName[2];
                }
                else
                    hinhanh.HaBia = fileName[0];

            }

            _context.Hinhanhs.Add(hinhanh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHinhanh", new { id = hinhanh.MaHa }, hinhanh);
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

        private bool HinhanhExists(int id)
        {
            return _context.Hinhanhs.Any(e => e.MaHa == id);
        }
    }
}
