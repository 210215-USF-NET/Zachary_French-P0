using System;
using OSModels;
using Serilog;
using Serilog.Sinks.File;

namespace OSUI
{
    public class ProductListMenu : IMenu
    {
        Location loc;
        ProductCategory pc;

        public ProductListMenu(ProductCategory _pc, Location _loc)
        {
            pc = _pc;
            loc = _loc;
        }

        public ProductListMenu(Location _loc)
        {
            loc = _loc;
        }

        public void Start()
        {
            Product prod = new Product();
            prod.Name = "testName";
            prod.PID = "tName";
            prod.Price = 69;
            prod.Description = "a true meme";

            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            PrintListing(prod);

            Console.WriteLine("Please enter the Product ID for the product you'd like to add to your cart:");
            string userInput = Console.ReadLine();

            // foreach(Product p in)
        }

        public void PrintListing(Product p)
        {
            Console.WriteLine(String.Format("{0,-53} {1,7}", "Product Name", "Price"));
            Console.WriteLine(String.Format("{0,-53} {1,7}\n", p.Name, p.Price));
            Console.WriteLine(String.Format("{0,-8} {1,50}", "Product ID", "Description"));
            Console.WriteLine(String.Format("{0,-8} {1,52}", p.PID, p.Description));
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
        }
    }
}