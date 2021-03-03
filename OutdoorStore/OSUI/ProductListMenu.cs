using System;
using System.Collections.Generic;
using OSBL;
using OSModels;
using System.Linq;
using Serilog;
using Serilog.Sinks.File;

namespace OSUI
{
    public class ProductListMenu : IMenu
    {
        Location loc;
        ProductCategory pc;
        List<Product> plist = new List<Product>();
        Customer customer;
        IStoreBL repo;

        public ProductListMenu(ProductCategory _pc, Location _loc, IStoreBL _repo, Customer _c)
        {
            pc = _pc;
            loc = _loc;
            customer = _c;
            repo = _repo;
            pList(loc, pc);  
        }

        public ProductListMenu(Location _loc, IStoreBL _repo, Customer _c)
        {
            loc = _loc;
            customer = _c;
            repo = _repo;
            pList(loc);
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();

            Console.WriteLine("\n= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            foreach(Product p in plist)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Please enter the Product ID for the product you'd like to add to your cart:\n(or enter \"0\" to go back)");
            string userInput = Console.ReadLine();

            foreach(Product p in plist)
            {
                if (userInput == p.ShortName)
                {
                    Console.WriteLine("How many would you like to buy?");
                    int num = int.Parse(Console.ReadLine()); //=================TODO:INPUT VALIDATION
                    repo.AddCart( new Cart {
                        ProductID = p.ID,
                        CustID = customer.ID,
                        LocID = loc.ID,
                        Quantity = num
                    });
                    if(num == 1)
                    {
                        Console.WriteLine("1 product added to cart.");
                    }
                    else{
                        Console.WriteLine($"{num} products added to cart.");
                    }
                    break;
                }
            }
            // if(!userInput.Equals("0"))
            // {
            //     Console.WriteLine("Invalid Product ID");
            // }
        }

        private void pList(Location _l)
        {
            List<Inventory> invList = repo.GetInventories();
            Product p;

            foreach(Inventory i in invList.Reverse<Inventory>())
            {
                if(i.LocationID == _l.ID)
                {
                    p = repo.GetProductByID(i.ProductID);
                    plist.Add(p);
                }
            }
        }
        private void pList(Location _l, ProductCategory _cat)
        {
            List<Inventory> invList = repo.GetInventories();
            Product p;

            foreach(Inventory i in invList.Reverse<Inventory>())
            {
                p = repo.GetProductByID(i.ProductID);
                if(i.LocationID == _l.ID && (int) p.Category == (int) (_cat+1))
                {
                    plist.Add(p);
                }
            }
        }

        public void PrintListing(Product p)
        {
            Console.WriteLine(String.Format("{0,-70} {1,30}", "Product Name", "Price"));
            Console.WriteLine(String.Format("{0,-70} {1,30}\n", p.Name, p.Price));
            Console.WriteLine(String.Format("{0,-90} {1,10}", "Description", "Product ID"));
            Console.WriteLine(String.Format("{0,-90} {1,10}", p.Description, p.ShortName));
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
        }
    }
}