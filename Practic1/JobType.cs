using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class JobType
    {
        public JobType()
        {
            DoneJobs = new HashSet<DoneJob>();
        }

        public int JobTypeId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DoneJob> DoneJobs { get; set; }
    }
}
