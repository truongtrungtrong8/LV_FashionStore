using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string MaLoai { get; set; } = null!;
        public string? Tenloai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
