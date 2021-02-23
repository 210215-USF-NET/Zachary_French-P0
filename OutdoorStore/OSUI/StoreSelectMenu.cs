using System;
using Serilog;
using OSModels;
using System.Collections.Generic;

namespace OSUI
{
    public class StoreSelectMenu : IMenu
    {
        public List<Location> StorefrontList = new List<Location>();
        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true;
            IMenu menu;

            //TODO: get list of stores from database

            //TEST CODE (I KNOW I SHOULD BE UNIT TESTING BUT OH WELL)
            //-------------------------------
            Location newYork = new Location();
            Location chicago = new Location();
            Location losAngeles = new Location();

            StorefrontList.Add(newYork);
            StorefrontList.Add(chicago);
            StorefrontList.Add(losAngeles);
            //-------------------------------

            do
            {
                Console.WriteLine("Please enter the name of the store you'd like to shop from.");
                Console.WriteLine("Our current locations:");
                Console.WriteLine("= = = = = = = =");
                foreach(Location store in StorefrontList)
                {
                    Console.WriteLine($"{store.Name}");
                }
                Console.WriteLine("= = = = = = = =");
                Console.WriteLine($"Or enter \"0\" to go back.");
                string userInput = Console.ReadLine();

                foreach(Location store in StorefrontList)
                {
                    if (userInput.Equals(store.Name))
                    {
                        //TODO: launch shopping page for that store
                    }
                    else if (userInput.Equals("0"))
                    {
                        stay = false;
                        break;
                    }
                    else {
                        Log.Error("Invalid location selection");
                        Console.WriteLine("Please enter a valid location.");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;
                    }
                }
                // switch(userInput)
                // {
                //     case "0":
                //         stay = false;
                //         break;
                //     default:
                //         Log.Error("Invalid store selection.");
                //         Console.WriteLine("Invalid choice - Please select a valid store.");
                //         Console.WriteLine("Press \"Enter\" to continue.");
                //         Console.ReadLine();
                //         break;
                // }
                
            } while (stay);
        }

        
    }
}