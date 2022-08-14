using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Thongsosp
    {
        public Thongsosp()
        {
            CtTs = new HashSet<CtT>();
        }

        public string MaTs { get; set; } = null!;
        public string? TenTs { get; set; }

        public virtual ICollection<CtT> CtTs { get; set; }
    }
}
