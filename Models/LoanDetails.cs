using System;
using System.Collections.Generic;

namespace MachineTest6._1.Models
{
    public partial class LoanDetails
    {
        public int LoanId { get; set; }
        public string LoanType { get; set; }
        public decimal? AccountNumber { get; set; }
        public string Branch { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Status { get; set; }
        public int? CId { get; set; }

        public virtual CustomerRegistration C { get; set; }
    }
}
