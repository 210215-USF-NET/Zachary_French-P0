using System;
using Serilog;
using OSModels;
using System.Collections.Generic;

namespace OSUI
{
    public class CategoryChoiceMenu : IMenu
    {
        public Location loc;
        public ProductCategory pc;

        public CategoryChoiceMenu(Location _loc)
        {
            loc = _loc;
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true;
            IMenu menu;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("=================");
                Console.WriteLine("  Select what category of items to browse:");
                Console.WriteLine("=================");
                Console.WriteLine("");
                Console.WriteLine("[1] Backpacks");
                Console.WriteLine("[2] Camping_Gear");
                Console.WriteLine("[3] Climbing_Gear");
                Console.WriteLine("[4] Clothing");
                Console.WriteLine("[5] Shoes");
                Console.WriteLine("[6] All Categories");
                Console.WriteLine("[0] Back");
                string userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "1":
                        //TODO:launch product menu
                        pc = ProductCategory.Backpacks;
                        menu = new ProductListMenu(pc, loc);
                        menu.Start();
                        break;
                    case "2":
                        pc = ProductCategory.Camping_Gear;
                        menu = new ProductListMenu(pc, loc);
                        menu.Start();
                        break;
                    case "3":
                        pc = ProductCategory.Climbing_Gear;
                        menu = new ProductListMenu(pc, loc);
                        menu.Start();
                        break;
                    case "4":
                        pc = ProductCategory.Clothing;
                        menu = new ProductListMenu(pc, loc);
                        menu.Start();
                        break;
                    case "5":
                        pc = ProductCategory.Shoes;
                        menu = new ProductListMenu(pc, loc);
                        menu.Start();
                        break;
                    case "6":
                        menu = new ProductListMenu(loc);
                        menu.Start();
                        break;
                    case "0":
                        stay = false;
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
    }
}