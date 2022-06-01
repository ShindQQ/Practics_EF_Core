using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class Brigade
    {
        public Brigade()
        {
            DoneJobs = new HashSet<DoneJob>();
        }

        public int BrigadeId { get; set; }
        public int BuildingCompanyId { get; set; }
        public int? WorkersAmmount { get; set; }

        public virtual BuildingCompany BuildingCompany { get; set; } = null!;
        public virtual ICollection<DoneJob> DoneJobs { get; set; }
    }
}
