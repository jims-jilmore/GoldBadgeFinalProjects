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
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();
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
            _claimQueue.Enqueue(claimOne);
            _claimList.Add(claimOne);
            _claimRepo.CreateClaim(claimTwo);
            _claimQueue.Enqueue(claimTwo);
            _claimList.Add(claimTwo);
            _claimRepo.CreateClaim(claimThree);
            _claimQueue.Enqueue(claimThree);
            _claimList.Add(claimThree);
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
                "1 ) See All Claims\n" +
                "2 ) View New Claims\n" +
                "3 ) Manage Claims\n" +
                "------------------------\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ShowAllClaims();
                    break;
                case "2":
                    ViewClaimQueue();
                    break;
                case "3":
                    ManageClaimMenu();
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
            claimToAdd.DateOfIncident = DateTime.Parse(Console.ReadLine()); // Need To Test This 
            Console.Clear();
            Console.WriteLine(
                "Enter Date Of Claim\n" +
                "*******************");
            claimToAdd.DateOfClaim = DateTime.Parse(Console.ReadLine());

            if (_claimRepo.ValidateClaim(claimToAdd.DateOfIncident, claimToAdd.DateOfClaim) == true)
            {
                Console.Clear();
                Console.WriteLine(
                    "***********************\n" +
                    "This Claim Is Valid\n" +
                    "*******************\n" +
                    "Press Any Key To Continue");
                _claimRepo.CreateClaim(claimToAdd);
                _claimQueue.Enqueue(claimToAdd);
                ViewClaimQueue();
            }
            else if (_claimRepo.ValidateClaim(claimToAdd.DateOfIncident, claimToAdd.DateOfClaim) == false)
            {
                Console.Clear();
                Console.WriteLine(
                    "*******************\n" +
                    "This Claim Is Invalid\n" +
                    "*********************\n" +
                    "Press Any Key To Continue");
                _claimRepo.CreateClaim(claimToAdd);
                _claimList.Add(claimToAdd);
                _claimQueue.Enqueue(claimToAdd);
                ViewClaimQueue();
            }
            else
            {
                Error();
            }
        }
        public void ViewClaimQueue()
        {
            Console.Clear();
            foreach (var claim in _claimQueue)
            {
                Console.WriteLine(
                    $"**************************\n " +
                    $"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Valid Claim: {claim.IsClaimValid}");
            }
            Console.ReadKey();
            MainMenu();
        }
        public void ShowAllClaims()
        {
            Console.Clear();
            foreach (var claim in _claimList)
            {
                Console.WriteLine(
                    $"*****************\n" +
                    $"Claim ID: {claim.ClaimID} | Claim Type: {claim.ClaimType} | Valid Claim : {claim.IsClaimValid}");
            }
            Console.WriteLine("**************\n" +
                "Press Any Key To Continue");
            Console.ReadKey();
        }
        public void ClaimDetailView(Claim claimToView)
        {
            Console.Clear();
            Console.WriteLine(
                $"**********************************************\n" +
                $"Claim ID: {claimToView.ClaimID}\n" +
                $"Claim Type: {claimToView.ClaimType}\n" +
                $"Description: {claimToView.Description}\n" +
                $"Amount: ${claimToView.ClaimAmount}\n" +
                $"Date Of Incident: {claimToView.DateOfIncident}\n" +
                $"Date of Claim: {claimToView.DateOfClaim}\n" +
                $"Valid Claim: {claimToView.IsClaimValid}\n" +
                $"**********************************************\n" +
                $"To Manage Claim Now    | Enter 1\n" +
                $"To Return To Main Menu | Enter 2");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ManageClaimMenu();
                    break;
                case "2":
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
                "2) Update Claim\n" +
                "3) Remove Claim\n" +
                "4) Main Menu\n" +
                "******************");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddClaim();
                    break;
                case "2":
                    UpdateClaim();
                    break;
                case "3":
                    RemoveClaim();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        public void RemoveClaim()
        {
            Console.Clear();
            Claim claimToRemove = _claimQueue.Peek();

            Console.WriteLine("Do you want to deal with this");
            //some input 

            //yes 
            _claimRepo.RemoveClaim();




            Console.WriteLine(
                $"Are you sure you want to remove Claim ID:{claimToRemove.ClaimID}?\n" +
                $"Enter Y for Yes | Enter N for No");

            string userinput = Console.ReadLine().ToUpper();
            switch (userinput)
            {
                case "Y":
                    Console.Clear();
                    Console.WriteLine(
                        $"Claim ID:{claimToRemove.ClaimID} was successfully removed.\n" +
                        $"************************************************************\n" +
                        $"Press Any Key To Continue");
                    Console.ReadKey();
                    ManageClaimMenu();
                    break;
                case "N":
                    ManageClaimMenu();
                    break;
                default:
                    Error();
                    break;
            }
        }
        private void UpdateClaim()
        {
            Console.Clear();
            ShowAllClaims();
            Console.WriteLine(
                "************************\n" +
                "Enter Claim ID To Update\n" +
                "************************");
            int idUserInput = int.Parse(Console.ReadLine());
            Claim oldClaim = _claimRepo.ViewSingleClaim(idUserInput);
            Claim updatedClaim = new Claim();

            Console.Clear();
            Console.WriteLine(
                "Select Claim Type:\n" +
                "1) Car\n" +
                "2) Home\n" +
                "3) Theft\n");
            int typeInput = int.Parse(Console.ReadLine());
            if (typeInput == 1)
            {
                updatedClaim.ClaimType = TypeOfClaim.Car;
            }
            else if (typeInput == 2)
            {
                updatedClaim.ClaimType = TypeOfClaim.Home;
            }
            else if (typeInput == 3)
            {
                updatedClaim.ClaimType = TypeOfClaim.Theft;
            }
            else
            {
                Error();
            }
            Console.Clear();
            Console.WriteLine(
                "Enter Brief Description Of The Incident\n" +
                "***************************************");
            updatedClaim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(
                "Enter The Amount Of The Claim\n" +
                "*****************************");
            updatedClaim.ClaimAmount = Decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(
                "Enter Date Of Incident\n" +
                "**********************");
            updatedClaim.DateOfIncident = DateTime.Parse(Console.ReadLine()); // Need To Test This 
            Console.Clear();
            Console.WriteLine(
                "Enter Date Of Claim\n" +
                "*******************");
            updatedClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            if (_claimRepo.ValidateClaim(updatedClaim.DateOfIncident, updatedClaim.DateOfClaim) == true)
            {
                Console.Clear();
                Console.WriteLine(
                    "***********************\n" +
                    "This Claim Is Valid\n" +
                    "*******************\n" +
                    "Press Any Key To Continue");
                _claimRepo.UpdateClaim(idUserInput, oldClaim);
                _claimList.Add(updatedClaim);
                _claimQueue.Enqueue(updatedClaim);
                ViewClaimQueue();
            }
            else if (_claimRepo.ValidateClaim(updatedClaim.DateOfIncident, updatedClaim.DateOfClaim) == false)
            {
                Console.Clear();
                Console.WriteLine(
                    "*******************\n" +
                    "This Claim Is Invalid\n" +
                    "*********************\n" +
                    "Press Any Key To Continue");
                _claimRepo.UpdateClaim(idUserInput, oldClaim);
                _claimList.Add(updatedClaim);
                _claimQueue.Enqueue(updatedClaim);
                ViewClaimQueue();
            }
            else
            {
                Error();
            }
        }// delete or comment out
        
    }
}
