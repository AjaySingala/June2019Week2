﻿using System;
using System.Collections.Generic;

namespace DBFirstDemo
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual ProductCategories Category { get; set; }
    }
}
