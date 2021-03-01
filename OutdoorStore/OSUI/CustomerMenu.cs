using System;
using Serilog;
using OSBL;
using OSModels;
using System.Collections.Generic;

namespace OSUI
{
    public class CustomerMenu : IMenu
    {
        private IStoreBL _repo;
        private Customer _customer;
        public CustomerMenu(IStoreBL repo, Customer c){
            _repo = repo;
            _customer = c;
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
                Console.WriteLine("=================");
                Console.WriteLine("  Welcome back!");
                Console.WriteLine("=================");
                Console.WriteLine("");
                Console.WriteLine("Navigate by entering one of the following:");
                Console.WriteLine("[1] Start Shopping");
                Console.WriteLine("[2] View Order History");
                Console.WriteLine("[0] Back");
                string custInput = Console.ReadLine();

                switch(custInput)
                {
                    case "1":
                    menu = new StoreSelectMenu(_repo);
                    menu.Start();
                    break;
                case "2":
                    // menu = new OrderListMenu(_repo);
                    // menu.Start();
                    // break;
                    GetOrderHistory();
                    Console.WriteLine("Press \"Enter\" to continue.");
                    Console.ReadLine();
                    break;
                case "0":
                    stay = false;
                    break;
                default:
                    Log.Error("Invalid navigation selection (not 'start shopping' or 'order history')");
                    Console.WriteLine("Invalid choice - Please enter \"1\" or \"2\".");
                    Console.WriteLine("Press \"Enter\" to continue.");
                    Console.ReadLine();
                    break;
                }
            }
            while(stay);
        }

        private void GetOrderHistory()
        {
            int num;
            List<Order> orders = _repo.GetOrders();
            List<Item> items = _repo.GetItems();
            foreach(Order o in orders)
            {
                if (o.CustomerID == _customer.ID)
                {
                    num = o.OrderID;
                    Console.WriteLine(o.ToString());
                    foreach(Item i in items)
                    {
                        if(num == i.OrderID)
                        {
                            Console.WriteLine(_repo.GetProductByID(i.ProductID).ToString());
                        } 
                    }
                }
            }
        }
    }
}