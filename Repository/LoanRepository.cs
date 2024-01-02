using MachineTest6._1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest6._1.Repository
{
    public class LoanRepository : ILoanRepository
    {

        private readonly MachineTest61Context _context;
        public LoanRepository(MachineTest61Context context)
        {
            _context = context;
        }
        public async Task<List<LoanDetails>> GetAllLoan()
        {
            if (_context != null)
            {
                return await _context.LoanDetails.ToListAsync();
            }
            return null;
        }

        #region
        public async Task<int> AddLoan(LoanDetails loan)
        {
            if (_context != null)
            {
                await _context.LoanDetails.AddAsync(loan);
                await _context.SaveChangesAsync();
                return loan.LoanId;
            }
            return 0;// becu here int need to return so 0 given
        }
        #endregion

        #region update customer
        public async Task<LoanDetails> UpdateLoan(LoanDetails loan)
        {
            if (_context != null)
            {
                _context.Entry(loan).State = EntityState.Modified;
                _context.LoanDetails.Update(loan);
                await _context.SaveChangesAsync();
                return loan;
            }
            return null;
        }
        #endregion

        #region GetCustomerById

        public async Task<LoanDetails> GetLoanById(int? id)
        {
            if (_context != null)
            {
                var loan = await _context.LoanDetails.FindAsync(id);
                return loan;
            }
            return null;
        }

        public Task<int> DeleteLoan(int? id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}