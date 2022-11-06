using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class DanhgiaSanpham
    {
        public int Id { get; set; }
        public string? TenKh { get; set; }
        public string? DanhGia { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public int BinhChon { get; set; }
        public string MaSp { get; set; } = null!;

        public virtual Sanpham MaSpNavigation { get; set; } = null!;
    }
}
