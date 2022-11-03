using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class DanhGiaDto
    {
        public int Id { get; set; }
        public string? TenKh { get; set; }
        public string? DanhGia { get; set; }
        public DateTime? NgayDanhGia { get; set; }
        public int BinhChon { get; set; }
        public string MaSp { get; set; } = null!;
    }
}
