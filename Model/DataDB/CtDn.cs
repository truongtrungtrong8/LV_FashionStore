using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CtDn
    {
        public string MaDn { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Sl { get; set; }
        public int Dg { get; set; }

        public virtual Donnhap MaDnNavigation { get; set; } = null!;
        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
