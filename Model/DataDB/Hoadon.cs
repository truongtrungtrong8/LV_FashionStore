using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            CtHds = new HashSet<CtHd>();
        }

        public string MaHd { get; set; } = null!;
        public string MaNv { get; set; } = null!;
        public string MaKh { get; set; } = null!;
        public DateTime? NgaylapHd { get; set; }
        public int? TongHd { get; set; }
        public string? DiachiHd { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; } = null!;
        public virtual Nhanvien MaNvNavigation { get; set; } = null!;
        public virtual ICollection<CtHd> CtHds { get; set; }
    }
}
