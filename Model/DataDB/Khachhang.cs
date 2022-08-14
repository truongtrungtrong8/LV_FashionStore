using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public string MaKh { get; set; } = null!;
        public string TenTk { get; set; } = null!;
        public string? TenKh { get; set; }
        public string? SdtKh { get; set; }
        public string? DiachiKh { get; set; }

        public virtual Taikhoan TenTkNavigation { get; set; } = null!;
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
