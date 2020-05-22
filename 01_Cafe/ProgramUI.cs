using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class ProgramUI
    {
        private Menu_Repo _menuRepo = new Menu_Repo();

        public void Run()
        {
            SeedMenuItemList();
            Menu();

        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Pick a menu option:\n" +
                    "1. New Menu Item\n" +
                    "2. View All Content\n" +
                    "3. Get Item By Number\n" +
                    "4. Update Menu Item\n" +
                    "5. Delete Menu Item\n" +
                    "6. Exit");

                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "New Menu Item":
                    case "new":
                    case "new item":
                        AddItemToList();
                        break;
                    case "2":
                    case "View All":
                    case "view":
                        GetItemList();
                        Console.WriteLine(_menuRepo);
                        Thread.Sleep(1000);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "3":
                    case "Item Number":
                        GetItemByNumber();
                        break;
                    case "4":
                    case "Update":
                    case "update":
                        UpdateExistingItem();
                        break;
                    case "5":
                    case "Delete":
                    case "delete":
                        DeleteItemFromList();
                        Console.Clear();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "6":
                    case "Exit":
                        keepRunning = false;
                        Console.WriteLine("Thanks for visiting the Komodo Cafe App.");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Please enter the number or type the first word of your option.");
                        break;
                }

                Console.WriteLine("Please press any keep to continue");
                Console.ReadKey();

                Console.Clear();
            }
        }




        private void AddItemToList()
        {
            MenuItem meal = new MenuItem();

            Console.Clear();

            Console.WriteLine("Enter an item name");
            meal.MealName = Console.ReadLine();

            Console.WriteLine("Enter an item number");
            meal.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter an item Description");
            meal.Description = Console.ReadLine();

            Console.WriteLine("Enter a description");
            meal.Description = Console.ReadLine();

            Console.WriteLine("Enter a price");
            meal.Price = Convert.ToDouble(Console.ReadLine());
            _menuRepo.AddItemToList(meal);

            Console.WriteLine("Press any key to continue");
        }

        private void GetItemList()
        {
            List<MenuItem> listOfMenuItems = _menuRepo.GetItemList();
            foreach (MenuItem item in listOfMenuItems)
            {

                Console.Clear();
                Console.WriteLine($"{item.MealName}\n" +
                    $" Name: {item.MealName}\n" +
                    $" Description: {item.Description}\n" +
                    $" Price {item.Price}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private void UpdateExistingItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter an item number you would like to see:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            MenuItem meal = _menuRepo.GetItemByNumber(mealNumber);
            if (meal != null)
            {
                Console.WriteLine($"{meal.MealNumber}\n" +
                    $"Name: {meal.MealName}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Description: {meal.Ingredients}\n" +
                    $"Price {meal.Price}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There is no meal with that item number.");
            }
        }

        private void GetItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("");
            int input = Convert.ToInt32(Console.ReadLine());
            MenuItem newItem = _menuRepo.GetItemByNumber(input);
            Console.WriteLine($"{newItem.MealName}\n" +
            $"Name: {newItem.MealName}\n" +
            $"Description: {newItem.Description}\n" +
            $"Price {newItem.Price}");
            Console.ReadKey();
        }

        private void DeleteItemFromList()
        {
            Console.WriteLine("What is the item number that you want to delete?");
            GetItemList();
            int input = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted = _menuRepo.DeleteItemFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was deleted");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted");
            }

        }

        private void SeedMenuItemList()
        {
            MenuItem applePie = new MenuItem(2, "apple pie", "tasty and warm", "apples, crust,butter", 4.00);
            _menuRepo.AddItemToList(applePie);
        }
    }

}
