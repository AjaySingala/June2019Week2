using System;
using System.Linq;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetEmployees();
        }

        static void GetEmployees()
        {
            using (var ctx = new FirstDBContext())
            {
                var employees = ctx.Employees.ToList<Employees>();
                foreach(var employee in employees)
                {
                    Console.WriteLine($"{employee.Id}: {employee.Lastname}, {employee.Firstname}");
                }
            }
        }
    }
}
