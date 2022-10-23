﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class ThongKeDto
    {
        public string MaSp { get; set; } = null!;
        public string MaCh { get; set; } = null!;
        public int Sl { get; set; }
        public int Dg { get; set; }
        public string TenSp { get; set; }
        public string TenCh { get; set; }
        public string HaBia { get; set; }
    }
}
