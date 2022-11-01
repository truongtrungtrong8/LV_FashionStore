using System;
using System.Collections.Generic;

namespace Model.DataDB
{
    public partial class Size
    {
        public Size()
        {
            CoSizes = new HashSet<CoSize>();
        }

        public string MaSize { get; set; } = null!;
        public string? TenSize { get; set; }

        public virtual ICollection<CoSize> CoSizes { get; set; }
    }
}
