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
            throw new NotImplementedException();
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
    }
}