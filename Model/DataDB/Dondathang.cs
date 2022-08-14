using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Dondathang
    {
        public string MaDdh { get; set; } = null!;
        public int? TongDdh { get; set; }
        public string? Diachi { get; set; }

        public virtual CtDdh CtDdh { get; set; } = null!;
    }
}
