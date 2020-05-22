using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_UnitTestProject5
{
    [TestClass]
    public class UnitTest1
    {
        private MenuItem _meal = new MenuItem();
        private Menu_Repo _menuRepo = new Menu_Repo();
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();



        [TestInitialize]

        public void SeedMenuItemList()
        {
            MenuItem applePie = new MenuItem(2, "apple pie", "tasty and warm", "apples, crust,butter", 4.00);
            _listOfMenuItems.Add(applePie);
            MenuItem cake = new MenuItem(3, "cake", "for birthdays", "flour, sugar, eggs,", 5.00);
            _listOfMenuItems.Add(cake);
        }

        [TestMethod]
        public void DeleteContentShouldReduceCount()
        {
            _menuRepo.DeleteItemFromList(2);
            int expected = 1;
            int actual = _listOfMenuItems.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItemToListShouldIncreaseCount()
        {
            int expected = 2;
            int actual = _listOfMenuItems.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowAllContentsShouldCountItemsEqualToList()
        {
            int expected = 2;
            int actual = _listOfMenuItems.Count;
            Assert.AreEqual(expected, actual);
        }


    }
}

