using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            CtDdhs = new HashSet<CtDdh>();
            CtDns = new HashSet<CtDn>();
            CtGhs = new HashSet<CtGh>();
            CtHds = new HashSet<CtHd>();
            CtTs = new HashSet<CtT>();
            Hinhanhs = new HashSet<Hinhanh>();
            Khuyenmais = new HashSet<Khuyenmai>();
            Tonkhos = new HashSet<Tonkho>();
            MaSizes = new HashSet<Size>();
            Mamaus = new HashSet<Mau>();
        }

        public string MaSp { get; set; } = null!;
        public string MaHsx { get; set; } = null!;
        public string MaLoai { get; set; } = null!;
        public string TenSp { get; set; }
        public int GiaSp { get; set; }
        public int? Baohanh { get; set; }
        public string? Mota { get; set; }

        public virtual Hx MaHsxNavigation { get; set; } = null!;
        public virtual LoaiSp MaLoaiNavigation { get; set; } = null!;
        public virtual ICollection<CtDdh> CtDdhs { get; set; }
        public virtual ICollection<CtDn> CtDns { get; set; }
        public virtual ICollection<CtGh> CtGhs { get; set; }
        public virtual ICollection<CtHd> CtHds { get; set; }
        public virtual ICollection<CtT> CtTs { get; set; }
        public virtual ICollection<Hinhanh> Hinhanhs { get; set; }
        public virtual ICollection<Khuyenmai> Khuyenmais { get; set; }
        public virtual ICollection<Tonkho> Tonkhos { get; set; }

        public virtual ICollection<Size> MaSizes { get; set; }
        public virtual ICollection<Mau> Mamaus { get; set; }
    }
}
