using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class Worker
    {
        public int WorkerId { get; set; }
        public string? Speciality { get; set; }
        public string? Professionalism { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
