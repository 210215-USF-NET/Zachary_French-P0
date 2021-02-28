using OSModels;
using System.Collections.Generic;

namespace OSDL
{
    public interface IStoreRepo
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCust);
        Customer GetCustomerByName(string name);
        Order AddOrder(Order order);
        List<Order> GetOrders();
        List<Location> GetLocations();
        List<Product> GetProducts();
        // List<ProductCategory> GetProductCategories();
    }
}