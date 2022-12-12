using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class HoaDonDto
    {
        public string MaHd { get; set; } = null!;
        public string MaNv { get; set; } = null!;
        public string MaKh { get; set; } = null!;
        public DateTime? NgaylapHd { get; set; }
        public int TongHd { get; set; }
        public string? DiachiHd { get; set; }
    }
}
