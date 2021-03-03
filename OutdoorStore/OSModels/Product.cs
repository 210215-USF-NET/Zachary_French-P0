using System;
using Serilog;

namespace OSModels
{
    public class Product
    {
        private string productName;
        private int id;
        private string shortname;
        private int price;
        private ProductCategory category;
        private string description;

        public string Name {
            get{
                return productName;
            } 
            set {
                if(value.Equals(null))
                {
                    ThrowNullException();
                }
                productName = value;
            }
        }
        public int ID {
            get{
                return id;
            } 
            set {
                if(value.Equals(null))
                {
                    ThrowNullException();
                }
                id = value;
            }
        }
        public string ShortName {
            get{
                return shortname;
            } 
            set {
                if(value.Equals(null))
                {
                    ThrowNullException();
                }
                shortname = value;
            }
        }
        public int Price {
            get{
                return price;
            } 
            set {
                if(value.Equals(null))
                {
                    ThrowNullException();
                }
                price = value;
            }
        }
        public ProductCategory Category {
            get{
                return category;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                category = value;
            }
        }
        public string Description {
            get{
                return description;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                description = value;
            }
        }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Null value provided to Product method.");

            throw new Exception("Null value not valid");
        }

        public override string ToString()
        {
            return String.Format("{0,-70} {1,30}\n{2,-70} {3,30}\n\n{4,-89} {5,10}\n{6,-90} {7,10}\n= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =", 
                "Product Name:", "Price:", this.Name, this.Price, "Description:", "Product ID:", this.Description, this.ShortName);
        }

        public string ToStringTabbed()
        {
            return String.Format("\t{0,-70} {1,30}\n\t{2,-70} {3,30}\n\n\t{4,-90} {5,10}\n\t{6,-90} {7,10}\n\t= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =", 
                "Product Name:", "Price:", this.Name, this.Price, "Description:", "Product ID:", this.Description, this.ShortName);
        }
    }
}