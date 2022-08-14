using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Size
    {
        public Size()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string MaSize { get; set; } = null!;
        public string? TenSize { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
