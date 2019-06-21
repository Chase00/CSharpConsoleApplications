using _02_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Console
{
    public class UI
    {
        private Repository _repo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("~~ Komodo Claims Department Program ~~\n" +
                    "1. Take next claim\n" +
                    "2. List all claims\n" +
                    "3. Add a claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        TakeClaim();
                        // Take next claim
                        break;
                    case "2":
                        ListAllClaims();
                        // List all claims
                        break;
                    case "3":
                        AddNewClaim();
                        // Add a new claim
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void TakeClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details on the next claim to be handled: \n");

            Queue<Claims> newList = _repo.GetList();
            Claims nextClaim = newList.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Incident Date: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Claim Date: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do you want to take this claim? (y/n)");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("You have successfully taken the claim\n" +
                        "Press any key to continue...");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter either y or n");
                    break;
            }
            Console.ReadLine();
        }
        public void ListAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimList = _repo.GetList();

            Console.WriteLine("ClaimID  Type   DateOfAccident  DateOfClaim   IsValid   Amount   Description\n");
            foreach (Claims content in claimList)
            {
                Console.WriteLine($"{ content.ClaimID}         {content.ClaimType}     {content.DateOfIncident.ToShortDateString()}     {content.DateOfClaim.ToShortDateString()}      {content.IsValid}    ${content.ClaimAmount}    {content.Description}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void AddNewClaim()
        {
            Claims content = new Claims();

            Console.Clear();
            Console.WriteLine($"(ID) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    content.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    content.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    content.ClaimType = TypeOfClaim.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter a description of the claim ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim amount:");
            content.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of the incident: ");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.ClaimAmount}) ({content.DateOfIncident}) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of claim: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _repo.IsValid(content);

            Console.Clear();
            Console.WriteLine($"You are about to add the following claim to the queue: \n" +
                $"\n" +
                $"ID: {content.ClaimID}\n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${content.ClaimAmount}\n" +
                $"Incident Date: {content.DateOfIncident}\n" +
                $"Claim Date: {content.DateOfClaim}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"Press any key to confirm the entry...");
            Console.ReadKey();

            _repo.AddClaim(content);

            Console.Clear();
            Console.WriteLine("Claim successfully added to the queue!\n" +
                "Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void SeedContent()
        {
            Claims claimOne = new Claims(1, TypeOfClaim.Car, "Broken windshield", 450, DateTime.Parse("06/13/2019"), DateTime.Parse("06/14/2019"), true);
            Claims claimTwo = new Claims(2, TypeOfClaim.Home, "Front door hail damage", 325.75m, DateTime.Parse("03/20/2019"), DateTime.Parse("06/01/2019"), false);
            Claims claimThree = new Claims(3, TypeOfClaim.Theft, "Stolen best pancakes in town", 325000, DateTime.Parse("05/30/2019"), DateTime.Parse("06/15/2019"), true);

            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
    }
}
