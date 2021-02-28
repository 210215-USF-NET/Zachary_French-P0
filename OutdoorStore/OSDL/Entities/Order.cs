using System;
using System.Collections.Generic;

#nullable disable

namespace OSDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? CustId { get; set; }
        public int? LocId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Location Loc { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
