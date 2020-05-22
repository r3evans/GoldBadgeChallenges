using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Email
{
    public class ProgramUI
    {
        private CustomerRepo _customerRepo = new CustomerRepo();
        private Customer _customer = new Customer();

        public void Run()
        {
            SeedCustomerForEmail();
            Menu();
        }

        private void Menu()

        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Pick an menu option:\n" +
                    "1. Send email to Customers:\n" +
                    "2. Create New Customer\n" +
                    "3. Update Customer Info\n" +
                    "4. Read Customer Info\n" +
                    "5. Delete Customer\n" +
                    "6. View Customer List\n" +
                    "7. Exit");

                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        GetCustomerList();
                        SendEmailToCustomer();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        AddNewCustomer();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        UpdateCustomer();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        GetCustomerByEmail();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        DeleteCustomer();
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        GetCustomerList();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter the number of your option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeedCustomerForEmail()
        {
            Customer willie = new Customer("Willy", "Bartone", "willyBartone@gmail.com", "3172334455", CustomerType.current);
            _customerRepo.AddCustomerToDirectory(willie);
            Customer jakey = new Customer("Jacob", "Bartone", "jacobBartone@gmail.com", "3174533242", CustomerType.past);
            _customerRepo.AddCustomerToDirectory(jakey);
            Customer tone = new Customer("Tony", "Bartone", "tony.bartone@gmail.com", "443332223", CustomerType.potential);
            _customerRepo.AddCustomerToDirectory(tone);
        }

        private void GetCustomerList()
        {
            List<Customer> customerList = _customerRepo.PullCustomers();
            var sortedCustomerList = customerList.OrderBy(a => a.LastName).ToList();
            foreach (Customer customer in sortedCustomerList)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}\n" +
                    $"Email: {customer.Email}\n" +
                    $"Customer Type: {customer.CustomerType}");
            }
        }

        private void SendEmailToCustomer()
        {

            List<Customer> customerList = _customerRepo.PullCustomers();
            Console.WriteLine("Customer's will receive the folling emails");
            foreach (Customer customer in customerList)
                if (
                    customer.CustomerType == CustomerType.current)
                {
                    Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here is a coupon.");
                }
                else if (customer.CustomerType == CustomerType.past)
                {
                    Console.WriteLine("It's been a long time since we've heard from you. We want you back>");
                }
                else
                {
                    Console.WriteLine("We currently have the lowest rates on helicopter insurance!");
                }
            Console.WriteLine("Press any key to return to the Main Menu");


        }

        private void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Please enter a customer email you would like to update:");
            string customerEmail = Console.ReadLine();
            Customer customer = _customerRepo.PullCustomerByEmail(customerEmail);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName}\n" +
                    $"Name: {customer.LastName}\n" +
                    $"Description: {customer.Email}\n" +
                    $"Description: {customer.CustomerType}\n");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("What is the customer's new First Name?");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("What is the customer's  new Last Name?");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("What is the  new email address of the customer?");
                customer.Email = Console.ReadLine();
                Console.WriteLine("What is the customer's new phone number");
                customer.PhoneNumber = Console.ReadLine();
                Console.WriteLine($"What type of customer will {customer.FirstName} now be? :\n" +
                    "1. Current\n" +
                    "2. Past\n" +
                    "3. Potential");
                string typeAsSTring = Console.ReadLine();
                int typeASInt = int.Parse(typeAsSTring);
                customer.CustomerType = (CustomerType)typeASInt;

                bool wasUpdated = _customerRepo.UpdateCustomer(customerEmail, customer);
                Console.WriteLine("Press any key to return to the Main Menu");
                if (wasUpdated)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Could not update customer {customer.FirstName} {customer.LastName}.");
                }
            }


        }

        private void AddNewCustomer()
        {
            Console.Clear();
            Customer customer = new Customer();
            Console.Clear();
            Console.WriteLine("What is the customer's First Name?");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("What is the customer's Last Name?");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("What is the email address of the customer?");
            customer.Email = Console.ReadLine();
            Console.WriteLine("What is the customer's phone number");
            customer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("What type of customer is this:\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            _customerRepo.AddCustomerToDirectory(customer);
            
            string typeAsString = Console.ReadLine();
            int typeASInt = int.Parse(typeAsString);
            customer.CustomerType = (CustomerType)typeASInt;
            Console.WriteLine("Press any key to return to the Main Menu");
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("What is the email address  of the customer that you want to delete?");
            GetCustomerList();
            string customer = Console.ReadLine();
            bool wasDeleted = _customerRepo.RemoveCustomerByEmail(customer);
            if (wasDeleted)
            {
                Console.WriteLine($"The customer {_customer.FirstName}{_customer.LastName} has been deleted.");
            }
            else
            {
                Console.WriteLine("There is no customer with that email address");
            }
            Console.WriteLine("Press any key to return to the Main Menu");
        }

        private void GetCustomerByEmail()
        {
            Console.Clear();
            Console.WriteLine("What email address are you looking for?");
            string email = Console.ReadLine();
            Customer customer = _customerRepo.PullCustomerByEmail(email);
            if (customer.Email != null)
            {
                Console.WriteLine($"{customer.Email}\n" +
            $"Name: {customer.FirstName}{customer.LastName} \n" +
            $"Customer Type: {customer.CustomerType}");
            }
            else
            {
                Console.WriteLine($"There is no customer with the email{customer.Email}.");
            }

            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
        }

    }
}
