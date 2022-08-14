using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Cuahang
    {
        public Cuahang()
        {
            Nhanviens = new HashSet<Nhanvien>();
            Tonkhos = new HashSet<Tonkho>();
        }

        public string MaCh { get; set; } = null!;
        public string? TenCh { get; set; }
        public string? DiachiCh { get; set; }
        public string? SdtCh { get; set; }
        public string? MaNql { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
        public virtual ICollection<Tonkho> Tonkhos { get; set; }
    }
}
