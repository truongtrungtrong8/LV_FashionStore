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
        [JsonIgnore]

        public string MaGh { get; set; }
        public string MaSp { get; set; }
        public int Sl { get; set; }
        public string TenSp { get; set; }
        public int GiaSp { get; set; }
        public byte? Baohanh { get; set; }
        public string? Mota { get; set; }
        public decimal TotalPrice { get; set; }
        public int EditID { get; set; }
        public string? HaBia { get; set; }

        public virtual ICollection<Size> MaSizes { get; set; }
        public virtual ICollection<Mau> Mamaus { get; set; }
    }


}
