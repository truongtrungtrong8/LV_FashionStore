using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Dondathangs = new HashSet<Dondathang>();
            Giohangs = new HashSet<Giohang>();
            Hoadons = new HashSet<Hoadon>();
        }

        public string MaKh { get; set; } = null!;
        public string? TenTk { get; set; }
        public string? TenKh { get; set; }
        public string? SdtKh { get; set; }
        public string? DiachiKh { get; set; }

        public virtual Taikhoan? TenTkNavigation { get; set; }
        public virtual ICollection<Dondathang> Dondathangs { get; set; }
        public virtual ICollection<Giohang> Giohangs { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
