using System;
using System.Collections.Generic;

namespace DBFirstDemo
{
    public partial class Employees
    {
        public Employees()
        {
            InverseReportsTo = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? ReportsToId { get; set; }
        public DateTime? Dob { get; set; }

        public virtual Employees ReportsTo { get; set; }
        public virtual ICollection<Employees> InverseReportsTo { get; set; }
    }
}
