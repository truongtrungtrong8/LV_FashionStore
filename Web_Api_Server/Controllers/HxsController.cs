using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class HxsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public HxsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Hxs
        [HttpGet("count")]
        public async Task<ActionResult<IEnumerable<Hx>>> GetCountHxs()
        {
            return await _context.Hxs.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangsxDto>>> GetHxs()
        {
            var hsx = (from h in _context.Hxs
                       select new HangsxDto()
                       {
                           MaHsx = h.MaHsx,
                           TenHsx = h.TenHsx
                       }).ToListAsync();
            return await hsx;
        }
        // GET: api/Hxs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HangsxDto>> GetHx(string id)
        {
            var hsx = (from h in _context.Hxs
                       where h.MaHsx == id
                       select new HangsxDto()
                       {
                           MaHsx = h.MaHsx,
                           TenHsx = h.TenHsx
                       }).SingleOrDefault();

            return hsx;
        }

        //Page
        [HttpGet("pageHsx")]
        public async Task<ActionResult<IEnumerable<HangsxDto>>> GetLoaiSpPage([FromQuery] PagingParameters paging)
        {
            var hsx = (from h in _context.Hxs
                       select new HangsxDto()
                       {
                           MaHsx = h.MaHsx,
                           TenHsx = h.TenHsx
                       }).AsQueryable();
            var result = PagedList<HangsxDto>.ToPagedList(hsx, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;
        }

        // PUT: api/Hxs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHx(string id,[FromBody] HangsxDto hsx)
        {
            if(id != hsx.MaHsx)
            {
                return BadRequest();
            }
            var temp = await _context.Hxs.FindAsync(id);
            if (temp == null)
                return NotFound(id);
            temp.MaHsx = hsx.MaHsx;
            temp.TenHsx = hsx.TenHsx;
            _context.Hxs.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Hxs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hx>> PostHx(Hx hx)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Hx()
            {
                MaHsx = hx.MaHsx,
                TenHsx = hx.TenHsx,
            };
            await _context.Hxs.AddAsync(temp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHx", new { id = hx.MaHsx }, hx);
        }

        // DELETE: api/Hxs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHx(string id)
        {
            var hx = await _context.Hxs.FindAsync(id);
            if (hx == null)
            {
                return NotFound();
            }

            _context.Hxs.Remove(hx);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HxExists(string id)
        {
            return _context.Hxs.Any(e => e.MaHsx == id);
        }
    }
}
