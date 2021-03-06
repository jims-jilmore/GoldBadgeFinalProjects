using ChallengeOneCafe.POCO;
using ChallengeOneCafe.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeOneCafe.UI
{
    class CafeUI
    {
        private readonly CafeREPO _menuItem = new CafeREPO();
        private bool isRunning = true;
        public void Run()
        {
            Seed();
            while (isRunning)
            {
                RunProgram();
            }
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
                    isRunning = false;
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(5000);
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
            switch (mealNumberInput)
            {
                case 1:
                    DisplayFullMenu();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please select an option");
                    break;
            }
        }
        public void DisplayFullMenu()
        {
            ListDishes();
            Console.WriteLine(
                "****************************\n" +
                "Enter the Meal Number to see details on a menu item");
            int mealNumberInput = int.Parse(Console.ReadLine());
            MenuItem menuItem = _menuItem.ViewMenuItem(mealNumberInput);
            DisplayItemDetail(menuItem);
        }
        public void ViewMenuItem()
        {
            Console.Clear();
            DisplayFullMenu();
            Console.WriteLine("Enter a meal item number to view details");
            int mealNumberInput = int.Parse(Console.ReadLine());
            MenuItem menuItem = _menuItem.ViewMenuItem(mealNumberInput);
            DisplayItemDetail(menuItem);
        }
        public void AddMenuItem()
        {
            MenuItem newMenuItem = new MenuItem();
            Console.Clear();
            Console.WriteLine("Enter the Name of the Meal");
            newMenuItem.MealName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter a short description of the Meal");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.Clear();
            Console.WriteLine(
                "Enter the Main Ingredient of the Meal\n" +
                "Ex: Beef, Chicken, Pork");
            newMenuItem.MainIngredient = Console.ReadLine();

            Console.Clear();
            List<string> sides = new List<string>();
            Console.WriteLine("Enter The First Side");
            string side = Console.ReadLine();
            sides.Add(side);
            Console.WriteLine("Add Another Side? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            while (userInput == "y")
            {
                Console.Clear();
                Console.WriteLine("Enter Your Next Side");
                string nextside = Console.ReadLine();
                sides.Add(nextside);
                Console.WriteLine("Add Another Side? (y/n)");
                userInput = Console.ReadLine().ToLower();
            }
            newMenuItem.SideIngredients = sides;

            Console.Clear();
            Console.WriteLine("Enter the price of the Meal");
            newMenuItem.MealPrice = Decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Is the Meal available now? (y/n)");
            string availableInput = Console.ReadLine().ToLower();
            switch (availableInput)
            {
                case "y":
                    newMenuItem.IsAvailable = true;
                    break;
                case "n":
                    newMenuItem.IsAvailable = false;
                    break;
                default:
                    Console.WriteLine("Please select y or n");
                    break;
            }

            Console.Clear();
            if (_menuItem.CreateMenuItem(newMenuItem) == true)
            {
                Console.WriteLine($"{newMenuItem.MealName} was successfully added to the menu.\n" +
                    $"Press any key to return to Main Menu");
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine($"ERROR \n" +
                    $"{newMenuItem.MealName} was not added to the menu \n" +
                    $"Press any key to return to Main Menu");
                Console.ReadKey();
                MainMenu();
            }
        }
        public void DeleteMenuItem()
        {
            ListDishes();
            Console.WriteLine($"*****************************\n" +
                $"Enter the Meal Number you would like to remove");
            int mealNumberToDelete = int.Parse(Console.ReadLine());
            MenuItem menuItemToDelete = _menuItem.DeleteMenuItem(mealNumberToDelete);
            Console.Clear();
            Console.WriteLine($"{menuItemToDelete.MealName} has been successfully removed from the menu. \n" +
                $"**************************\n" +
                $"Press any key to return to Main Menu");
            Console.ReadKey();
            MainMenu();
        }
        public void Seed()
        {
            MenuItem numberOne = new MenuItem(1, "King Burger", "Bacon Cheeseburger with Fries", "Beef", new List<string> { "fries", "pickle" }, 9.99m, true);
            MenuItem numberTwo = new MenuItem(2, "Tendies Basket", "Chicken Tenders with Fries", "Chicken", new List<string> { "fries" }, 7.99m, true);

            _menuItem.CreateMenuItem(numberOne);
            _menuItem.CreateMenuItem(numberTwo);
        }
        public void DisplayItemDetail(MenuItem menuItem)
        {
            List<string> sides = _menuItem.ListAllSides(menuItem);
            Console.Clear();
            Console.WriteLine(
                 $"#{menuItem.MealNumber} {menuItem.MealName} \n" +
                 $"{menuItem.MealDescription} \n" +
                 $"Main Component: {menuItem.MainIngredient}");
            foreach (var side in sides)
            {
                Console.WriteLine($"Side: {side}");
            }
            Console.WriteLine($"Price: ${menuItem.MealPrice}");
            if (menuItem.IsAvailable == true)
            {
                Console.WriteLine("Available Now!");
            }
            Console.WriteLine(
                "**************************\n" +
                "Press any key to return to Main Menu");
            Console.ReadKey();
            MainMenu();
        }
        public void ListDishes()
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
        }
    }
}