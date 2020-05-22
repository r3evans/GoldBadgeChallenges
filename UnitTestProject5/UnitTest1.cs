using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject5
{
    [TestClass]
    public class UnitTest1
    {
        private CompanyOutingRepo _companyOutingRepo = new CompanyOutingRepo();
        private List<CompanyOuting> _companyOutings = new List<CompanyOuting>();
   

        [TestInitialize]
        public void SeedTest()
        {
            CompanyOuting outing = new CompanyOuting(EventType.AmusementPark, 4, "April 30", 4.00);
            _companyOutingRepo.AddCompOuting(outing);
            CompanyOuting outing1 = new CompanyOuting(EventType.Bowling, 3, "April 10", 4.00);
            _companyOutingRepo.AddCompOuting(outing1);
        }

        [TestMethod]
        public void AddOutingToRepoShouldIncreaseCountBy()
        {
            CompanyOuting outing = new CompanyOuting();
            bool actual = _companyOutingRepo.AddCompOuting(outing);
            Assert.IsTrue(actual);
        }

       [TestMethod]
       public void SumAllOutingsShouldUpdateOutingTotal()
        {
            // test that the number of outings is greater than the original number after adding an outing or an attendee

            List<CompanyOuting> outingList = new List<CompanyOuting>();
            CompanyOuting outing = new CompanyOuting();

            double actual = _companyOutingRepo.SumAllOutings(outing);
            double expected = outingList.Sum();
            Assert.AreNotEqual(expected,actual);

        }

        [TestMethod]

        public void SumAllOutingsShouldIncreaseTotalEventsCost()
        {

        }
       

       
    }
}
