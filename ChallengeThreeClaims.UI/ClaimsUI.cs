using ChallengeThreeClaims.POCO;
using ChallengeThreeClaims.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClaims.UI
{
    class ClaimsUI
    {
        private readonly ClaimREPO _claimRepo = new ClaimREPO();
        private bool isAppRunning = true;

        public void Run()
        {
            Seed();
            while (isAppRunning)
            {
                RunApplication();
            }
        }
        public void Seed()
        {
            Claim claimOne = new Claim(1, TypeOfClaim.Car, "Rear Ended", 2000m, true);
            Claim claimTwo = new Claim(2, TypeOfClaim.Home, "Kitchen Fire", 10000m, true);
            Claim claimThree = new Claim(3, TypeOfClaim.Theft, "Burglary", 5000m, false);
            _claimRepo.CreateClaim(claimOne);
            _claimRepo.CreateClaim(claimTwo);
            _claimRepo.CreateClaim(claimThree);
        }
        private void RunApplication()
        {
            MainMenu();
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "***********************\n" +
                "Komodo Claim Management\n" +
                "***********************\n" +
                "Select An Option:\n" +
                "1 ) View Claim Queue\n" +
                "2 ) Manage Claims\n" +
                "3 ) Exit Application\n" +
                "------------------------\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewClaimQueue();
                    break;
                case "2":
                    ManageClaimMenu();
                    break;
                case "3":
                    Console.Clear();
                    isAppRunning = false;
                    break;
                default:
                    Error();
                    break;
            }
        }
        public void ViewClaimQueue()
        {
            Console.Clear();
            var queue = _claimRepo.ShowClaimQueue();
            foreach (var claim in queue)
            {
                Console.WriteLine(
                    $"**************************\n " +
                    $"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Valid Claim: {claim.IsClaimValid}");
            }
            Console.WriteLine(
                "*********************************************************\n" +
                "Enter 1 | To Manage Next Claim || Enter 2 | For Main Menu\n" +
                "*********************************************************");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ClaimDetailView();
                    break;
                case "2":
                    MainMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        public void ClaimDetailView()
        {
            var queue = _claimRepo.ShowClaimQueue();
            Claim nextClaimInQueue = queue.Peek();
            Console.Clear();
            Console.WriteLine(
                $"**********************************************\n" +
                $"|Claim ID: {nextClaimInQueue.ClaimID}\n" +
                $"|Claim Type: {nextClaimInQueue.ClaimType}\n" +
                $"|Description: {nextClaimInQueue.Description}\n" +
                $"|Amount: ${nextClaimInQueue.ClaimAmount}\n" +
                $"|Date Of Incident: {nextClaimInQueue.DateOfIncident}\n" +
                $"|Date of Claim: {nextClaimInQueue.DateOfClaim}\n" +
                $"|Valid Claim: {nextClaimInQueue.IsClaimValid}\n" +
                $"**********************************************\n" +
                $"Enter 1 | To Remove Claim || Enter 2 | For Main Menu");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    // RemoveClaim();
                    _claimRepo.RemoveClaim();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        private void ManageClaimMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Select An Option\n" +
                "******************\n" +
                "1) Add Claim\n" +
                "2) Remove Claim\n" +
                "3) Main Menu\n" +
                "******************");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddClaim();
                    break;
                case "2":
                    RemoveClaim();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        public void AddClaim()
        {
            Claim claimToAdd = new Claim();
            Console.Clear();
            Console.WriteLine(
                "Select Claim Type:\n" +
                "1) Car\n" +
                "2) Home\n" +
                "3) Theft\n");
            int typeInput = int.Parse(Console.ReadLine());
            if (typeInput == 1)
            {
                claimToAdd.ClaimType = TypeOfClaim.Car;
            }
            else if (typeInput == 2)
            {
                claimToAdd.ClaimType = TypeOfClaim.Home;
            }
            else if (typeInput == 3)
            {
                claimToAdd.ClaimType = TypeOfClaim.Theft;
            }
            else
            {
                Error();
            }
            Console.Clear();
            Console.WriteLine(
                "Enter Brief Description Of The Incident\n" +
                "***************************************");
            claimToAdd.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(
                "Enter The Amount Of The Claim\n" +
                "*****************************");
            claimToAdd.ClaimAmount = Decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(
                "Enter Date Of Incident\n" +
                "**********************");
            claimToAdd.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(
                "Enter Date Of Claim\n" +
                "*******************");
            claimToAdd.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimRepo.ValidateClaim(claimToAdd.DateOfIncident, claimToAdd.DateOfClaim);

            if (_claimRepo.ValidateClaim(claimToAdd.DateOfIncident, claimToAdd.DateOfClaim) == true)
            {
                claimToAdd.IsClaimValid = true;
                Console.Clear();
                Console.WriteLine(
                    "***********************\n" +
                    "This Claim Is Valid\n" +
                    "*******************\n" +
                    "Press Any Key To Continue");
                _claimRepo.CreateClaim(claimToAdd);
               // _claimQueue.Enqueue(claimToAdd);
                Console.ReadKey();
                ViewClaimQueue();
            }
            else if (_claimRepo.ValidateClaim(claimToAdd.DateOfIncident, claimToAdd.DateOfClaim) == false)
            {
                claimToAdd.IsClaimValid = false;
                Console.Clear();
                Console.WriteLine(
                    "*******************\n" +
                    "This Claim Is Invalid\n" +
                    "*********************\n" +
                    "Press Any Key To Continue");
                _claimRepo.CreateClaim(claimToAdd);
                Console.ReadKey();
                ViewClaimQueue();
            }
            else
            {
                Error();
            }
        }
        public void RemoveClaim()
        {
            Claim claimToRemove = _claimQueue.Peek();
            Console.WriteLine(
                "Are you sure you want to remove this claim?\n" +
                "*******************************************\n" +
                "Enter Y To Confirm | Enter N for Main Menu\n" +
                "*******************************************");
            string userInput = Console.ReadLine().ToUpper();
            switch (userInput)
            {
                case "Y":
                    Console.Clear();
                    _claimRepo.RemoveClaim();
                   // _claimQueue.Dequeue();
                    Console.WriteLine(
                            "*********************************************\n" +
                            "Claim was successfully removed from the queue\n" +
                            "*********************************************\n" +
                            "Press Any Key For Main Menu");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case "N":
                    MainMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        private void Error()
        {
            Console.Clear();
            Console.WriteLine(
                        "*****\n" +
                        "ERROR\n" +
                        "*****\n" +
                        "Press Any Key For Main Menu");
            Console.ReadKey();
            MainMenu();
        }
    }
}