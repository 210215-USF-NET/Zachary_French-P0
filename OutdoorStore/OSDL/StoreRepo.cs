using OSModels;
using System.Collections.Generic;
using System;

namespace OSDL
{
    public class StoreRepo : IStoreRepo
    {
        public List<Customer> GetCustomers()
        { 
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Customer newCust){
            throw new NotImplementedException();
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

        public List<Item> GetItems()
        {
            throw new NotImplementedException();
        }
        public Item AddItem(Item newItem)
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

        public Product GetProductByID(int num)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategories(ProductCategory pcat)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventories()
        {
            throw new NotImplementedException();
        }

        public Cart AddCart(Cart newCart)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetCarts()
        {
            throw new NotImplementedException();
        }
    }
}