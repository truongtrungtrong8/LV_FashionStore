using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Khachhangs = new HashSet<Khachhang>();
            Nhanviens = new HashSet<Nhanvien>();
        }

        public string TenTk { get; set; } = null!;
        public string? Matkhau { get; set; }
        public string? Quyensd { get; set; }
        public string? TrangThai { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
