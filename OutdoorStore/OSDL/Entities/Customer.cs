using System;
using System.Collections.Generic;

#nullable disable

namespace OSDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
