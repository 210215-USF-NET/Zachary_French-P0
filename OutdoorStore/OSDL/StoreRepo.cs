using OSModels;
using System.Collections.Generic;
using System;

namespace OSDL
{
    public class StoreRepo : IStoreRepo
    {
        public List<Customer> GetCustomers()
        { 
            return new List<Customer>();
        }

        public Customer AddCustomer(Customer newCust){
            return new Customer();
        }

        public Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetProductCategories()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int num)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}