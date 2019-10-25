using System;
using System.Collections.Generic;

namespace DBFirstDemo
{
    public partial class Salaries
    {
        public int Id { get; set; }
        public decimal? Salary { get; set; }
        public int? EmployeeId { get; set; }
    }
}
