using System;
using System.Collections.Generic;
using OSBL;
using OSModels;
using Model = OSModels;

namespace OSUI
{
    public class OrderListMenu : IMenu
    {
        private IStoreBL _repo;
        private Customer _customer;
        List<Order> orders;
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
                orders[i] = CalculateTotalPrice(orders[i]);
            }
        }

        public void Start()
        {
            do{
                foreach(Order o in orders)
                {
                    int num = o.OrderID;
                    Console.WriteLine(o.ToString());
                    foreach(Item i in items)
                    {
                        if(num == i.OrderID)
                        {
                            Console.WriteLine(_repo.GetProductByID(i.ProductID).ToStringTabbed());
                        }
                    }
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
                    // num = o.OrderID;
                    // Console.WriteLine(o.ToString());
                    // foreach(Item i in items)
                    // {
                    //     if(num == i.OrderID)
                    //     {
                    //         Console.WriteLine(_repo.GetProductByID(i.ProductID).ToStringTabbed());
                    //     }
                    // }
                }
            }
            return newlist;
        }
        
        private Order CalculateTotalPrice(Order o)
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
            
            o.TotalPrice = TotalCost;
            return o;
        }

        private void SortByDate()
        {
            orders.Sort()
        }
        private void SortByPrice()
        {
            
        }
    }
}