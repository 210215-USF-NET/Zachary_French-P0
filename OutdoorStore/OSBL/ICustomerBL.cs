using System.Collections.Generic;
using OSModels;

namespace OSBL
{
    public interface ICustomerBL
    {
         List<Customer> GetCustomers();
         void AddCustomer();
    }
}