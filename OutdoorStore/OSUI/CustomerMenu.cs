using System;
using Serilog;

namespace OSUI
{
    public class CustomerMenu : IMenu
    {
        public CustomerMenu(){

        }
        public void Start() 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true;
            IMenu menu;
            do
            {
                //Print Customer UI
                Console.WriteLine("");
                Console.WriteLine("===============");
                Console.WriteLine("Welcome to REI!");
                Console.WriteLine("===============");
                Console.WriteLine("");
                Console.WriteLine("Navigate by entering one of the following:");
                Console.WriteLine("[1] Start Shopping");
                Console.WriteLine("[2] View Order History");
                Console.WriteLine("[3] Exit");
                string custInput = Console.ReadLine();

                switch(custInput)
                {
                    case "1":
                    menu = new StoreSelectMenu();
                    menu.Start();
                    break;
                case "2":
                    menu = new OrderListMenu();
                    menu.Start();
                    break;
                case "3":
                    stay = false;
                    break;
                default:
                    Log.Error("Invalid navigation selection (not 'start shopping' or 'order history').");
                    Console.WriteLine("Invalid choice - Please enter \"1\" or \"2\".");
                    Console.WriteLine("Press \"Enter\" to continue.");
                    Console.ReadLine();
                    break;
                }
            }
            while(stay);
        }
    }
}