using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe.POCO
{
    public class MenuItem
    {
        //Empty
        public MenuItem() { }
        //Hard Code Entry
        public MenuItem(int mealNumber, string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, decimal mealPrice, bool isAvailable)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MainIngredient = mainIngredient;
            SideIngredients = sideIngredients;
            MealPrice = mealPrice;
            IsAvailable = isAvailable;
        }
        //Use function to assign meal number
        public MenuItem(string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, decimal mealPrice, bool isAvailable)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MainIngredient = mainIngredient;
            SideIngredients = sideIngredients;
            MealPrice = mealPrice;
            IsAvailable = isAvailable;
        }
        //Use function to assign meal number and leave the mealPrice null? (blank to where price could be added later)
        public MenuItem(string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, bool isAvailable)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MainIngredient = mainIngredient;
            SideIngredients = sideIngredients;
            IsAvailable = isAvailable;
        }
        //Use function to assign meal number for an item coming soon
        public MenuItem(string mealName, string mealDescription, string mainIngredient, bool isAvailable)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MainIngredient = mainIngredient;
            IsAvailable = isAvailable;
        }
        //Use function to assign meal number and only enter the name (Could be for like an idea for a menu item in early concept)
        public MenuItem(string mealName, bool isAvailable)
        {
            MealName = mealName;
            IsAvailable = isAvailable;
        }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MainIngredient { get; set; }
        public List<string> SideIngredients { get; set; }
        public decimal MealPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
