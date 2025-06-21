using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int id, string name, string email, string phone, DateTime birthday, int status, string password)
        {
            CustomerID = id;
            CustomerFullName = name;
            EmailAddress = email;
            Telephone = phone;
            CustomerBirthday = birthday;
            CustomerStatus = status;
            Password = password;
        }

        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public int CustomerStatus { get; set; } // 1 = Active, 2 = Deleted
        public string Password { get; set; }
    }

}
