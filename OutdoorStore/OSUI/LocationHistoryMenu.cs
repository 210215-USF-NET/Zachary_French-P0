using System;
using System.Collections.Generic;
using System.Linq;
using OSBL;
using OSModels;
using Serilog;

namespace OSUI
{
    public class LocationHistoryMenu : IMenu
    {
        private IStoreBL _repo;
        private Location location;
        List<Order> orders;
        List<Product> products;
        List<Item> items;
        public List<Location> StorefrontList;

        public LocationHistoryMenu(IStoreBL repo)
        {
            _repo = repo;
            StorefrontList = _repo.GetLocations();
            items = _repo.GetItems();
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
            Boolean stay = true;

            do{
                Console.WriteLine("Which Order History would you like to check?");
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
                    Console.WriteLine("Invalid choice - please enter a valid Location.");
                }
            } while(stay);

            stay = true;
            orders = GetOrderHistory(_repo.GetOrders());
            orders = CalculateTotalPrice(orders);

            do
            {
                Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                foreach(Order o in orders)
                {
                    Console.WriteLine(o.ToString());
                    
                    Console.WriteLine($"Customer: {_repo.GetCustomers().FirstOrDefault(x => x.ID == o.CustomerID).Name}");
                    products = GetProductsForOrder(o);
                    foreach(Product p in products)
                    {
                        Console.WriteLine(p.ToStringTabbed());
                    }
                }

                Console.WriteLine("Sort by: [1] Date, [2] Cost - [0] Back");
                string str = Console.ReadLine();
                switch(str)
                {
                    case "1":
                        orders = OrdersByDate();
                        break;
                    case "2":
                        orders = OrdersByCost();
                        break;
                    case "0":
                        stay = false;
                        break;
                    default:
                        Log.Error("Invalid Navigation Selection (Sorted by something other than Date or Cost)");
                        Console.WriteLine("Invalid choice - Please enter \"1\" or \"2\".");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;
                }
            }
            while(stay);
        }
        private List<Order> GetOrderHistory(List<Order> _orders)
        {
            // int num;
            List<Order> newlist = new List<Order>();

            foreach(Order o in _orders)
            {
                if (o.LocationID == location.ID)
                {
                    newlist.Add(o);
                }
            }
            return newlist;
        }

        private List<Product> GetProductsForOrder(Order o)
        {
            products = new List<Product>();
            foreach(Item itm in items)
            {
                if(o.OrderID == itm.OrderID)
                {
                    products.Add(_repo.GetProductByID(itm.ProductID));
                }
            }

            return products;
        }
        
        private List<Order> CalculateTotalPrice(List<Order> oList)
        {
            for(int i = 0; i < oList.Count; i++)
            {
                int TotalCost = 0;

                foreach(Item itm in items)
                {
                    if(itm.OrderID == oList[i].OrderID)
                    {
                        TotalCost += _repo.GetProductByID(itm.ProductID).Price;
                    }
                }

                oList[i].TotalPrice = TotalCost;
            }
            
            return oList;
        }

        private List<Order> OrdersByDate()
        {
            return orders.OrderBy(h => h.Date).ToList();
        }
        private List<Order> OrdersByCost()
        {
            return orders.OrderBy(h => h.TotalPrice).ToList();
        }
    }
}