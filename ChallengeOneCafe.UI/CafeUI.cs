using ChallengeOneCafe.POCO;
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
        // Start Menu, Main Menu
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
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Please select an option: " +
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
                    ViewMenu();
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
                    Console.WriteLine("The update menu item function is coming soon...");
                    break;
                case "6":
                    //Leave the program
                default:
                    Console.WriteLine("Please select one of the options");
                    break;
            }
            private void AddMenuItem()
            {

            }
        }
    }
}
