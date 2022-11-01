using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtGh
    {
        public string MaSp { get; set; } = null!;
        public string MaGh { get; set; } = null!;
        public int Sl { get; set; }
        public string? Mau { get; set; }
        public string? Size { get; set; }

        public virtual Giohang MaGhNavigation { get; set; } = null!;
        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
