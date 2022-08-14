using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Mau
    {
        public Mau()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string Mamau { get; set; } = null!;
        public string? Tenmau { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
