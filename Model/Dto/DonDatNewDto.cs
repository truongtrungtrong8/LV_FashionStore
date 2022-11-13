using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class DonDatNewDto
    {
        public string MaDdh { get; set; } = null!;
        public int TongDdh { get; set; }
        public string? Diachi { get; set; }
        public string MaKh { get; set; } = null!;
        public DateTime Thoigian { get; set; }
        public string? TinhTrang { get; set; }
        public string TenKh { get; set; }
    }
}
