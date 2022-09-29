using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Giohang
    {
        public Giohang()
        {
            CtGhs = new HashSet<CtGh>();
        }

        public string MaGh { get; set; } = null!;
        public string MaKh { get; set; } = null!;
        public int? Tongtien { get; set; }
        public DateTime? Ngaydat { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; } = null!;
        public virtual ICollection<CtGh> CtGhs { get; set; }
    }
}
