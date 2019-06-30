using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCustomer(1);
            //GetAllOrders();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        static void GetAllOrders()
        {
            var ctx = new TestDbContext();
            var orders = ctx.Orders.ToList<Order>();
                //.Include("Customer");
            foreach(var order in orders)
            {
                Console.Write($"{order.Id} - {order.OrderDate.ToString("dd-MMM-yyyy")} - {order.CustomerId}");
                Console.WriteLine($" - {order.Customer.Firstname} - {order.Customer.Lastname}");
            }
        }

        static void GetCustomer(int id)
        {
            var ctx = new TestDbContext();
            var customer = ctx.Customers
                .Where(c => c.Id == id)
                .SingleOrDefault<Customer>();

            Console.WriteLine($"Customer Name: {customer.Firstname} {customer.Lastname}");
            foreach(var order in customer.Orders)
            {
                Console.WriteLine($"Order Id: {order.Id}. Order Date: {order.OrderDate}");
            }
        }
    }
}
