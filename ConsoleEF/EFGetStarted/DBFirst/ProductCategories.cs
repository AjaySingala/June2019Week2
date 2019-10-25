using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class ProductCategories
    {
        public ProductCategories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
