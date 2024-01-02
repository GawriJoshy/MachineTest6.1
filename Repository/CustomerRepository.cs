using MachineTest6._1.Models;
using MachineTest6._1.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MachineTest6._1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MachineTest61Context _context;
        public CustomerRepository(MachineTest61Context context)
        {
            _context = context;
        }
        #region
        public async Task<List<CustomerRegistration>> GetAllCustomer()
        {
            if (_context != null)
            {
                return await _context.CustomerRegistration.ToListAsync();
            }
            return null;
        }
        #endregion

        #region
        public async Task<int> AddCustomer(CustomerRegistration customer)
        {
            if (_context != null)
            {
                await _context.CustomerRegistration.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer.CId;
            }
            return 0;// becu here int need to return so 0 given
        }
        #endregion
        #region update customer
        public async Task<CustomerRegistration> UpdateCustomer(CustomerRegistration customer)
        {
            if (_context != null)
            {
                _context.Entry(customer).State = EntityState.Modified;
                _context.CustomerRegistration.Update(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            return null;
        }
        #endregion

        #region GetCustomerById

        public async Task<CustomerRegistration> GetCustomerById(int? id)
        {
            if(_context != null)
            {
                var customer = await _context.CustomerRegistration.FindAsync(id);
                return customer;
            }
            return null;
        }

        #endregion

        #region delete an customer

        public async Task<int> DeleteCustomer(int? id)
        {
            if (_context != null)
            {
                var customer = await _context.CustomerRegistration.FirstOrDefaultAsync(emp => emp.CId == id);
                if (customer != null)
                {
                    //delete
                    _context.CustomerRegistration.Remove(customer);
                    //commit
                    await _context.SaveChangesAsync();
                    return customer.CId;
                }

            }
            return 0;

        }
        #endregion

        #region get ViewModel Employee

        public async Task<List<CustomerLoan>> GetViewModelCustomerLoan()
        {
            if (_context != null)
            {
                //linq
                return await (from c in _context.CustomerRegistration // MANUALLY IMPORT LINQ
                              from l in _context.LoanDetails
                              where c.CId == l.LoanId
                              select new CustomerLoan
                              {
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,
                                  Address = c.Address,
                                  PhoneNumber = c.PhoneNumber,
                                  
                                  LoanType = l.LoanType,
                                  LoanAmount = l.LoanAmount,
                                  AccountNumber = l.AccountNumber,
                                  InterestRate = l.InterestRate,
                                  Status = l.Status
                              }).ToListAsync();

            }
            return null;
        }

        

        #endregion



    }
}
