using System;
using OSModels;
using Serilog;
using Serilog.Sinks.File;

namespace OSUI
{
    public class ProductListMenu : IMenu
    {
        public void Start()
        {
            //craete UI with all categories
        }

        public void Start(ProductCategory pc)
        {
            //create UI with just one category
            
            Product prod = new Product();
            prod.Name = "testName";
            prod.PID = "tName";
            prod.Price = 69.0;
            prod.Description = "a true meme";

            PrintListing(prod);
        }

        public void PrintListing(Product p)
        {
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine(String.Format("{0,-20} {1,7}\n\n", "Product Name", "Price"));
            Console.WriteLine(String.Format("{0,-8} {1,19}\n\n", "Product ID", "Description"));
        }
    }
}