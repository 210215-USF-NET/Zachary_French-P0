using System;
using Serilog;

namespace OSModels
{
    public class Product
    {
        private string productName;
        private string pID;
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
        public string PID {
            get{
                return pID;
            } 
            set {
                if(value.Equals(null))
                {
                    ThrowNullException();
                }
                pID = value;
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
    }
}