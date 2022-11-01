using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CoMau
    {
        public string Mamau { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Id { get; set; }

        public virtual Sanpham MaSpNavigation { get; set; } = null!;
        public virtual Mau MamauNavigation { get; set; } = null!;
    }
}
