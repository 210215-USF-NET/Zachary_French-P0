using System;
using Serilog;

namespace OSUI
{
    public class IDEntryMenu : IMenu
    {
        public void Start() 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();

            Console.WriteLine("Please enter your User ID.");
            string userID = Console.ReadLine();
            IMenu menu;
            switch(userID)
            {
                case "69":
                    Log.Information("Manager logged-in.");
                    menu = new ManagerMenu();
                    menu.Start();
                    break;
                default:
                    Log.Information("User {userID} logged-in.", userID);
                    menu = new CustomerMenu();
                    menu.Start();
                    break;
            }
        }
    }
}