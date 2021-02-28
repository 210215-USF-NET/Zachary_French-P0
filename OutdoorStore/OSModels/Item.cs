using System;
using Serilog;

namespace OSModels
{
    public class Item
    {
        private int id;
        private int oid;
        private int pid;
        private int quantity;

        public int ID
        {
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
        public int OrderID{
            get{
                return oid;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                oid = value;
            }
        }
        public int ProductID
        {
            get{
                return pid;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                pid = value;
            }
        }
        public int Quantity
        {
            get{
                return quantity;
            } 
            set {
                if(value.Equals(null)) 
                {
                    ThrowNullException();
                }
                quantity = value;
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