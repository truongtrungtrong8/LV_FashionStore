using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Donnhaps = new HashSet<Donnhap>();
            Hoadons = new HashSet<Hoadon>();
        }

        public string MaNv { get; set; } = null!;
        public string TenTk { get; set; } = null!;
        public string MaCh { get; set; } = null!;
        public string? HtenNv { get; set; }
        public string? GtNv { get; set; }
        public DateTime? NsNv { get; set; }
        public string? DcNv { get; set; }
        public string? ChucvuNv { get; set; }
        public int? LuongNv { get; set; }

        public virtual Cuahang MaChNavigation { get; set; } = null!;
        public virtual Taikhoan TenTkNavigation { get; set; } = null!;
        public virtual ICollection<Donnhap> Donnhaps { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
