using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtDdh
    {
        public string MaDdh { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Sl { get; set; }
        public int Dg { get; set; }
        public string? Mau { get; set; }
        public string? Size { get; set; }
        public int DanhGia { get; set; }

        public virtual Dondathang MaDdhNavigation { get; set; } = null!;
        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
