using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CreateCustomer();
            //CreateCustomer(2, "Mary", "Jane");
            //CreateCustomer(3, "Joe", "Pesci");
            //CreateCustomer(4, "Neo", "Trinity");
            //CreateCustomer(5, "John", "McEnroe");
            CreateCustomer(6, "Ariel", "Smith");
            GetAllCustomers();
        }

        static void CreateCustomer()
        {
            using (var db = new MyDbContext())
            {
                var customer = new Customer()
                {
                    Id = 1,
                    Firstname = "John",
                    Lastname = "Smith"
                };

                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        static void CreateCustomer(int id, string firstname, string lastname)
        {
            using (var db = new MyDbContext())
            {
                var customer = new Customer()
                {
                    Id = id,
                    Firstname = firstname,
                    Lastname = lastname
                };

                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        static void GetAllCustomers()
        {
            using (var db = new MyDbContext())
            {
                var customers = db.Customers
                    .OrderBy(c => c.Lastname)
                    .ThenBy(c => c.Firstname);
                foreach(var customer in customers)
                {
                    Console.WriteLine($"{customer.Id}: {customer.Lastname}, {customer.Firstname}");
                }
            }
        }
    }
}
