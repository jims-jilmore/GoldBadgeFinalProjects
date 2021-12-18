using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoGreenPlan.REPO;
using ChallengeTwoGreenPlan.POCO;
using System.Threading;

namespace ChallengeTwoGreenPlan.UI
{
    class GreenPlanUI
    {
        private readonly GreenPlanREPO _vehicle = new GreenPlanREPO();
        private bool _isAppRunning = true;
        public void Seed()
        {
            Vehicle vehicleOne = new Vehicle(VehicleType.Gas, "2022", "Kia", "Telluride", 50.0000m, true, 25, 32, 1);
            Vehicle vehicleTwo = new Vehicle("2022", "Tesla", "Model X");
            Vehicle vehicleThree = new Vehicle("2022", "Ford", "F-150 Raptor");
            _vehicle.CreateVehicle(vehicleOne);
            _vehicle.CreateVehicle(vehicleTwo);
            _vehicle.CreateVehicle(vehicleThree);

        }
        public void Run()
        {
            Seed();
            while (_isAppRunning)
            {
            RunApplication();
            }
        }
        private void RunApplication()
        {
            StartMenu();
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
                    GoodbyePage();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void GoodbyePage()
        {
            _isAppRunning = false;
            Console.Clear();
            Console.WriteLine("Goodbye");
            Thread.Sleep(5000);
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
        private void DisplayVehicleDetail(Vehicle vehicle)
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
            Console.Clear();
            Console.WriteLine(
                    "|||||Vehicle Inventory|||||\n" +
                    "***************************");

            List<Vehicle> vehicleInventory = _vehicle.ViewAllVehicles();

            foreach (Vehicle vehicle in vehicleInventory)
            {
                Console.WriteLine($"{vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine("***************************\n" +
                "Enter Vehicle ID To View Details | Press 2 To Return To Main Menu");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Vehicle vehicleToDisplay = _vehicle.ViewVehicleById(userInput);
                    DisplayVehicleDetail(vehicleToDisplay);
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
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
            Console.Clear();
            Console.WriteLine(
                "********************\n" +
                "Add Vehicle To Inventory\n" +
                "********************\n" +
                "1) Add A Single Vehicle\n" +
                "2) Add Multiple Vehicles (Coming Soon)\n" +
                "3) Return To Main Menu");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    AddVehicle();
                    break;
                case 2:
                    //AddMultipleVehicles();
                    break;
                case 3:
                    MainMenu();
                    break;
            }


        } // Not Built
        private void AddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            Console.Clear();
            Console.WriteLine(
                "Select Vehicle Type:\n" +
                "1) Gas\n" +
                "2) Electric\n" +
                "3) Hybrid");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    vehicleToAdd.VehicleType = VehicleType.Gas;
                    break;
                case "2":
                    vehicleToAdd.VehicleType = VehicleType.Electric;
                    break;
                case "3":
                    vehicleToAdd.VehicleType = VehicleType.Hybrid;
                    break;
                default:
                    ErrorMessage();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Enter The Year Of The Vehicle");
            vehicleToAdd.Year = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Make Of The Vehicle");
            vehicleToAdd.Make = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Model Of The Vehicle");
            vehicleToAdd.Model = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Price Of The Vehicle");
            vehicleToAdd.Price = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Does The Vehicle Have An Incentive (y/n)");
            string incentiveInput = Console.ReadLine().ToLower();
            switch (incentiveInput)
            {
                case "y":
                    vehicleToAdd.HasIncentive = true;
                    break;
                case "n":
                    vehicleToAdd.HasIncentive = false;
                    break;
                default:
                    ErrorMessage();
                    break;
            }

            Console.Clear();
            Console.WriteLine("Enter The Vehicles Estimated City MPG");
            vehicleToAdd.CityMPG = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter The Vehicle's Estimated Highway MPG");
            vehicleToAdd.HighwayMPG = int.Parse(Console.ReadLine());

            Console.Clear();
            if (_vehicle.CreateVehicle(vehicleToAdd) == true)
            {
                Console.WriteLine(
                    $"{vehicleToAdd.Make} {vehicleToAdd.Model}\n" +
                    $"Was Successfully Added To The Inventory\n" +
                    $"********************\n" +
                    $"Enter 1 To View Vehicle | Enter 2 To Return To Main Menu");
                string returnInput = Console.ReadLine();
                switch (returnInput)
                {
                    case "1":
                        DisplayVehicleDetail(vehicleToAdd);
                        break;
                    case "2":
                        MainMenu();
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
            else
            {
                Console.WriteLine(
                    $"ERROR\n" +
                    $"{vehicleToAdd.Make} {vehicleToAdd.Model}\n" +
                    $"Was Not Added To The Inventory\n" +
                    $"********************\n" +
                    $"Press Any Key To Return To Main Menu");
                Console.ReadKey();
                MainMenu();
            }
        }
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
