using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class KhuyenMaiDto
    {
        public int Id { get; set; }
        public DateTime Thoigian { get; set; }
        
        public double Tile { get; set; }
        public string MaSp { get; set; }
    }
}
