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
            Vehicle vehicleOne = new Vehicle("Gas", "2022", "Kia", "Telluride", 50.0000m, true, 25, 32, 1);
            Vehicle vehicleTwo = new Vehicle("Electric" ,"2022", "Tesla", "Model X", true);
            Vehicle vehicleThree = new Vehicle("Gas", "2022", "Ford", "F-150 Raptor", false); 
            Vehicle vehicleFour = new Vehicle("Gas", "1969", "Ford", "Mustang", 10000000m, false, 1, 2, 4);
            Vehicle vehicleFive = new Vehicle("Electric", "2017", "Chevy", "Volt", true);
            Vehicle vehicleSix = new Vehicle("Hybrid", "2019", "Toyota", "Prius", true);
            _vehicle.CreateVehicle(vehicleOne);
            _vehicle.CreateVehicle(vehicleTwo);
            _vehicle.CreateVehicle(vehicleThree);
            _vehicle.CreateVehicle(vehicleFour);
            _vehicle.CreateVehicle(vehicleFive);
            _vehicle.CreateVehicle(vehicleSix);
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
                "1: View Inventory Menu\n" +
                "2: Add Vehicle Menu\n" +
                "3: Update Vehicle Information\n" +
                "4: Remove Vehicle Menu\n" +
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
                    UpdateVehicleInfoMenu();
                    break;
                case "4":
                    RemoveVehicleMenu();
                    break;
                case "5":
                    GoodbyePage();
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
                "-----Inventory Menu-----\n" +
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
                    ViewVehicleInventoryMenu();
                    break;
                case "2":
                    ListVehicleByType();
                    break;
                case "3":
                    SearchSpecificVehicle();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void SearchSpecificVehicle()
        {
            DisplayVehicleInventory();
            Console.Clear();
            Console.WriteLine("Enter ID of the Vehicle To View");
            Vehicle vehicle = _vehicle.ViewVehicleById(int.Parse(Console.ReadLine()));
            DisplayVehicleDetail(vehicle);
            
        }
        private void DisplayVehicleDetail(Vehicle vehicle)
        {
            List<Vehicle> vehiclesToList = _vehicle.ViewAllVehicles();
            Console.Clear();
            foreach (var vehicleToList in vehiclesToList)
            {
                if (vehicleToList.IdNumber == vehicle.IdNumber)
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
                    ViewVehicleInventoryMenu();
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

            foreach (var vehicle in vehicleInventory)
            {
                Console.WriteLine($"ID: {vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine("********************\n" +
                "Press Any Key To Continue");
            Console.ReadKey();
        }
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
            Console.Clear();
            List<Vehicle> gasVehicles = _vehicle.ViewGasVehicles();
            Console.WriteLine(
                "|||||Gas Vehicles|||||\n" +
                "**********************");
            foreach (var vehicle in gasVehicles)
            {
                Console.WriteLine($"ID: {vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine(
                "**********************\n" +
                "Press Any Key To Return To Inventory Menu");
            Console.ReadKey();
            ViewVehicleInventoryMenu();
        }  // Base Function Works. Not Listing all vehicles though
        private void ListElectricVehicles()
        {
            Console.Clear();
            List<Vehicle> electricVehicles = _vehicle.ViewElectricVehicles();
            Console.WriteLine(
                "|||||Electric Vehicles|||||\n" +
                "**********************");
            foreach (var vehicle in electricVehicles)
            {
                Console.WriteLine($"ID: {vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine(
                "**********************\n" +
                "Press Any Key To Return To Inventory Menu");
            Console.ReadKey();
            ViewVehicleInventoryMenu();
        } // Base Function Works. 
        private void ListHybridVehicles()
        {
            Console.Clear();
            List<Vehicle> hybridVehicles = _vehicle.ViewHybridVehicles();
            Console.WriteLine(
                "|||||Hybrid Vehicles|||||\n" +
                "**********************");
            foreach (var vehicle in hybridVehicles)
            {
                Console.WriteLine($"ID: {vehicle.IdNumber} | {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
            Console.WriteLine(
                "**********************\n" +
                "Press Any Key To Return To Inventory Menu");
            Console.ReadKey();
            ViewVehicleInventoryMenu();
        }  // Base Function Works.
        private void AddVehicleToInventory()
        {
            Console.Clear();
            Console.WriteLine(
                "********************\n" +
                "Add Vehicle Menu\n" +
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
        } // Add Multiple Not Build | Not REQ'd
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
                    vehicleToAdd.VehicleType = "Gas";
                    break;
                case "2":
                    vehicleToAdd.VehicleType = "Electric";
                    break;
                case "3":
                    vehicleToAdd.VehicleType = "Hybrid";
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
        private void UpdateVehicleInfoMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "|||||Update Vehicle Info Menu|||||\n" +
                "**********************************\n" +
                "!) Update Vehicle\n" +
                "2) Return To Main Menu");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    UpdateVehicle();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void UpdateVehicle()
        {
            DisplayVehicleInventory();
            Console.WriteLine("Enter ID Of Vehicle To Update");
            int idToUpdate = int.Parse(Console.ReadLine());
            Vehicle vehicleToUpdate = new Vehicle();
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
                    vehicleToUpdate.VehicleType = "Gas";
                    break;
                case "2":
                    vehicleToUpdate.VehicleType = "Electric";
                    break;
                case "3":
                    vehicleToUpdate.VehicleType = "Hybrid";
                    break;
                default:
                    ErrorMessage();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Enter The Year Of The Vehicle");
            vehicleToUpdate.Year = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Make Of The Vehicle");
            vehicleToUpdate.Make = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Model Of The Vehicle");
            vehicleToUpdate.Model = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter The Price Of The Vehicle");
            vehicleToUpdate.Price = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Does The Vehicle Have An Incentive (y/n)");
            string incentiveInput = Console.ReadLine().ToLower();
            switch (incentiveInput)
            {
                case "y":
                    vehicleToUpdate.HasIncentive = true;
                    break;
                case "n":
                    vehicleToUpdate.HasIncentive = false;
                    break;
                default:
                    ErrorMessage();
                    break;
            }

            Console.Clear();
            Console.WriteLine("Enter The Vehicles Estimated City MPG");
            vehicleToUpdate.CityMPG = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter The Vehicle's Estimated Highway MPG");
            vehicleToUpdate.HighwayMPG = int.Parse(Console.ReadLine());

            Console.Clear();
            if (_vehicle.UpdateVehicle(idToUpdate, vehicleToUpdate) == true)
            {
                Console.WriteLine(
                    $"{vehicleToUpdate.Make} {vehicleToUpdate.Model}\n" +
                    $"Was Successfully Added To The Inventory\n" +
                    $"********************\n" +
                    $"Enter 1 To View Vehicle | Enter 2 To Return To Main Menu");
                string returnInput = Console.ReadLine();
                switch (returnInput)
                {
                    case "1":
                        DisplayVehicleDetail(vehicleToUpdate);
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
                    $"{vehicleToUpdate.Make} {vehicleToUpdate.Model}\n" +
                    $"Was Not Added To The Inventory\n" +
                    $"********************\n" +
                    $"Press Any Key To Return To Main Menu");
                Console.ReadKey();
                MainMenu();
            }
        }
        private void RemoveVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "**************\n" +
                "Remove Vehicle Menu\n" +
                "**************\n" +
                " \n" +
                "Select an Option:\n" +
                "1) Remove Vehicle by Id\n" +
                "2) Remove Multiple Vehicles (Coming Soon)\n" +
                "3) View Vehicle Inventory\n" +
                "4) Return To Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveVehicleById();
                    break;
                case "2":
                    RemoveMultipleVehicles();
                    break;
                case "3":
                    DisplayVehicleInventory();
                    RemoveVehicleMenu();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        private void RemoveVehicleById()
        {
            DisplayVehicleInventory();
            Console.Clear();
            Console.WriteLine("***************************\n" +
                "Enter ID Number To Remove Vehicle");

            int userInput = int.Parse(Console.ReadLine());
            Vehicle vehicleToRemove = _vehicle.ViewVehicleById(userInput);
            if (vehicleToRemove.IdNumber == userInput)
            {
                _vehicle.RemoveVehicle(vehicleToRemove);
                Console.WriteLine($"ID: {vehicleToRemove.IdNumber} | {vehicleToRemove.Year} {vehicleToRemove.Make} {vehicleToRemove.Model} was successfully removed.\n" +
                    $"**********************\n" +
                    $"Press Any Key Continue\n" +
                    $"**********************");
                Console.ReadKey();
                RemoveVehicleMenu();
            }
            else if (vehicleToRemove.IdNumber != userInput)
            {
                Console.WriteLine(
                    $"ERROR\n" +
                    $"ID: {vehicleToRemove.IdNumber} | {vehicleToRemove.Year} {vehicleToRemove.Make} {vehicleToRemove.Model} was NOT removed.\n" +
                    $"**********************\n" +
                    $"Press Any Key Continue\n" +
                    $"**********************");
                Console.ReadKey();
                RemoveVehicleMenu();
            }
            else
            {
                Console.WriteLine("ERROR ERROR ERROR\n" +
                    "********************\n" +
                    "Press Any Key To Return To Main Menu");
                Console.ReadKey();
                MainMenu();
            }
        }
        private void RemoveMultipleVehicles()
        {
            throw new NotImplementedException();
        } // Not Built: Not REQ'd
        private void IncentiveOffer()
        {
            Console.WriteLine(
                "This vehicle has a special offer!\n" +
                "*********************************\n" +
                "Press any key to continue!");
            Console.ReadKey();
            ViewVehicleInventoryMenu();
        }// Could build more functionality for the Incentive | Not REQ'd
        private void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine(
                "Please Select A Menu Option\n" +
                "Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        private void GoodbyePage()
        {
            _isAppRunning = false;
            Console.Clear();
            Console.WriteLine("Goodbye");
            Thread.Sleep(5000);
        }
    }
}
