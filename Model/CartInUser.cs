using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model
{
    public class CartInUser
    {
        [JsonIgnore]
        public string MaGh { get; set; }
        public string MaSp { get; set; }
        public string MaKh { get; set; } = null!;
        public int Sl { get; set; }
        public string TenSp { get; set; }
        public int GiaSp { get; set; }
        public decimal TotalPrice { get; set; }
        public int EditID { get; set; }
        public string? HaBia { get; set; }
    }
}
