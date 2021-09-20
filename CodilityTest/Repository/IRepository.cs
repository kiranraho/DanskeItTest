using CodilityTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodilityTest.Data
{
    public interface IRepository
    {
        List<CustomerInfo> GetAllCustomers();
        CustomerInfo GetCustomerByName(string firstName, string surName);
        CustomerInfo CreateNewCustomer();
    }
}
