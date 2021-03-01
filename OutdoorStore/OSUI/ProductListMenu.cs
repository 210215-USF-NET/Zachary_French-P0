using System;
using System.Collections.Generic;
using OSBL;
using OSModels;
using Serilog;
using Serilog.Sinks.File;

namespace OSUI
{
    public class ProductListMenu : IMenu
    {
        Location loc;
        ProductCategory pc;
        List<Product> plist;
        IStoreBL repo;

        public ProductListMenu(ProductCategory _pc, Location _loc, IStoreBL _repo)
        {
            pc = _pc;
            loc = _loc;
            plist = _repo.GetProductsByCategories(_pc);
        }

        public ProductListMenu(Location _loc, IStoreBL _repo)
        {
            loc = _loc;
            repo = _repo;
            plist = _repo.GetProducts();
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

        // private void SetProdList()
        // {
        //     List<Inventory> invList = repo.GetInventories();
        //     foreach()
        // }

        public void PrintListing(Product p)
        {
            Console.WriteLine(String.Format("{0,-80} {1,10}", "Product Name", "Price"));
            Console.WriteLine(String.Format("{0,-80} {1,10}\n", p.Name, p.Price));
            Console.WriteLine(String.Format("{0,-80} {1,8}", "Description", "Product ID"));
            Console.WriteLine(String.Format("{0,-82} {1,8}", p.Description, p.ShortName));
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
        }
    }
}