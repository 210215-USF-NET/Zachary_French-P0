using System;
using OSBL;
using Model = OSModels;

namespace OSUI
{
    public class OrderListMenu : IMenu
    {
        private IStoreBL _repo;
        public OrderListMenu(IStoreBL repo)
        {
            _repo = repo;
        }

        public void Start()
        {
            
        }
    }
}