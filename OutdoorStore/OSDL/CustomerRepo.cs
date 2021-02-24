namespace OSDL
{
    public class CustomerRepo : ICustomerRepo
    {
        public List<Customer> GetCustomers()
        { 
            return new List<Customer>();
        }

        public Customer AddCustomer(Customer newCust){
            return new Customer();
        }
    }
}