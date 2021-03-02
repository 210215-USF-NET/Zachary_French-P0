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
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Product> GetProductsByCategories(ProductCategory pcat);
        Product GetProductByID(int num);
        List<Inventory> GetInventories();
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        void EmptyCart();
    }
}