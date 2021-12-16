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
        private readonly GreenPlanREPO _vehicle = new GreenPlanREPO();
        private bool _isAppRunning = true;
        public void Run()
        {
            while (_isAppRunning)
            {
            Seed();
            RunApplication();
            }
        }
        private void RunApplication()
        {
            StartMenu();
        }
        private void StopApplication()
        {
            _isAppRunning = false;
        }
        private void Seed()
        {
            Vehicle vehicleOne = new Vehicle(VehicleType.Gas, 2022, "Kia", "Telluride", 50.0000m, true, 25, 32, 1);
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
                    ViewVehicleInventoryMenu();
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
        private void ViewVehicleInventoryMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "-----Vehicle Inventory-----\n" +
                "\n" +
                "Select An Option:\n" +
                "-----------------\n" +
                "1 ) View Full Vehicle Inventory\n" +
                "2 ) View Vehicle Inventory by Type\n" +
                "3 ) Search Vehicle Inventory for Specific Vehicle\n" +
                "4 ) Return to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ListFullVehicleInventory();
                    break;
                case "2":
                    ListVehicleByType();
                    break;
                case "3":
                    SearchVehicleById(); 
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void DisplayVehicleInformation(Vehicle display)
        {
            Console.Clear();
            Console.WriteLine(
                $"******************\n" +
                $"{display.Year} {display.Make} {display.Model}\n" +
                $"Estimated {display.HighwayMPG} MPG Highway |\n" +
                $"Estimated {display.CityMPG} MPG City |\n" +
                $"Starting at {display.Price} MSRP\n");
            if (display.HasIncentive == true)
            {
                IncentiveOffer();
            }
            else
            {
            Console.WriteLine(
                    $"******************\n" +
                    $"Press any key to continue");
            Console.ReadKey();
            }
        }
        private List<Vehicle> ListFullVehicleInventory()
        {
            List<Vehicle> vehicles = _vehicle.ViewAllVehicles();

        }
        private void SearchVehicleById()
        {
            
        }
        private void ListVehicleByType()
        {
            throw new NotImplementedException();
        }
        private void AddVehicleToInventory()
        {
            throw new NotImplementedException();
        }
        private void UpdateVehicleInformation()
        {
            throw new NotImplementedException();
        }
        private void RemoveVehicleFromInventory()
        {
            Console.Clear();
            Console.WriteLine(
                "**************\n" +
                "Remove Vehicle\n" +
                "**************\n" +
                " \n" +
                "Select an Option:\n" +
                "1) Remove Vehicle by Id\n" +
                "2) Remove Multiple Vehicles\n" +
                "3) View Vehicle Inventory\n" +
                "4) Return To Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveVehicleById(int.Parse(userInput));
                    break;
                case "2":
                    RemoveMultipleVehicles();
                    break;
                case "3":
                    ListFullVehicleInventory();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void RemoveVehicleById(int vehicleIdToRemove)
        {
            Console.Clear();
            Console.WriteLine("Enter Vehicle ID Number: ");
            int idInput = int.Parse(Console.ReadLine());
            Vehicle vehicleToRemove = new Vehicle();
            if (vehicleToRemove.IdNumber == idInput)
            {
                _vehicle.RemoveVehicle(vehicleToRemove);
                if (vehicleToRemove is null)
                {
                    Console.Clear();
                    Console.WriteLine($"{vehicleToRemove.Model} was not removed from the inventory");
                }
                else if (_vehicle.Contains(vehicleToRemove))
                {
                Console.Clear();
                    Console.WriteLine($"{vehicleToRemove.Model} was removed from the inventory.\n" +
                        $"--------------------------------------------\n" +
                        $"Press any key for Remove Vehicle Menu");

                    Console.ReadKey();
                    RemoveVehicleFromInventory();
                }
                else
                {
                    Console.WriteLine("How did you break it this bad to get here?");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fission Mailed | Press any key to return to the Remove Vehicle Menu");
                Console.ReadKey();
                RemoveVehicleFromInventory();
            }
        }
        private void RemoveMultipleVehicles()
        {
            throw new NotImplementedException();
        }
        private void IncentiveOffer()
        {
            Console.WriteLine(
                "This vehicle has a special offer!\n" +
                "*********************************\n" +
                "Press any key to continue!");
            Console.ReadKey();
        }
        private void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine(
                "Please Select A Menu Option\n" +
                "Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }





    }
}
