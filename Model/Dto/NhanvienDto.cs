using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class NhanvienDto
    {
        public string MaNv { get; set; } = null!;
        public string TenTk { get; set; } = null!;
        public string MaCh { get; set; } = null!;
        public string? HtenNv { get; set; }
        public string? GtNv { get; set; }
        public DateTime? NsNv { get; set; }
        public string? DcNv { get; set; }
        public string? ChucvuNv { get; set; }
        public int LuongNv { get; set; }
    }
}
