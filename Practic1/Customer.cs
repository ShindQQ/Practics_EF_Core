using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Pname { get; set; }
        public int PassportId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
