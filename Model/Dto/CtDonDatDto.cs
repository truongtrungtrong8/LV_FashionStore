using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class CtDonDatDto
    {
        public string MaDdh { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Sl { get; set; }
        public int Dg { get; set; }

        public string Mau { get; set; }
        public string Size { get; set; }
        public int DanhGia { get; set; }
    }
}
