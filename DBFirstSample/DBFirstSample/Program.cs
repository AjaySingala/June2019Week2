using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateCustomer();
            GetCustomers();

            //// Delete Customer.
            //DeleteCustomer(3);
            //GetCustomers();

            // Update Customer.
            UpdateCustomer(1, "Ed Joe");
            GetCustomers();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }


        static void UpdateCustomer(int id, string name)
        {
            using (var ctx = new TestEFDBFirstContext())
            {
                var customer = ctx.Customers
                    .Where(c => c.Id == id)
                    .SingleOrDefault<Customer>();

                if (customer != null)
                {
                    customer.Name = name;
                    ctx.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                    ctx.SaveChanges();
                }
            }
        }

        static void DeleteCustomer(int id)
        {
            using (var ctx = new TestEFDBFirstContext())
            {
                var customer = ctx.Customers
                    .Where(c => c.Id == id)
                    .SingleOrDefault<Customer>();
                if(customer != null)
                {
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                }
            }
        }

        static void GetCustomers()
        {
            Console.WriteLine("List of Customers...");
            using (var ctx = new TestEFDBFirstContext())
            {
                var customers = ctx.Customers.ToList<Customer>();

                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.Name}");
                }
            }
        }

        static void CreateCustomer()
        {
            using (var ctx = new TestEFDBFirstContext())
            {
                var customer = new Customer()
                {
                    Name = "Joe Cole"
                };

                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }
    }
}
