namespace DBFirstSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
