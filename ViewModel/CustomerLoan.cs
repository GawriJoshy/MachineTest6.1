using System;

namespace MachineTest6._1.ViewModel
{
    public class CustomerLoan
    {
        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public string LoanType { get; set; }
        public decimal? AccountNumber { get; set; }
        
        public decimal? LoanAmount { get; set; }
        public decimal? InterestRate { get; set; }
       
        public string Status { get; set; }
    }
}
