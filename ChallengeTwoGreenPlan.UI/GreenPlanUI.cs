using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoGreenPlan.REPO;
using ChallengeTwoGreenPlan.POCO;

namespace ChallengeTwoGreenPlan.UI
{
    class GreenPlanUI
    {
        private readonly List<Vehicle> _vehicle = new List<Vehicle>();
        public void Run()
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
            RunApplication();
            }
        }
        private void RunApplication()
        {
            Seed();
            StartMenu();
        }
        private void StopApplication()
        {
            Environment.Exit(0);
        }// <<<---May not be the correct way of stopping application 
        private void Seed()
        {
            // I'll create this later
        }
        private void StartMenu()
        {
            Console.WriteLine(
                "|||||Welcome to the GreenPlan Corp||||| \n" +
                "--------------------------------------- \n" +
                "Press any key to enter the Main Menu \n");
            Console.ReadKey();
            MainMenu();
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "|||||GreenPlan Corporation|||||\n" +
                "-------------------------------\n" +
                " \n" +
                "Select A Menu Option:\n" +
                "*********************\n" +
                "1: View Vehicle Inventory\n" +
                "2: Add a Vehicle(s)\n" +
                "3: Update Vehicle Information\n" +
                "4: Remove Vehicle(s)\n" +
                "5: Exit Application\n" +
                "-------------------------------");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewVehicleInventory();
                    break;
                case "2":
                    AddVehicleToInventory();
                    break;
                case "3":
                    UpdateVehicleInformation();
                    break;
                case "4":
                    RemoveVehicleFromInventory();
                    break;
                case "5":
                    StopApplication();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void RemoveVehicleFromInventory()
        {
            throw new NotImplementedException();
        }
        private void UpdateVehicleInformation()
        {
            throw new NotImplementedException();
        }
        private void AddVehicleToInventory()
        {
            throw new NotImplementedException();
        }
        private void ViewVehicleInventory()
        {
            throw new NotImplementedException();
        }
        private void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("Please Select A Menu Option\n" +
                "Press any key to continue");
            Console.ReadKey(); // <<<---Look at how to make windows popouts for the error message
        }
    }
}
