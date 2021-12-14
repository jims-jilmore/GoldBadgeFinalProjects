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
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();
        public void Run()
        {
            RunProgram();
        }
        public void RunProgram()
        {
            StartMenu();
            // This is where you could seed your fake database 
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
            Console.WriteLine("The current dishes on the menu are: ");
            foreach (var menuItem in _menuItem)
            {
                Console.WriteLine(menuItem); //definitely not sure if this is right
            }
            /*
            Console.WriteLine("Would you like to view a specific menu item? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    ViewMenuItem();
                    break;
                case "n":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine(
                        "Enter Y to return view a specific menu item \n" +
                        "Enter N to return to the main menu");
                    break;
            }
            */
        }
        public void ViewMenuItem()
        {
            
        }
        public void AddMenuItem()
        {

        }
        public void DeleteMenuItem()
        {

        }
    }
}
