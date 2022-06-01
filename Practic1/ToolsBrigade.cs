using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class ToolsBrigade
    {
        public int ToolId { get; set; }
        public int BrigadeId { get; set; }

        public virtual Brigade Brigade { get; set; } = null!;
        public virtual Tool Tool { get; set; } = null!;
    }
}
