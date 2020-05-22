using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class ProgramUI
    {
        private CompanyOutingRepo _companyOutingRepo = new CompanyOutingRepo();
        private CompanyOuting _companyOutings = new CompanyOuting();
        private CompanyOuting _outing = new CompanyOuting();
        public void Run()
        {
            SeedCompanyOutings();
            Menu();
        }



        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Pick an menu option:\n" +
                    "1. Display All Outings:\n" +
                    "2. Display Outings by Type\n" +
                    "3. Add Outing\n" +
                    "4. Exit");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        DisplayAllOutings();
                        Console.ReadKey();
                        break;
                    case "2":
                        DisplayOutingsByType();
                        Console.WriteLine(_companyOutings);
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        AddOuting();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(2000);
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter the number of your option.");
                        Console.ReadKey();
                        break;
                }
            }

        }
        private void SeedCompanyOutings()
        {
            CompanyOuting outing = new CompanyOuting(EventType.AmusementPark, 4, "April 30", 4.00);
            _companyOutingRepo.AddCompOuting(outing);
            CompanyOuting outing1 = new CompanyOuting(EventType.Bowling, 3, "April 10", 4.00);
            _companyOutingRepo.AddCompOuting(outing1);
        }
        private List<CompanyOuting> DisplayAllOutings()
        {
            DisplayAllOutings();
        }

        private void AddOuting()
        {
            Console.Clear();
            CompanyOuting outing = new CompanyOuting();
            Console.WriteLine("What is the Date of the event?");
            outing.EventDate = Console.ReadLine();
            Console.WriteLine("How many people are attending?");
            outing.AttendeeTotal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the price of the event per person?");
            outing.Cost = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What type of Event is this:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Conert");
            string typeAsSTring = Console.ReadLine();
            int typeASInt = int.Parse(typeAsSTring);
            outing.EventType = (EventType)typeASInt;
            _companyOutingRepo.AddCompOuting(outing);
            Console.WriteLine("Press any key to return to the Main Menu");
        }

        private CompanyOuting DisplayOutingsByType(EventType eventType)
        {
                foreach(CompanyOuting outing in _companyOutings)
                {
                    if (outing.EventType == eventType)
                    {
                        return outing;
                    }
                }
                return null;
        }
    }
}
