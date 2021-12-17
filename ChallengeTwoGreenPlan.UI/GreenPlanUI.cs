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
            _isAppRunning = false; //Longer than one line probably doesn't need a method
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
                    DisplayVehicleInventory();
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
        private void DisplayVehicleInformation(Vehicle vehicle)
        {
            List<Vehicle> vehiclesToList = _vehicle.ViewAllVehicles();
            Console.Clear();
            foreach (var vehicleToList in vehiclesToList)
            {
                Console.WriteLine(
               $"******************\n" +
               $"{vehicleToList.Year} {vehicleToList.Make} {vehicleToList.Model}\n" +
               $"Estimated {vehicleToList.HighwayMPG} MPG Highway |\n" +
               $"Estimated {vehicleToList.CityMPG} MPG City |\n" +
               $"Starting at {vehicleToList.Price} MSRP\n");

                if (vehicleToList.HasIncentive == true)
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
        }
        public void DisplayVehicleInventory()
        {
            List<Vehicle> VehicleInventory = _vehicle.ViewAllVehicles();
            Console.Clear();
            Console.WriteLine(
                    "|||||Vehicle Inventory|||||\n" +
                    "***************************");
            foreach (var vehicle in VehicleInventory)
            {
                Console.WriteLine($"{vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine("TestTestTest");
            Console.ReadLine();
        }
        private void SearchVehicleById()
        {
            throw new NotImplementedException();
        } // Not Built: Not req'd
        private void ListVehicleByType()
        {
            Console.Clear();
            Console.WriteLine(
                "Select An Option\n" +
                "****************\n" +
                "1) Gas\n" +
                "2) Electric\n" +
                "3) Hybrid\n" +
                "4) Return To Main Menu\n" +
                "****************");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ListGasVehicles();
                    break;  
                case "2":
                    ListElectricVehicles();
                    break;
                case "3":
                    ListHybridVehicles();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }

        private void ListGasVehicles()
        {
            throw new NotImplementedException();
        }
        private void ListElectricVehicles()
        {
            throw new NotImplementedException();
        } // Not Built
        private void ListHybridVehicles()
        {
            throw new NotImplementedException();
        } // Not Built
        private void AddVehicleToInventory()
        {
            throw new NotImplementedException();
        } // Not Built
        private void UpdateVehicleInformation()
        {
            throw new NotImplementedException();
        } // Not Built
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
                    DisplayVehicleInventory();
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
                _vehicle.RemoveVehicle(idInput);
                if (vehicleToRemove is null)
                {
                    Console.Clear();
                    Console.WriteLine($"{vehicleToRemove.Model} was not removed from the inventory");
                }
                else if (_vehicle.WasVehicleRemoved(vehicleToRemove, idInput)) 
                {
                    Console.Clear();
                    Console.WriteLine("did this work");
                    Console.ReadKey();
                }
                Console.Clear();
                    Console.WriteLine($"{vehicleToRemove.Model} was removed from the inventory.\n" +
                        $"--------------------------------------------\n" +
                        $"Press any key for Remove Vehicle Menu");

                    Console.ReadKey();
                    RemoveVehicleFromInventory();
               
            }
        }
        private void RemoveMultipleVehicles()
        {
            throw new NotImplementedException();
        } // Not Built
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
