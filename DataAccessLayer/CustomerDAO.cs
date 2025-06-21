using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer(1, "Admin", "admin@FUMiniHotelSystem.com", "0123456789", new DateTime(2000, 1, 1), 1, "@@abc123@@"),
            new Customer(2, "Nguyen Van A", "a1@gmail.com", "0900000001", new DateTime(1999, 5, 10), 1, "123"),
            new Customer(3, "Tran Thi B", "b2@gmail.com", "0900000002", new DateTime(1998, 3, 22), 1, "123"),
            new Customer(4, "Le Van C", "c3@gmail.com", "0900000003", new DateTime(1995, 4, 5), 1, "123"),
            new Customer(5, "Pham Thi D", "d4@gmail.com", "0900000004", new DateTime(2001, 11, 11), 1, "123"),
            new Customer(6, "Do Van E", "e5@gmail.com", "0900000005", new DateTime(1997, 2, 2), 1, "123"),
            new Customer(7, "Hoang Thi F", "f6@gmail.com", "0900000006", new DateTime(2000, 6, 6), 1, "123"),
            new Customer(8, "Nguyen Van G", "g7@gmail.com", "0900000007", new DateTime(1996, 9, 9), 1, "123"),
            new Customer(9, "Tran Thi H", "h8@gmail.com", "0900000008", new DateTime(2002, 10, 10), 1, "123"),
            new Customer(10, "Le Van I", "i9@gmail.com", "0900000009", new DateTime(1994, 12, 12), 1, "123")
        };

        public static List<Customer> GetCustomers() => customers;

        public static Customer GetById(int id) => customers.FirstOrDefault(c => c.CustomerID == id);

        public static Customer GetByEmail(string email) => customers.FirstOrDefault(c => c.EmailAddress == email);

        public static void Add(Customer customer)
        {
            customer.CustomerID = customers.Any() ? customers.Max(c => c.CustomerID) + 1 : 1;
            customers.Add(customer);
        }

        public static void Update(Customer customer)
        {
            var existing = GetById(customer.CustomerID);
            if (existing != null)
            {
                existing.CustomerFullName = customer.CustomerFullName;
                existing.EmailAddress = customer.EmailAddress;
                existing.Telephone = customer.Telephone;
                existing.CustomerBirthday = customer.CustomerBirthday;
                existing.CustomerStatus = customer.CustomerStatus;
                existing.Password = customer.Password;
            }
        }

        public static void Delete(int id)
        {
            var c = GetById(id);
            if (c != null)
                customers.Remove(c);
        }
    }
}

