using System;
using System.Collections.Generic;
using System.Text;

namespace FirstEF
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
