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
        private string address;


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

        public string Address {
            get{
                return address;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                address = value;
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
            return $"Customer: {name}\n\tHome: {address}";
        }
    }
}