namespace OSDL
{
    public interface ICustomerRepo
    {
         List<Customer> GetCustomers();

         Customer AddCustomer(Customer newCust);
    }
}