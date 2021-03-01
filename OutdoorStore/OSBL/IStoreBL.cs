using System.Collections.Generic;
using OSModels;

namespace OSBL
{
    public interface IStoreBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer c);
        Customer GetCustomerByName(string name);
        void AddOrder(Order order);
        List<Order> GetOrders();
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Product> GetProductsByCategories(ProductCategory pcat);
        Product GetProductByID(int num);
        List<Item> GetItems();
        List<Inventory> GetInventories();
    }
}