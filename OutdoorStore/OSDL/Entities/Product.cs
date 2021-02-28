using System;
using System.Collections.Generic;

#nullable disable

namespace OSDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Description { get; set; }
        public int? Category { get; set; }
        public int Price { get; set; }

        public virtual ProductCategory CategoryNavigation { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
