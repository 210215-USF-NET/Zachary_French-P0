using System;
using OSBL;

namespace OSUI
{
    public class ManagerMenu : IMenu
    {
        IStoreBL repo;
        public ManagerMenu(IStoreBL _repo)
        {
            repo = _repo;
        }

        public void Start()
        {
                Console.WriteLine("");
                Console.WriteLine("================");
                Console.WriteLine("  Manager Menu");
                Console.WriteLine("================");
                Console.WriteLine("");
                Console.WriteLine("Navigate by entering one of the following:");
                Console.WriteLine("[1] View each location's Order History");
                Console.WriteLine("[2] View each location's current Inventory");
                Console.WriteLine("[3] Restock an item");
                Console.WriteLine("[0] Back");
        }
    }
}