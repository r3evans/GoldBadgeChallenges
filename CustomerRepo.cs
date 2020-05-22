using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Email
{   
    public class CustomerRepo   
    {

        private Customer _customer = new Customer();
        private List<Customer> _customerList = new List<Customer>();
      

        public bool AddCustomerToDirectory(Customer customer)
        {
            int startingCount = _customerList.Count;
            _customerList.Add(customer);
            bool wasAdded = _customerList.Count == startingCount + 1;
            return wasAdded;
        }

        public List<Customer> PullCustomers()
        {
            return _customerList;
        }

        public Customer PullCustomerByEmail(string email)
        {
            foreach (Customer customer in _customerList)
                if (customer.Email.ToLower().Contains(email.ToLower()))
                {
                    return customer;
                }
            return null;
        }

        
        public bool UpdateCustomer(string email, Customer updatedInfo)

        {
            Customer customer = PullCustomerByEmail(email);
            if (customer != null)
            {
                customer.FirstName = updatedInfo.FirstName;
                customer.LastName = updatedInfo.LastName;
                customer.Email = updatedInfo.Email;
                customer.PhoneNumber = updatedInfo.PhoneNumber;
                customer.CustomerType = updatedInfo.CustomerType;
                Console.WriteLine($"The customer {customer.FirstName} {customer.LastName} has been updated.");
                return true;
            }
            else
            {
                Console.WriteLine($"There is no customer with the email address {customer.Email}.");
                return false;
            }
           
        }

        public bool RemoveCustomerByEmail(string email)
        {
            Customer customer = PullCustomerByEmail(email);
            if (customer == null)
            {
                Console.WriteLine($"There is no customer with the email {email}.");
                return false;
            }
            else
            {
                _customerList.Remove(customer);
                return true;
            }
        }

    }
}


    
