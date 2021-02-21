using System;

namespace OSUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new IDEntryMenu();
            menu.Start();
        }
    }
}
