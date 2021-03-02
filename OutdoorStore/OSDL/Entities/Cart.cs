using System;
using System.Collections.Generic;

#nullable disable

namespace OSDL.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int CustId { get; set; }
        public int LocId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Location Loc { get; set; }
        public virtual Product Product { get; set; }
    }
}
