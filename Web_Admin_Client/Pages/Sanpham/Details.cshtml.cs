﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;

namespace Web_Admin_Client.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly LV_FashionStoreContext _context;

        public DetailsModel(LV_FashionStoreContext context)
        {
            _context = context;
        }

      public Sanpham Sanpham { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            else 
            {
                Sanpham = sanpham;
            }
            return Page();
        }
    }
}
