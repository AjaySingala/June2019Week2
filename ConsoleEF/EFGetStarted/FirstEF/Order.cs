﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FirstEF
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    }
}
