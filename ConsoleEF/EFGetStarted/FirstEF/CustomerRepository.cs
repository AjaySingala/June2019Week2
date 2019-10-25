using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstEF
{
    public class CustomerRepository
    {
        private MyDbContext _context;

        public CustomerRepository()
        {
            _context = new MyDbContext();
        }

        public List<Customer> Get()
        {
            var customers = _context.Customers.ToList<Customer>();

            return customers;
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers
                .Where(c => c.Id == id)
                .SingleOrDefault<Customer>();

            return customer;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Customer customer)
        {
            if (customer != null && id > 0)
            {
                _context.Update(customer);
                _context.SaveChanges();
            }
        }

    }
}
