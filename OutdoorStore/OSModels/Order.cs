namespace OSModels
{
    public class Order
    {
        private string customerName;
        private string location;
        private double total;
        public string CustomerName {
            get{
                return customerName;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                customerName = value;
            }
        }
        public string Location {
            get{
                return location;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                location = value;
            }
        }
        public double Total {
            get{
                return total;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                total = value;
            }
        }
    }
}