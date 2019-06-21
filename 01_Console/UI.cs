using _01_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    public class UI
    {
        private Repository _orderRepo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe!\n" +
                    "\n" +
                    "1. List all orders\n" +
                    "2. Add an order\n" +
                    "3. Remove an order\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllOrders();
                        break;
                    case "2":
                        CreateOrder();
                        break;
                    case "3":
                        RemoveOrderFromList();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                }
            }
        }

        public void ListAllOrders()
        {
            List<Menu> ItemList = _orderRepo.ListOrders();

            foreach(Menu content in ItemList)
            {
                Console.WriteLine($"#{content.ItemNumber} {content.Name}\n" +
                    $"Description: {content.Desc}\n" +
                    $"Ingredients: {content.Ingredients}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.ReadLine();
        }

        public void CreateOrder()
        {
            Menu content = new Menu();

            Console.Clear();
            Console.WriteLine("(ID) (Name) (Description) (Ingrediants)\n");

            Console.WriteLine("Enter the new item's item number: ");
            content.ItemNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) (Name) (Description) (Ingrediants)\n");

            Console.WriteLine("Enter the item's name: ");
            content.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) (Description) (Ingrediants)\n");

            Console.WriteLine($"Enter a description for {content.Name}: ");
            content.Desc = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) ({content.Desc}) (Ingrediants)\n");

            Console.WriteLine($"Enter the ingrediants for {content.Name}: ");
            content.Ingredients = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Order Summary:\n");

            Console.WriteLine($"Item Number: {content.ItemNumber}\n" +
                $"Name: {content.Name}\n" +
                $"Description: {content.Desc}\n" +
                $"Ingrediants: {content.Ingredients}\n");

            Console.WriteLine("Press any key to confirm order");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Order successfully added!\n" +
                "Press any key to continue...");
            Console.ReadKey();

            _orderRepo.AddOrder(content);

        }

        public void RemoveOrderFromList()
        {
            Console.WriteLine("What order would you like to remove?\n" +
                "(Select by item number)");

            List<Menu> ItemList = _orderRepo.ListOrders();

            foreach (Menu order in ItemList)
            {
                Console.WriteLine($"#{order.ItemNumber} - {order.Name}\n");
            }
            
            int numRemove = int.Parse(Console.ReadLine());

            Menu menuObject = _orderRepo.FindOrderByID(numRemove);

            _orderRepo.RemoveOrder(menuObject);

            Console.WriteLine("Order successfully removed!\n" +
    "Press any key to continue...");
            Console.ReadKey();

        }
        public void SeedContent()
        {
            Menu cheeseBurger = new Menu(1, "Cheese Burger", "Just a plain old burger.", "2 buns, 1 patty");
            Menu chickenSandwich = new Menu(2, "Chicken Sandwich", "Crispy seasoned chicken breast inbetween two toasted buns.", "2 buns, 1 chicken breast");
            Menu grilledCheese = new Menu(3, "Grilled Cheese", "Warmly toasted grilled cheese sandwich.", "2 bread, 2 slices of cheese");

            _orderRepo.AddOrder(cheeseBurger);
            _orderRepo.AddOrder(chickenSandwich);
            _orderRepo.AddOrder(grilledCheese);
        }
    }
}
