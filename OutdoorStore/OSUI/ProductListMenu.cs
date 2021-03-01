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
        IStoreBL repo;

        public ProductListMenu(ProductCategory _pc, Location _loc, IStoreBL _repo)
        {
            pc = _pc;
            loc = _loc;
            pListCat(loc, pc);
        }

        public ProductListMenu(Location _loc, IStoreBL _repo)
        {
            loc = _loc;
            repo = _repo;
            pList(loc);
        }

        public void Start()
        {
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            foreach(Product p in plist)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Please enter the Product ID for the product you'd like to add to your cart:");
            string userInput = Console.ReadLine();
        }

        private void pList(Location _l)
        {
            List<Inventory> inventoryList = repo.GetInventories();
            Product p;

            foreach(Inventory i in inventoryList.Reverse<Inventory>())
            {
                if(i.LocationID == _l.ID)
                {
                    p = repo.GetProductByID(i.ProductID);
                    plist.Add(p);
                }
            }
        }
        private void pListCat(Location _l, ProductCategory _cat)
        {
            List<Inventory> invList = repo.GetInventories();
            Product p;

            foreach(Inventory i in invList.Reverse<Inventory>())
            {
                p = repo.GetProductByID(i.ProductID);
                Console.WriteLine(p.Name);
                if(i.LocationID == _l.ID && (int) p.Category == (int) _cat)
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