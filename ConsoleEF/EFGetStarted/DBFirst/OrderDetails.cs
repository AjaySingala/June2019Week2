using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Orders Order { get; set; }
    }
}
