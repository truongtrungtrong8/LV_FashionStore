using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            CtDns = new HashSet<CtDn>();
            CtHds = new HashSet<CtHd>();
            CtTs = new HashSet<CtT>();
            Hinhanhs = new HashSet<Hinhanh>();
            Khuyenmais = new HashSet<Khuyenmai>();
            Tonkhos = new HashSet<Tonkho>();
        }

        public string MaSp { get; set; } = null!;
        public string MaHsx { get; set; } = null!;
        public string Mamau { get; set; } = null!;
        public string MaLoai { get; set; } = null!;
        public string? TenSp { get; set; }
        public string MaSize { get; set; } = null!;
        public int? GiaSp { get; set; }
        public byte? Baohanh { get; set; }
        public string? Mota { get; set; }

        public virtual Hx MaHsxNavigation { get; set; } = null!;
        public virtual LoaiSp MaLoaiNavigation { get; set; } = null!;
        public virtual Size MaSizeNavigation { get; set; } = null!;
        public virtual Mau MamauNavigation { get; set; } = null!;
        public virtual CtDdh CtDdh { get; set; } = null!;
        public virtual ICollection<CtDn> CtDns { get; set; }
        public virtual ICollection<CtHd> CtHds { get; set; }
        public virtual ICollection<CtT> CtTs { get; set; }
        public virtual ICollection<Hinhanh> Hinhanhs { get; set; }
        public virtual ICollection<Khuyenmai> Khuyenmais { get; set; }
        public virtual ICollection<Tonkho> Tonkhos { get; set; }
    }
}
