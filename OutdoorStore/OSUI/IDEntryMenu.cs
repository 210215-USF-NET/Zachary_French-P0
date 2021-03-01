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
                        _repo.AddCustomer(newCustomer());
                        List<Customer> cList = _repo.GetCustomers();

                        foreach(Customer b in cList)
                        {
                            Console.WriteLine(b.ToString());
                        }
                        break;
                    case "2":
                        Console.WriteLine("Please enter yourname:");
                        string str = Console.ReadLine();
                        Customer foundCust = _repo.GetCustomerByName(str);

                        if (foundCust == null)
                        {
                            Console.WriteLine("No Customer by that name found, check your spelling and try again!");
                        }
                        else if ( foundCust.Name.Equals("Jerry Seinfeld"))
                        {
                            menu = new ManagerMenu(_repo);
                            menu.Start();
                        }
                        else
                        {
                            Console.WriteLine($"Customer record for {foundCust.Name} found.");
                            menu = new CustomerMenu(_repo, foundCust);
                            menu.Start();
                        }
                        break;
                    case "3":
                        //TODO: search for customer details by name
                        //temp debug code:
                        //     {menu = new CustomerMenu(_repo);
                        //     menu.Start();}
                        // break;
                    case "4":
                        List<Customer> newList = _repo.GetCustomers();

                        foreach(Customer b in newList)
                        {
                            Console.WriteLine(b.ToString());
                        }
                        break;
                    case "0":
                        stay = false;
                        Console.WriteLine("Thanks for shopping with REI!");
                        break;
                    default:
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

            return c;
        }
    }
}