using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class SanphamEdit
    {
        public string MaSp { get; set; }
        public string MaHsx { get; set; }
        public string MaLoai { get; set; }
        public string TenSp { get; set; }
        public int GiaSp { get; set; }
        public int Baohanh { get; set; }
        public string? Mota { get; set; }
        public int Sl { get; set; }
        public string? TinhTrang { get; set; }
    }
}
