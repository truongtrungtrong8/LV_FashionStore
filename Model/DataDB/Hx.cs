using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Hx
    {
        public Hx()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string MaHsx { get; set; } = null!;
        public string? TenHsx { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
