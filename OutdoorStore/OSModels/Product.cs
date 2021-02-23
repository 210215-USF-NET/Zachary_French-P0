using System;
using Serilog;

namespace OSModels
{
    public class Product
    {
        private string productName;
        private string pID;
        private double price;
        private ProductCategory category;
        private string description;

        public string Name {
            get{
                return productName;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                productName = value;
            }
        }
        public string PID {
            get{
                return pID;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                pID = value;
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

            try
            {
                throw new Exception("Null value not valid");
            }
            catch (System.Exception)
            {
                Log.Error("Null value provided to Product method.");
            }
        }
    }
}