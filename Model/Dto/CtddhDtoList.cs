using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class CtddhDtoList
    {
        public string MaDdh { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Sl { get; set; }
        public int Dg { get; set; }

        public string Mau { get; set; }
        public string Size { get; set; }
        public string TenKH { get; set; }
        public string Hinhanh { get; set; }
        public string TenSP { get; set; }
        public int TongTien { get; set; }
        public string DiaChi { get; set; }
        public int DanhGia { get; set; }
        public int Id { get; set; }
    }
}
