using System;
using System.Collections.Generic;
using System.Linq;
using OSBL;
using OSModels;
using Serilog;
using Model = OSModels;

namespace OSUI
{
    public class OrderListMenu : IMenu
    {
        private IStoreBL _repo;
        private Customer _customer;
        List<Order> orders;
        List<Product> products;
        List<Item> items;
        Boolean stay = true;

        public OrderListMenu(IStoreBL repo, Customer c)
        {
            _repo = repo;
            _customer = c;
            orders = GetOrderHistory(_repo.GetOrders());
            items = _repo.GetItems();

            for(int i = 0; i < orders.Count; i++)
            {
                orders[i].TotalPrice = CalculateTotalPrice(orders[i]);
            }
        }

        public void Start()
        {
            do{
                foreach(Order o in orders)
                {
                    Console.WriteLine(o.ToString());
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
                        Log.Error("Invalid navigation selection (Sorted by something other than Date or Cost)");
                        Console.WriteLine("Invalid choice - Please enter \"1\" or \"2\".");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;
                }
            } while(stay);
        }

        private List<Order> GetOrderHistory(List<Order> _orders)
        {
            // int num;
            List<Order> newlist = new List<Order>();

            foreach(Order o in _orders)
            {
                if (o.CustomerID == _customer.ID)
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
        
        private int CalculateTotalPrice(Order o)
        {
            int id = o.OrderID;
            int TotalCost = 0;

            foreach(Item i in items)
            {
                if(i.OrderID == id)
                {
                    TotalCost += _repo.GetProductByID(i.ProductID).Price;
                }
            }
            
            return TotalCost;
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