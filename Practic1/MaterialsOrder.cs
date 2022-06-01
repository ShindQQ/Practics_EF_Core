using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class MaterialsOrder
    {
        public int OrderId { get; set; }
        public int MaterialId { get; set; }
        public int? MaterialAmmount { get; set; }
        public int? ActualPrice { get; set; }

        public virtual Material Material { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
