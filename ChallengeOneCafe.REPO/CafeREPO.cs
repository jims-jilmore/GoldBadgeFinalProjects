using ChallengeOneCafe.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe.REPO
{
    public class CafeREPO
    {
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();
        // Create Menu Items, Delete Menu Items, Display Menu Items, Display Menu Item Ingredients
        private int menuNumberCounter = 0;
        // Create Menu Items
        public bool CreateMenuItem(MenuItem menuItem)
        {
            if (menuItem is null)
            {
                return false;
            }
            menuNumberCounter++;
            menuItem.MealNumber = menuNumberCounter;
            _menuItem.Add(menuItem);
            return true;
        }
        // Update (not req'd)
        
        // Read (View the menu items on their own or as a full menu and view the ingredients)
        public List<MenuItem> ViewMenuList()
        {
            return _menuItem;
        }
        public MenuItem ViewMenuItem(int mealNumber)
        {
            foreach (var menuItem in _menuItem)
            {
                if (mealNumber == menuItem.MealNumber)
                {
                    return menuItem;
                }
                else
                {
                    return null; // some other condition. Kinda lost in the return type here
                }
            }
            //Think about looking in to _menuItems and how you want to pull a specific menu item. 
        }

        // Delete (Delete single menu item or multiple)
        public void DeleteMenuItem() //return a bool? 
        {

        }
        public void DeleteMultipleMenuItems() //return a bool?
        {

        }
    }
}
