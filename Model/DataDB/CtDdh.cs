using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtDdh
    {
        public string MaSp { get; set; } = null!;
        public int? Sl { get; set; }
        public int? Dg { get; set; }

        public virtual Sanpham MaSp1 { get; set; } = null!;
        public virtual Dondathang MaSpNavigation { get; set; } = null!;
    }
}
