using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
