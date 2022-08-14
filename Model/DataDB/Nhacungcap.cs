using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Donnhaps = new HashSet<Donnhap>();
        }

        public string MaNcc { get; set; } = null!;
        public string? TenNcc { get; set; }
        public string? DiachiNcc { get; set; }
        public string? SdtNcc { get; set; }

        public virtual ICollection<Donnhap> Donnhaps { get; set; }
    }
}
