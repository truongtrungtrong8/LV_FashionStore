using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class DoanhThuNgay
    {
        public int Id { get; set; }
        public int? Ngay { get; set; }
        public string? Thang { get; set; }
        public int? DoanhThu { get; set; }
    }
}
