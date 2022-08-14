using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtT
    {
        public string MaSp { get; set; } = null!;
        public string MaTs { get; set; } = null!;
        public string? Donvi { get; set; }

        public virtual Sanpham MaSpNavigation { get; set; } = null!;
        public virtual Thongsosp MaTsNavigation { get; set; } = null!;
    }
}
