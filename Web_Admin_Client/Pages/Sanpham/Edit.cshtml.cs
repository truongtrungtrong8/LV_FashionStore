using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;

namespace Web_Admin_Client.Pages
{
    public class EditModel : PageModel
    {
        private readonly LV_FashionStoreContext _context;

        public EditModel(LV_FashionStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sanpham Sanpham { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham =  await _context.Sanphams.FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            Sanpham = sanpham;
           ViewData["MaHsx"] = new SelectList(_context.Hxs, "MaHsx", "MaHsx");
           ViewData["MaLoai"] = new SelectList(_context.LoaiSps, "MaLoai", "MaLoai");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanphamExists(Sanpham.MaSp))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SanphamExists(string id)
        {
          return _context.Sanphams.Any(e => e.MaSp == id);
        }
    }
}
