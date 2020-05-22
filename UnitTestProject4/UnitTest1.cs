using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Reflection;
using Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject4
{
    [TestClass]
    public class EmailUnitTests
    {

        private CustomerRepo _customerRepo = new CustomerRepo();
        private List<Customer> _customerList = new List<Customer>();

        [TestInitialize]

        public void SeedRepo()
        {
            Customer jake = new Customer("Jake", "Smith", "jake.smith@gmail.com", "317 - 233 - 9845", CustomerType.potential);
            _customerRepo.AddCustomerToDirectory(jake);
            Customer james = new Customer("James", "Smith", "james.smith@gmail.com", "317 - 234 - 9845", CustomerType.current);
            _customerRepo.AddCustomerToDirectory(james);
            Customer jane = new Customer("Jane", "Smith", "jane.smith@gmail.com", "317 - 235 - 9845", CustomerType.past);
            _customerRepo.AddCustomerToDirectory(jane);
        }

        [TestMethod]
        public void AddCustomerToDirectoryShouldIncreaseCustomerListCount()
        {
            int expected = 3;
            int actual = _customerRepo.PullCustomers().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void PullCustomers()
        {
            Customer lesley = new Customer("Lesley", "Bartone", "lesleybartone@gmail.com", "317 - 345 - 5432", CustomerType.current);
            _customerRepo.AddCustomerToDirectory(lesley);
            Customer testContent = _customerRepo.PullCustomerByEmail("lesleybartone@gmail.com");
            Assert.AreEqual(lesley, testContent);
        }

        [TestMethod]

        public void RemoveCustomerByEmailShouldReduceList()
        {
            _customerRepo.RemoveCustomerByEmail("lesleybartone@gmail.com");
            int expected = 3;
            int actual = _customerRepo.PullCustomers().Count;
            Assert.AreEqual(expected, actual);
        }

        public void UpdateCustomerInfoShouldReturnEvenListNumber()
        {
            Customer updateInfo = new Customer("Michael", "Smith", "jake.smith@gmail.com", "317-444-8433", CustomerType.past);
            _customerRepo.UpdateCustomer("Jake", updateInfo);
            CustomerType expected = CustomerType.past;
            
        }




    }
}