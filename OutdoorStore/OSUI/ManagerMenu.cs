using System;
using OSBL;
using OSModels;
using Serilog;

namespace OSUI
{
    public class ManagerMenu : IMenu
    {
        IStoreBL _repo;
        public ManagerMenu(IStoreBL repo)
        {
            _repo = repo;
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
            Boolean stay = true;
            IMenu menu;
            do{
                Console.WriteLine("");
                Console.WriteLine("================");
                Console.WriteLine("  Manager Menu");
                Console.WriteLine("================");
                Console.WriteLine("");
                Console.WriteLine("Navigate by entering one of the following:");
                Console.WriteLine("[1] View each location's Order History");
                Console.WriteLine("[2] View each location's current Inventory");
                Console.WriteLine("[3] Restock an item");
                Console.WriteLine("[4] Display all Products");
                Console.WriteLine("[5] Find Customer by Name");
                Console.WriteLine("[0] Back");
                string managerInput = Console.ReadLine();
                switch(managerInput)
                {
                    case "1":
                        menu = new LocationHistoryMenu(_repo);
                        menu.Start();
                        break;
                    case "2":
                        menu = new LocationInventoryMenu(_repo);
                        menu.Start();
                        break;
                    case "3":
                        try{ updateInventory(); }
                        catch(Exception)
                        {
                            Console.WriteLine("Please try again!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                        foreach( Product p in _repo.GetProducts())
                        {
                            Console.WriteLine(p.ToString());
                        }
                        break;
                    case "5":
                        Console.WriteLine("Please enter Customer name:");
                        string str = Console.ReadLine();
                        try{
                            Console.WriteLine(_repo.GetCustomerByName(str).ToString());
                        }
                        catch(NullReferenceException)
                        {
                            Log.Error("Invalid navigation selection - Manager Menu");
                            Log.CloseAndFlush();
                            Console.WriteLine("Invalid choice - Please try a different name.");
                            Console.WriteLine("Press \"Enter\" to continue.");
                            Console.ReadLine();
                        }
                        // if (foundCust == null)
                        // {
                        //     Console.WriteLine("No Customer by that name found, check your spelling and try again!");
                        // }
                        break;
                    case "0":
                        stay = false;
                        break;
                    default:
                        Log.Error("Invalid navigation selection - Manager Menu");
                        Log.CloseAndFlush();
                        Console.WriteLine("Invalid choice - Please enter \"1\" or \"2\".");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;
                }
            } while(stay);
        }

        private Inventory updateInventory()
        {
            string userInput;
            int newLocationID=0;
            Inventory newInventory;
            Console.WriteLine("Enter Location you'd like to update:");
            userInput = Console.ReadLine();
            foreach(Location l in _repo.GetLocations())
            {
                if (l.Name.Equals(userInput))
                {
                    newLocationID = l.ID;

                    Console.WriteLine("Enter Product ID you'd like to update:");
                    userInput = Console.ReadLine();

                    foreach(Inventory inv in _repo.GetInventories())
                    {
                        if(inv.LocationID == newLocationID && inv.ProductID == _repo.GetProductByShortName(userInput).ID)
                        {
                            newInventory = inv;
                            Console.WriteLine("Enter the updated Stock Quantity:");
                            userInput = Console.ReadLine();
                            newInventory.Quantity = int.Parse(userInput);
                            _repo.UpdateInventory(inv);
                            return inv;
                        }
                    }
                    Log.Error("Invalid product selection - Manager Menu - Update Inventory");
                    throw new Exception();
                }
            }
            Log.Error("Invalid location selection - Manager Menu - Update Inventory");
            throw new Exception();
        }
    }
}