using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Khuyenmai
    {
        public int Id { get; set; }
        public DateTime Thoigian { get; set; }
        public string MaSp { get; set; } = null!;
        public double Tile { get; set; }

        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
