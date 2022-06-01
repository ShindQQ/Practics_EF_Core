using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class Order
    {
        public Order()
        {
            DoneJobs = new HashSet<DoneJob>();
        }

        public int OrderId { get; set; }
        public int DevelopmentId { get; set; }
        public int CustomerId { get; set; }
        public int BuildingCompanyId { get; set; }
        public int WorkersAmmount { get; set; }
        public decimal EstimatedPrice { get; set; }

        public virtual BuildingCompany BuildingCompany { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Development Development { get; set; } = null!;
        public virtual ICollection<DoneJob> DoneJobs { get; set; }
    }
}
