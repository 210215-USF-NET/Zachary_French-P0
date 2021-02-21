namespace OSModels
{
    public class Product
    {
        private string productName;
        private double price;
        private ProductCategory category;
        public string ProductName {
            get{
                return productName;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                productName = value;
            }
        }
        public double Price {
            get{
                return price;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                price = value;
            }
        }
        public ProductCategory Category {
            get{
                return category;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                category = value;
            }
        }
    }
}