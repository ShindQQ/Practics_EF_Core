using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class DoneJob
    {
        public int DoneJobId { get; set; }
        public int JobTypeId { get; set; }
        public int BrigadeId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        public virtual Brigade Brigade { get; set; } = null!;
        public virtual JobType JobType { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
