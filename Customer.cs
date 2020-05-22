using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public enum CustomerType { current = 1, past, potential }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public CustomerType CustomerType { get; set; }

        public Customer
        ()
        {
            
        }

        public Customer(string firstName, string lastName, string email, string phoneNumber, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CustomerType = customerType;
        }
    }
}
