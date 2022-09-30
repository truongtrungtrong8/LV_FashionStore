﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using Newtonsoft.Json;
using Web_Api_Server.Repositoreies;

namespace Web_Api_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamsController : ControllerBase
    {
        private readonly LV_FashionStoreContext _context;

        public SanphamsController(LV_FashionStoreContext context)
        {
            _context = context;
        }

        // GET: api/Sanphams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sanpham_Model>>> GetProducts()
        {
            var sanpham = (from s in _context.Sanphams
                           join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                           join hsx in _context.Hxs on s.MaHsx equals hsx.MaHsx
                           join l in _context.LoaiSps on s.MaLoai equals l.MaLoai
                           select new Sanpham_Model()
                           {
                               MaSp = s.MaSp,
                               MaLoai = s.MaLoai,
                               HaBia = h.HaBia,
                               Ha1 = h.Ha1,
                               Ha2 = h.Ha2,
                               GiaSp = s.GiaSp,
                               TenSp = s.TenSp,
                               TenHsx = hsx.TenHsx
                               
                           });
            return await sanpham.ToListAsync();
           


        }
        [HttpGet("page")]
        public async Task<ActionResult<PagedList<Sanpham_Model>>> GetProductPages([FromQuery] PagingParameters paging)
        {
            var sanpham = (from s in _context.Sanphams
                           join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                           join hsx in _context.Hxs on s.MaHsx equals hsx.MaHsx
                           join l in _context.LoaiSps on s.MaLoai equals l.MaLoai
                           select new Sanpham_Model()
                           {
                               MaSp = s.MaSp,
                               MaLoai = s.MaLoai,
                               HaBia = h.HaBia,
                               Ha1 = h.Ha1,
                               Ha2 = h.Ha2,
                               GiaSp = s.GiaSp,
                               TenSp = s.TenSp,
                               TenHsx = hsx.TenHsx
                           }).Search(paging.SearchTerm).AsQueryable();
            
           
            var result = PagedList<Sanpham_Model>.ToPagedList(sanpham, paging.PageNumber, paging.PageSize);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return result;


        }
        
        // GET: api/Sanphams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sanpham_Model>> GetSanpham(string id)
        {
            var sanpham = (from s in _context.Sanphams
                           join h in _context.Hinhanhs on s.MaSp equals h.MaSp
                           join hsx in _context.Hxs on s.MaHsx equals hsx.MaHsx
                           join l in _context.LoaiSps on s.MaLoai equals l.MaLoai
                           where s.MaSp == id
                           select new Sanpham_Model()
                           {
                               MaSp = s.MaSp,
                               MaLoai = s.MaLoai,
                               HaBia = h.HaBia,
                               Ha1 = h.Ha1,
                               Ha2 = h.Ha2,
                               GiaSp = s.GiaSp,
                               TenSp = s.TenSp,
                               TenHsx = hsx.TenHsx,
                               Tenloai = l.Tenloai,
                               Mota = s.Mota,
                               MaHsx = hsx.MaHsx,
                               Baohanh = s.Baohanh
                               
                           }).SingleOrDefault();

            return sanpham;
        }

        // PUT: api/Sanphams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanpham(string id,[FromBody] SanphamEdit sanpham)
        {
            if (id != sanpham.MaSp)
            {
                return BadRequest();
            }

            var temp = await _context.Sanphams.FindAsync(id);
            if (temp == null)
                return NotFound($"{id} is not found");

            temp.MaSp = sanpham.MaSp;
            temp.TenSp = sanpham.TenSp;
            temp.Mota = sanpham.Mota;
            temp.GiaSp = sanpham.GiaSp;
            temp.MaHsx = sanpham.MaHsx;
            temp.MaLoai = sanpham.MaLoai;
            temp.Baohanh = sanpham.Baohanh;

            _context.Sanphams.Update(temp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Sanphams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sanpham>> PostSanpham([FromBody] SanphamEdit sanpham)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var temp = new Sanpham()
            {
                MaSp = sanpham.MaSp,
                TenSp = sanpham.TenSp,
                Mota = sanpham.Mota,
                GiaSp = sanpham.GiaSp,
                MaHsx = sanpham.MaHsx,
                MaLoai = sanpham.MaLoai,
                Baohanh = sanpham.Baohanh,
        };
            await _context.Sanphams.AddAsync(temp);
            await _context.SaveChangesAsync();
        return CreatedAtAction("GetSanpham", new { id = sanpham.MaSp}, sanpham);
        }

// DELETE: api/Sanphams/5
[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanpham(string id)
        {
            if (_context.Sanphams == null)
            {
                return NotFound();
            }
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanphamExists(string id)
        {
            return (_context.Sanphams?.Any(e => e.MaSp == id)).GetValueOrDefault();
        }
        
    }
}
