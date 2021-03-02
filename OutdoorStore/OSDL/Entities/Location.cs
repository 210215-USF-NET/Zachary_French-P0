using System;
using System.Collections.Generic;

#nullable disable

namespace OSDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
