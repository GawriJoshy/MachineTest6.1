using MachineTest6._1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest6._1.Repository
{
    public interface ILoanRepository
    {
        Task<List<LoanDetails>> GetAllLoan();// asychronnous declaration
        Task<int> AddLoan(LoanDetails loan);
        Task<LoanDetails> UpdateLoan(LoanDetails loan);
       Task<LoanDetails> GetLoanById(int? id);
        Task<int> DeleteLoan(int? id);
    }
}
