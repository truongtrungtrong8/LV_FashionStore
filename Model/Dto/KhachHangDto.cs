using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class KhachHangDto
    {
        public string MaKh { get; set; } = null!;
        public string? TenTk { get; set; }
        public string? TenKh { get; set; }
        public string? SdtKh { get; set; }
        public string? DiachiKh { get; set; }
    }
}
