using System;
using Serilog;
using OSModels;

namespace OSUI
{
    public class IDEntryMenu : IMenu
    {
        public void Start() 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            IMenu menu;
            Boolean stay = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("===============");
                Console.WriteLine("Welcome to REI!");
                Console.WriteLine("===============");
                Console.WriteLine("Please enter one of the following:");
                Console.WriteLine("[1] New Customer");
                Console.WriteLine("[2] Returning Customer");
                Console.WriteLine("[0] Exit");
                string userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "1":
                        //TODO: new customer
                        break;
                    case "2":
                        //TODO: search for customer details by name
                        //temp debug code:
                            {menu = new CustomerMenu();
                            menu.Start();}
                        break;
                    case "0":
                        stay = false;
                        Console.WriteLine("Thanks for shopping with REI!");
                        break;
                    default:
                        break;
                }
            } while (stay);


            // switch(userID)
            // {
            //     case "69":
            //         Log.Information("Manager logged-in.");
            //         menu = new ManagerMenu();
            //         menu.Start();
            //         break;
            //     default:
            //         Log.Information("User {userID} logged-in.", userID);
            //         menu = new CustomerMenu();
            //         menu.Start();
            //         break;
            // }
        }
    }
}