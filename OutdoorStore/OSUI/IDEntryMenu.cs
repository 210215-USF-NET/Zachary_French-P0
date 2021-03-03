using System;
using Serilog;
using OSModels;
using OSBL;
using System.Collections.Generic;

namespace OSUI
{
    public class IDEntryMenu : IMenu
    {
        private IStoreBL _repo;

        public IDEntryMenu(IStoreBL repo)
        {
            _repo = repo;
        }

        public void Start() 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
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
                        Customer cust = _repo.AddCustomer(newCustomer());
                        Log.Information("Customer record added to database.");

                        Console.WriteLine("\nSuccessfully registered!");
                        menu = new CustomerMenu(_repo, cust);
                        menu.Start();
                        break;

                    case "2":
                        Console.WriteLine("Please enter your name:");
                        string str = Console.ReadLine();

                        try {
                            Customer foundCust = _repo.GetCustomerByName(str);

                            if ( foundCust.Name.Equals("Jerry Seinfeld"))
                            {
                                menu = new ManagerMenu(_repo);
                                menu.Start();
                            }
                            else
                            {
                                Console.WriteLine($"\nCustomer record for {foundCust.Name} found.");
                                menu = new CustomerMenu(_repo, foundCust);
                                menu.Start();
                            }
                        }
                        catch(NullReferenceException)
                        {
                            Log.Fatal("No name provided");
                            Console.WriteLine("Please enter a valid name");
                        }
                        break;

                    case "0":
                        stay = false;
                        Console.WriteLine("Thanks for shopping with REI!");
                        break;

                    default:
                        Log.Error("Invalid Navigation Selection - ID Entry Menu");
                        Console.WriteLine("Invalid choice - Please enter 1 or 2 to proceed, or 0 to go back.");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;
                }
            } while (stay);
        }

        public Customer newCustomer()
        {
            Customer c = new Customer();

            Console.WriteLine("Enter your full name:");
            c.Name = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            c.Address = Console.ReadLine();
            Console.WriteLine("Enter your phone:");
            c.Phone = Console.ReadLine();

            return c;
        }
    }
}