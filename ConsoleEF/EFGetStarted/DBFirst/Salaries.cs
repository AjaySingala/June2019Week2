﻿using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class Salaries
    {
        public int Id { get; set; }
        public decimal? Salary { get; set; }
        public int? EmployeeId { get; set; }
    }
}
