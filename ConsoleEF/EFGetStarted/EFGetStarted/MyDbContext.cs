using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Customers.db");

        public DbSet<Customer> Customers { get; set; }
    }
}
