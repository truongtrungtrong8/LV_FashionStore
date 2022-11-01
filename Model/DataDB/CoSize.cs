using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class CoSize
    {
        public string MaSp { get; set; } = null!;
        public string MaSize { get; set; } = null!;
        public int Id { get; set; }

        public virtual Size MaSizeNavigation { get; set; } = null!;
        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
