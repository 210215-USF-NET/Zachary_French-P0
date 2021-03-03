using System;
using Serilog;
using OSBL;
using OSModels;
using System.Collections.Generic;

namespace OSUI
{
    public class StoreSelectMenu : IMenu
    {
        private IStoreBL _repo;
        private Customer _customer;
        public List<Location> StorefrontList;
        public StoreSelectMenu(IStoreBL repo, Customer c)
        {
            _repo = repo;
            _customer = c;
            StorefrontList = _repo.GetLocations();
        }
        
        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
            Boolean stay = true, badEntryFlag = true;
            IMenu menu;

            do
            {
                Console.WriteLine("Please enter the name of the store you'd like to shop from.");
                Console.WriteLine("Our current locations:");
                Console.WriteLine("= = = = = = = =");
                foreach(Location store in StorefrontList)
                {
                    Console.WriteLine(store.Name);
                }
                Console.WriteLine("= = = = = = = =");
                Console.WriteLine($"Or enter \"0\" to go back.");
                string userInput = Console.ReadLine();

                if (userInput.Equals("0"))
                {
                    stay = false;
                    break;
                }
                foreach(Location store in StorefrontList)
                {
                    if (userInput.Equals(store.Name))
                    {
                        badEntryFlag = false;
                        menu = new CategoryChoiceMenu(store, _repo, _customer);
                        menu.Start();
                        break;
                    }
                }

                if(badEntryFlag)
                {
                    Log.Error("Invalid location selection");
                    Console.WriteLine("Please enter a valid location.");
                    Console.WriteLine("Press \"Enter\" to continue.");
                    Console.ReadLine();
                }
            } while (stay);
        }
    }
}