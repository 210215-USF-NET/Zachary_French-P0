using System;
using System.Collections.Generic;
using OSModels;
using OSDL;

namespace OSBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreRepo _repo;
        public StoreBL(IStoreRepo repo)
        {
            _repo = repo;
        }

        public void AddCustomer(Customer c)
        {
            _repo.AddCustomer(c);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        // public void DeleteCustomer(Customer CustForDeletion)
        // {
        //     throw new NotImplementedException();
        //     //_repo.DeleteHero(hero2BDeleted);
        // }

        public Customer GetCustomerByName(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return _repo.GetCustomerByName(name);
        }

        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product GetProductByID(int num)
        {
            return _repo.GetProductByID(num);
        }

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Product> GetProductsByCategories(ProductCategory pcat)
        {
            return _repo.GetProductsByCategories(pcat);
        }

        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }
    }
}