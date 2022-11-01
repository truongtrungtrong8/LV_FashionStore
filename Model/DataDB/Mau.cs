using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Mau
    {
        public Mau()
        {
            CoMaus = new HashSet<CoMau>();
        }

        public string Mamau { get; set; } = null!;
        public string? Tenmau { get; set; }

        public virtual ICollection<CoMau> CoMaus { get; set; }
    }
}
