using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Donnhap
    {
        public Donnhap()
        {
            CtDns = new HashSet<CtDn>();
        }

        public string MaDn { get; set; } = null!;
        public string MaNcc { get; set; } = null!;
        public string MaNv { get; set; } = null!;
        public DateTime? NgaylapHd { get; set; }
        public int? TongDn { get; set; }

        public virtual Nhacungcap MaNccNavigation { get; set; } = null!;
        public virtual Nhanvien MaNvNavigation { get; set; } = null!;
        public virtual ICollection<CtDn> CtDns { get; set; }
    }
}
