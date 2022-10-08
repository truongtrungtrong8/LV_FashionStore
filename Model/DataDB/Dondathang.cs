﻿using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Dondathang
    {
        public Dondathang()
        {
            CtDdhs = new HashSet<CtDdh>();
        }

        public string MaDdh { get; set; } = null!;
        public int TongDdh { get; set; }
        public string? Diachi { get; set; }

        public virtual ICollection<CtDdh> CtDdhs { get; set; }
    }
}
