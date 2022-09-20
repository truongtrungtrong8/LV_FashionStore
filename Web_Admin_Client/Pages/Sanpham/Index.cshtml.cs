using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.DataDB;

namespace Web_Admin_Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LV_FashionStoreContext _context;

        public IndexModel(LV_FashionStoreContext context)
        {
            _context = context;
        }

        public IList<Sanpham> Sanpham { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sanphams != null)
            {
                Sanpham = await _context.Sanphams
                .Include(s => s.MaHsxNavigation)
                .Include(s => s.MaLoaiNavigation).ToListAsync();
            }
        }
    }
}
