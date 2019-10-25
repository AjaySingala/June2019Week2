using System;
using System.Collections.Generic;

namespace DBFirstDemo
{
    public partial class ProductAudits
    {
        public int ChangeId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Operation { get; set; }
    }
}
