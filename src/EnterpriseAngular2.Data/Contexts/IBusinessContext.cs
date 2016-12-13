using EnterpriseAngular2.Data.Models;
using System.Collections.Generic;

namespace EnterpriseAngular2.Data.Contexts
{
    public interface IBusinessContext
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        ICollection<Customer> GetCustomerList();
    }
}
