using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Hinhanh
    {
        public int? MaHa { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public string? HaBia { get; set; }
        public string? Ha1 { get; set; }
        public string? Ha2 { get; set; }
        public string? Ha3 { get; set; }

        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
