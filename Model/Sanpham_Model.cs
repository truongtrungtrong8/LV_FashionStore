using Model.DataDB;
using Models.Page;
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
        public string TenSp { get; set; }
        public string MaSize { get; set; } = null!;
        public int GiaSp { get; set; }
        public int Baohanh { get; set; }
        public string? Mota { get; set; } = null!;

        public int? MaHa { get; set; } = null!;

        public string? HaBia { get; set; }
        public string? Ha1 { get; set; }
        public string? Ha2 { get; set; }
        public string? Ha3 { get; set; }
        public string? TenHsx { get; set; }
        public string? Tenloai { get; set; }
        public int Sl { get; set; }
        public DateTime Thoigian { get; set; }

        public string? TinhTrang {get; set;}

        public double Tile { get; set; }
        public List<CartItems> Variants { get; set; } = new List<CartItems>();

        public Sanpham_Model()
        {
            MaSizes = new HashSet<Size>();
            Mamaus = new HashSet<Mau>();
        }

        public virtual ICollection<Size> MaSizes { get; set; }
        public virtual ICollection<Mau> Mamaus { get; set; }
    }
}
