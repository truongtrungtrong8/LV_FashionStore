using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DataDB;

namespace Web_Admin_Client.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LV_FashionStoreContext _context;

        public CreateModel(LV_FashionStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MaHsx"] = new SelectList(_context.Hxs, "MaHsx", "MaHsx");
        ViewData["MaLoai"] = new SelectList(_context.LoaiSps, "MaLoai", "MaLoai");
            return Page();
        }

        [BindProperty]
        public Sanpham Sanpham { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sanphams.Add(Sanpham);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
