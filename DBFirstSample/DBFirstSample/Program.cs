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
            // Quiz
            //Quiz();

            CreateCustomer("Joe Cole");
            GetCustomers();

            //CreateCustomer("Mary Jane");
            //CreateCustomer("Neo Trinity");
            //CreateCustomer("John Smith");
            //GetCustomers();

            //// Delete Customer.
            //DeleteCustomer(3);
            //GetCustomers();

            //// Update Customer.
            //UpdateCustomer(1, "Ed Joe");
            //GetCustomers();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        static void Quiz()
        {
            string[] words = { "banana", "stamp", "lamp", "sample" };
            string[] numbers = { "5", "six", "nine", "three", "seven" };
            string[] animals = { "fish", "cat", "bear", "bird", "dog" };

            var allThings = words.Union(numbers)
                .OrderBy(x => x.Length)
                .Union(animals).Reverse();

            Console.WriteLine(allThings.ElementAt(5));
            Console.WriteLine(allThings.ElementAt(8));

            string[] trees = { "cedar", "pine", "", "fur", "spruce", "oak" };
            string[] vehicles = { "car", "truck", "moto", "boat", "plain" };

            var a = trees.Union(vehicles)
                .Where(x => x.Length < 5);
            var b = trees.Union(vehicles)
                .Where(x => x.Length < 5)
                .OrderBy(x => x.Length);

            var allThings2 = trees.Union(vehicles)
                .Where(x => x.Length < 5)
                .OrderBy(x => x.Length)
                .Union(trees).Reverse();

            int numberOfItems = allThings.Count();
            Console.WriteLine($"Number of Items: {numberOfItems}");
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
                    Console.WriteLine($"{cust.Id}: {cust.Name}");
                }
            }
        }

        static void CreateCustomer(string name)
        {
            using (var ctx = new TestEFDBFirstContext())
            {
                var customer = new Customer()
                {
                    Name = name
                };

                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }
    }
}
