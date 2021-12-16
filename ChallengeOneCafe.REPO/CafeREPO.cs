using ChallengeOneCafe.POCO;
using System.Collections.Generic;

namespace ChallengeOneCafe.REPO
{
    public class CafeREPO
    {
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();
    
        private int menuNumberCounter = 0;
        
        public bool CreateMenuItem(MenuItem menuItemToCreate)
        {
            if (menuItemToCreate is null)
            {
                return false;
            }
            menuNumberCounter++;
            menuItemToCreate.MealNumber = menuNumberCounter;
            _menuItem.Add(menuItemToCreate);
            return true;
        }
        public bool CreateSideItem(MenuItem sideItemToCreate)
        {
            if (sideItemToCreate is null)
            {
                return false;
            }
            _menuItem.Add(sideItemToCreate);
            return true;
            
        }
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
            }
            return null;
        }
        public MenuItem DeleteMenuItem(int menuItemToDelete)
        {
            foreach (MenuItem menuItem in _menuItem)
            {
                if (menuItem.MealNumber == menuItemToDelete)
                {
                    _menuItem.Remove(menuItem);
                    return menuItem;
                }
            }
            return null;
        }
    }
}
