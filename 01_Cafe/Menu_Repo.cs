using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{

    public class Menu_Repo
    {
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();
        //create
        public void AddItemToList(MenuItem item)
        {
            _listOfMenuItems.Add(item);
        }
        //read
        public List<MenuItem> GetItemList()
        {
            return _listOfMenuItems;
        }
        //update
        public bool UpdateExistingItem(int originalMenuItemNum, MenuItem newItem)

        {
            MenuItem oldItem = GetItemByNumber(originalMenuItemNum);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool DeleteItemFromList(int itemNumber)
        {
            MenuItem item = GetItemByNumber(itemNumber);
            if (item == null)
            {
                return false;
            }
            int intitialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);
            if (intitialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MenuItem GetItemByNumber(int mealNumber)
        {
            foreach (MenuItem item in _listOfMenuItems)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
    }

}
