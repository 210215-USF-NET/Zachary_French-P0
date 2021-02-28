using System.Collections.Generic;

namespace OSModels
{
    public class Order
    {
        private int orderID;
        private int customerID;
        private int locationID;
        
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

        //Convenience fields
        private string customerName;
        private List<Product> plist;
        private int total;
        public string CustomerName {
            get{
                return customerName;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                customerName = value;
            }
        }
        public List<Product> ProductList {
            get{
                return plist;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                plist = value;
            }
        }
        public int Total {
            get{
                return total;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();} 
                total = value;
            }
        }

        public override string ToString()
        {
            return $"Order#: {OrderID}";
        }
    }
}