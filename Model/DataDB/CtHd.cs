using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtHd
    {
        public string MaSp { get; set; } = null!;
        public string MaHd { get; set; } = null!;
        public int? Sl { get; set; }
        public int? Dg { get; set; }

        public virtual Hoadon MaHdNavigation { get; set; } = null!;
        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
