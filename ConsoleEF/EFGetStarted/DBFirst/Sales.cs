using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int? SalesPersonId { get; set; }
        public int? SalesOrderId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
