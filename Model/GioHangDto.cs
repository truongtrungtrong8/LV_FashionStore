using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GioHangDto
    {
        public string MaGh { get; set; } = null!;
        public int? Tongtien { get; set; }
        public DateTime? Ngaydat { get; set; }
    }
}
