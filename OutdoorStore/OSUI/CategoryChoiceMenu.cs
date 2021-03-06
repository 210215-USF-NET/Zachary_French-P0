using System;
using Serilog;
using OSModels;
using System.Collections.Generic;
using OSBL;

namespace OSUI
{
    public class CategoryChoiceMenu : IMenu
    {
        private Location loc;
        private ProductCategory pc;
        private IStoreBL _repo;
        Customer _c;

        public CategoryChoiceMenu(Location _loc, IStoreBL repo, Customer c)
        {
            loc = _loc;
            _repo = repo;
            _c = c;
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../SystemLog.json").CreateLogger();
            Boolean stay = true;
            IMenu menu;
            _repo.EmptyCart();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("=================");
                Console.WriteLine("  Select what category of items to browse:");
                Console.WriteLine("=================");
                Console.WriteLine("");
                Console.WriteLine("[1] Backpacks");
                Console.WriteLine("[2] Camping");
                Console.WriteLine("[3] Climbing");
                Console.WriteLine("[4] Clothing");
                Console.WriteLine("[5] Shoes");
                Console.WriteLine("[6] All Categories");
                Console.WriteLine("[0] Back");
                string userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "1":
                        pc = ProductCategory.Backpacks;
                        menu = new ProductListMenu(pc, loc, _repo, _c);
                        menu.Start();
                        break;
                    case "2":
                        pc = ProductCategory.Camping;
                        menu = new ProductListMenu(pc, loc, _repo, _c);
                        menu.Start();
                        break;
                    case "3":
                        pc = ProductCategory.Climbing;
                        menu = new ProductListMenu(pc, loc, _repo, _c);
                        menu.Start();
                        break;
                    case "4":
                        pc = ProductCategory.Clothing;
                        menu = new ProductListMenu(pc, loc, _repo, _c);
                        menu.Start();
                        break;
                    case "5":
                        pc = ProductCategory.Shoes;
                        menu = new ProductListMenu(pc, loc, _repo, _c);
                        menu.Start();
                        break;
                    case "6":
                        menu = new ProductListMenu(loc, _repo, _c);
                        menu.Start();
                        break;
                    case "0":
                        stay = false;
                        Checkout();
                        break;
                    default:
                        Log.Error("Invalid product category selection");
                        Console.WriteLine("Invalid choice - Please enter a value 1-5, or 0 to go back.");
                        Console.WriteLine("Press \"Enter\" to continue.");
                        Console.ReadLine();
                        break;

                }
            }
            while(stay);
        }

        private void Checkout()
        {
            Boolean checkoutFlag = true;
            do{
                Console.WriteLine("================================================================");
                Console.WriteLine("Would you like to check out with your current cart, or empty it?");
                Console.WriteLine("================================================================");
                Console.WriteLine("[1] Show my Cart");
                Console.WriteLine("[3] Checkout");
                Console.WriteLine("[0] Empty and go Back");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        List<Cart> customerCart = _repo.GetCarts();
                        int price = 0;
                        foreach(Cart c in customerCart)
                        {
                            Product p = _repo.GetProductByID(c.ProductID);
                            price += p.Price;
                            Console.WriteLine(p.ToString());
                        }
                        break;
                    case "3":
                        customerCart = _repo.GetCarts();
                        Order o = new Order()
                        {
                            CustomerID = _c.ID,
                            LocationID = loc.ID,
                            Date = DateTime.Now,
                        };
                        _repo.AddOrder(o);
                        Log.Information("Order record added to database.");

                        foreach(Cart c in customerCart)
                        {
                            Item i = new Item() 
                            {
                                OrderID = (_repo.GetOrders().Count),
                                ProductID = c.ProductID,
                                Quantity = c.Quantity
                            };
                            _repo.AddItem(i);
                            Log.Information("OrderItem record added to database.");
                        }
                        _repo.EmptyCart();
                        checkoutFlag = false;
                        break;
                    case "0":
                        _repo.EmptyCart();
                        checkoutFlag = false;
                        break;
                }
            }
            while(checkoutFlag);
        }
    }
}