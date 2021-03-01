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
        public List<Location> StorefrontList;
        public StoreSelectMenu(IStoreBL repo)
        {
            _repo = repo;
            StorefrontList = _repo.GetLocations();
        }
        
        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true, badEntryFlag = true;
            IMenu menu;

            //TODO: get list of stores from database

            //TEST CODE (I KNOW I SHOULD BE UNIT TESTING BUT OH WELL)
            //-------------------------------
            // Location newYork = new Location();
            // newYork.Name = "New York";
            // Location chicago = new Location();
            // chicago.Name = "Chicago";
            // Location losAngeles = new Location();
            // losAngeles.Name = "Los Angeles";

            // StorefrontList.Add(newYork);
            // StorefrontList.Add(chicago);
            // StorefrontList.Add(losAngeles);
            //-------------------------------

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

                // Console.WriteLine("<DEBUG>");
                // Console.WriteLine($"User Input: {userInput}");
                // Console.WriteLine($"store count: {StorefrontList.Count}");
                // Console.WriteLine("</DEBUG>");

                if (userInput.Equals("0"))
                {
                    stay = false;
                    break;
                }
                foreach(Location store in StorefrontList)
                {
                    Console.WriteLine(store.Name);
                    if (userInput.Equals(store.Name))
                    {
                        badEntryFlag = false;
                        menu = new CategoryChoiceMenu(store, _repo);
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