using System;
using System.Collections.Generic;
using Serilog;

namespace OSModels
{
    /// <summary>
    /// This class contains necessary properties and fields for customer info. 
    /// </summary>
    public class Customer
    {
        private string name;
        private List<Order> orderhistory;


        public string Name {
            get{
                return name;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                name = value;
            }
        }

        public List<Order> OrderHistory
        {
            get {
                return orderhistory;
            }
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                orderhistory = value;
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