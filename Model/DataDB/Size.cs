using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Size
    {
        public Size()
        {
            MaSps = new HashSet<Sanpham>();
        }

        public string MaSize { get; set; } = null!;
        public string? TenSize { get; set; }

        public virtual ICollection<Sanpham> MaSps { get; set; }
    }
}
