using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sanpham_Model
    {
        public string MaSp { get; set; } = null!;
        public string MaHsx { get; set; } = null!;
        public string Mamau { get; set; } = null!;
        public string MaLoai { get; set; } = null!;
        public string? TenSp { get; set; }
        public string MaSize { get; set; } = null!;
        public int? GiaSp { get; set; }
        public byte? Baohanh { get; set; }
        public string? Mota { get; set; }

        public string MaHa { get; set; } = null!;
      
        public string? HaBia { get; set; }
        public string? Ha1 { get; set; }
        public string? Ha2 { get; set; }
        public string? Ha3 { get; set; }
    }
}
