using System;
using System.Linq;

namespace FirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetCustomers();
            //GetOrders();

            //CreateCustomer();
            //GetCustomers();
            //DeleteCustomer(13);
            //GetCustomers();

            UsingWhere();
        }

        static void UsingWhere()
        {

            Console.WriteLine();
            Console.WriteLine("List of customers using Where clause...");
            using (MyDbContext ctx = new MyDbContext())
            {
                var customer = ctx.Customers
                    //.Where(c => c.City == "NYC")
                    .Where(c => c.Id == 11)
                    .Single<Customer>();

                //var customers = ctx.Customers;
                //var filteredList = customers.Where(c => c.City == "NYC");

                //foreach (var customer in customers)
                //{
                    Console.WriteLine($"{customer.Id}: {customer.Firstname} {customer.Lastname}");
                //}
            }
        }

        static void DeleteCustomer(int id)
        {
            Console.WriteLine();
            Console.WriteLine("Deleting a customer...");
            using (MyDbContext ctx = new MyDbContext())
            {
                var customerToDelete = ctx.Customers.Find(id);
                if (customerToDelete != null)
                {
                    ctx.Customers.Remove(customerToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        static void CreateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("Creating a new customer...");
            using (MyDbContext ctx = new MyDbContext())
            {
                var newCustomer = new Customer()
                {
                    Firstname = "Ajay",
                    Lastname = "Singala",
                    City = "Reston",
                    State = "VA",
                    IsActive = true,
                    IsDeleted = false
                };

                ctx.Customers.Add(newCustomer);
                ctx.SaveChanges();
            }
        }

        static void GetCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("List of customers...");
            using (MyDbContext ctx = new MyDbContext())
            {
                var customers = ctx.Customers.ToList<Customer>();
                //var customers = ctx.Customers;
                //var filteredList = customers.Where(c => c.City == "NYC");

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Id}: {customer.Firstname} {customer.Lastname}");
                }
            }
        }

        static void GetOrders()
        {
            Console.WriteLine();
            Console.WriteLine("List of Orders...");
            using (MyDbContext ctx = new MyDbContext())
            {
                var orders = ctx.Orders.ToList<Order>();
                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.Id} {order.OrderDate} {order.CustomerId}");
                }
            }
        }
    }
}
