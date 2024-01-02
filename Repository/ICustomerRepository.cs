using MachineTest6._1.Models;
using MachineTest6._1.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest6._1.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerRegistration>> GetAllCustomer();// asychronnous declaration
        Task<int> AddCustomer(CustomerRegistration customer);
        Task<CustomerRegistration> UpdateCustomer(CustomerRegistration customer);
        Task<CustomerRegistration> GetCustomerById(int? id);
        Task<int> DeleteCustomer(int? id);

        Task<List<CustomerLoan>> GetViewModelCustomerLoan();




    }
}
