using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class DoanhThuNam
    {
        public string Thang { get; set; } = null!;
        public int Nam { get; set; }
        public int DoanhThu { get; set; }
        public int Id { get; set; }
    }
}
