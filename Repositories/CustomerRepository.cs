using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAll() => CustomerDAO.GetCustomers();
        public Customer GetById(int id) => CustomerDAO.GetById(id);
        public Customer GetByEmail(string email) => CustomerDAO.GetByEmail(email);
        public void Add(Customer customer) => CustomerDAO.Add(customer);
        public void Update(Customer customer) => CustomerDAO.Update(customer);
        public void Delete(int id) => CustomerDAO.Delete(id);
    }

}
