using System;
using System.Collections.Generic;
using OSBL;
using OSModels;
using Serilog;

namespace OSUI
{
    public class LocationInventoryMenu : IMenu
    {
        private IStoreBL _repo;
        private Location location;
        List<Inventory> inventories;
        public List<Location> StorefrontList;

        public LocationInventoryMenu(IStoreBL repo)
        {
            _repo = repo;
            StorefrontList = _repo.GetLocations();
            inventories = _repo.GetInventories();
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
            Boolean stay = true;

            do{
                Console.WriteLine("Which inventory would you like to check?");
                Console.WriteLine("= = = = = = = =");
                foreach(Location store in StorefrontList)
                {
                    Console.WriteLine(store.Name);
                }
                Console.WriteLine("= = = = = = = =");
                Console.WriteLine($"Or enter \"0\" to go back.");
                string userInput = Console.ReadLine();
                foreach(Location L in StorefrontList)
                {
                    if(userInput.Equals(L.Name))
                    {
                        location = L;
                        stay = false;
                    }
                }
                if(stay)
                {
                    Console.WriteLine("Invalid Selection - please enter a valid Location.");
                    Console.WriteLine("Press \"Enter\" to continue.");
                    Console.ReadLine();
                }
            } while (stay);

            Console.WriteLine("");
            Console.WriteLine($"Current Inventory for: {location.Name}");
            Console.WriteLine(string.Format("PID | Qty | Product Name"));
            Console.WriteLine("--------------------------");
            foreach(Inventory inv in inventories)
            {
                if(inv.LocationID == location.ID)
                {
                    Console.WriteLine(string.Format("{0, 3} | {1, 3} | {2}",inv.ProductID, inv.Quantity, _repo.GetProductByID(inv.ProductID).Name));
                }
            }
            Console.WriteLine("Press \"Enter\" to continue.");
            Console.ReadLine();
        }
    }
}