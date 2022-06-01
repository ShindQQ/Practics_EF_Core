using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class WorkersBrigade
    {
        public int WorkerId { get; set; }
        public int BrigadeId { get; set; }

        public virtual Brigade Brigade { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
