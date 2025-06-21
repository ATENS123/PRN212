using System.Collections.Generic;
using BusinessObject;
using Repositories;
using Services;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public IEnumerable<Customer> GetAllCustomers() => _customerRepository.GetAll();

        public Customer GetCustomerById(int id) => _customerRepository.GetById(id);

        public Customer GetCustomerByEmail(string email) => _customerRepository.GetByEmail(email);

        public void AddCustomer(Customer customer) => _customerRepository.Add(customer);

        public void UpdateCustomer(Customer customer) => _customerRepository.Update(customer);

        public void DeleteCustomer(int id) => _customerRepository.Delete(id);

        public bool Login(string email, string password)
        {
            var user = _customerRepository.GetByEmail(email);
            return user != null && user.Password == password;
        }
    }
}
