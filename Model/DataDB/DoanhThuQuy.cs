using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class DoanhThuQuy
    {
        public int Id { get; set; }
        public string Quy { get; set; } = null!;
        public int Nam { get; set; }
        public int DoanhThu { get; set; }
    }
}
