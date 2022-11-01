using Model.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model
{
    public class CartItems
    {
        public string MaGh { get; set; }
        public string MaSp { get; set; }
        public string MaKh { get; set; } = null!;
        public int Sl { get; set; }
        public string TenSp { get; set; }
        public int GiaSp { get; set; }
        public string? HaBia { get; set; }
        public int Id { get; set; }
        public DateTime Thoigian { get; set; }

        public double Tile { get; set; }

        public string Ma_Size { get; set; }
        public string Ten_Size { get; set; }
        public string Ma_Mau { get; set; }
        public string Ten_Mau { get; set; }
    }


}
