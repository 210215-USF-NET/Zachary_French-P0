using System;
using System.Collections.Generic;

namespace OSModels
{
    public class Order
    {
        private int orderID;
        private int customerID;
        private int locationID;
        private DateTime date;
        private int price;
        
        public int OrderID {
            get{
                return orderID;
            } 
            set {
                if(value.Equals(null)) 
                    {throw new System.Exception();} 
                orderID = value;
            }
        }
        public int CustomerID {
            get{
                return customerID;
            } 
            set {
                if(value.Equals(null)) 
                    {throw new System.Exception();} 
                customerID = value;
            }
        }
        public int LocationID {
            get{
                return locationID;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                locationID = value;
            }
        }
        public DateTime Date {
            get{
                return date;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                date = value;
            }
        }
        public int TotalPrice {
            get{
                return price;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                price = value;
            }
        }

        public void AddToTotalPrice(Product product)
        {
            this.TotalPrice += product.Price;
        }

        public override string ToString()
        {
            return $"Order#: {OrderID}\nTotal Cost: {TotalPrice}";
        }
    }
}