using ChallengeOneCafe.POCO;
using ChallengeOneCafe.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe.UI
{
    class CafeUI
    {
        private readonly CafeREPO _menuItem = new CafeREPO();
        public void Run()
        {
            Seed();
            RunProgram();
        }
        public void RunProgram()
        {
            StartMenu();
        }
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine(
                $"Welcome to the Komodo Cafe Menu App \n" +
                $"***************************** \n" +
                $"Press any key to continue \n" +
                $"*****************************"
                );
            Console.ReadKey();
            MainMenu();
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Please select an option: \n " +
                "**************************\n" + 
                "1: View the full menu \n" + 
                "2: View an item on the menu \n" + 
                "3: Add an item to the menu \n" + 
                "4: Remove item from the menu \n" +
                "5: Update an existing menu item (COMING SOON)\n" +
                "**************************\n" + 
                "99: Exit to Desktop");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewFullMenu();
                    break;
                case "2":
                    ViewMenuItem(); 
                    break;
                case "3":
                    AddMenuItem();
                    break;
                case "4":
                    DeleteMenuItem();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(
                        "The update menu item function is coming soon... \n" +
                        "Press any key to return to the main menu");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case "99":
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(
                        "Please select one of the options \n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        public void ViewFullMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "The current dishes on the menu are: \n" +
                "****************************");

            List<MenuItem> listMenuItems = _menuItem.ViewMenuList();

            foreach (var item in listMenuItems)
            { 
                Console.WriteLine($"{item.MealNumber}: {item.MealName}");
            }
            Console.WriteLine(
                "****************************\n" +
                "Press 1 to View a specific dish | Press 2 to return to Main Menu");
            int mealNumberInput = int.Parse(Console.ReadLine());
            //MenuItem menuItem = _menuItem.ViewMenuItem(mealNumberInput);
            switch (mealNumberInput)
            {
                case 1:
                    ViewMenuItem();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please select an option");
                    break;
            }
        }

        /*public void DisplayFullMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "The current dishes on the menu are: \n" +
                "****************************");

            List<MenuItem> listMenuItems = _menuItem.ViewMenuList();

            foreach (var item in listMenuItems)
            {
                Console.WriteLine($"{item.MealNumber}: {item.MealName}");
            }
            Console.WriteLine(
                "****************************\n" +
                "Press 1 to View a specific dish | Press 2 to return to Main Menu");
            int mealNumberInput = int.Parse(Console.ReadLine());
            //MenuItem menuItem = _menuItem.ViewMenuItem(mealNumberInput);
            switch (mealNumberInput)
            {
                case 1:
                    ViewMenuItem();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please select an option");
                    break;
            }
        }
        */
        public void ViewMenuItem() //getting a menu item by its meal number
        {
            Console.Clear();
            //22DisplayFullMenu();
            Console.WriteLine("Enter a meal item number to view details");
            int mealNumberInput = int.Parse(Console.ReadLine());
            MenuItem menuItem = _menuItem.ViewMenuItem(mealNumberInput);
            Console.Clear();
            Console.WriteLine(
                $"#{menuItem.MealNumber} {menuItem.MealName} \n" +
                $"{menuItem.MealDescription} \n" +
                $"Main Component: {menuItem.MainIngredient} \n" +
                $"Sides: {menuItem.SideIngredients} \n" + //<<<---Not listing correctly. pretty sure i need a loop 
                $"Price: ${menuItem.MealPrice}");
            if (menuItem.IsAvailable == true)
            {
                Console.WriteLine("Available Now!");
            }
            Console.ReadLine();
        }

        public void AddMenuItem()
        {
            //Enter meal name
            //Enter meal description
            //Enter main ingredient
            //Enter side ingredient(s)
            //Enter price
            //IsAvailable
        }
        public void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number you would like to remove");
            int mealNumberToDelete = int.Parse(Console.ReadLine());
            MenuItem menuItemToDelete = _menuItem.DeleteMenuItem(mealNumberToDelete);
            Console.WriteLine($"{menuItemToDelete.MealName} has been successfully removed from the menu.");
            Console.ReadLine();
        }
        public void Seed()
        {
            MenuItem numberOne = new MenuItem(1, "King Burger", "Bacon Cheeseburger with Fries", "Beef", new List<string> { "fries", "pickle" }, 9.99m, true);
            MenuItem numberTwo = new MenuItem(2, "Tendies Basket", "Chicken Tenders with Fries", "Chicken", new List<string> { "fries" }, 7.99m, true);

            _menuItem.CreateMenuItem(numberOne);
            _menuItem.CreateMenuItem(numberTwo);
        }

        //Helper Method that failed
        /*
        public void DisplayItemDetail(int inputToDisplay)
        {
            inputToDisplay = int.Parse(Console.ReadLine());
            MenuItem menuItemToDisplay = _menuItem.ViewMenuItem(inputToDisplay);
            Console.WriteLine($"#test");
        }
        */
    }
}
