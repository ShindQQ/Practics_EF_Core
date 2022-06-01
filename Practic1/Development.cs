using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class Development
    {
        public Development()
        {
            Orders = new HashSet<Order>();
        }

        public int DevelopmentId { get; set; }
        public int? Size { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
