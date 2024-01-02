using System;
using System.Collections.Generic;

namespace MachineTest6._1.Models
{
    public partial class CustomerRegistration
    {
        public CustomerRegistration()
        {
            LoanDetails = new HashSet<LoanDetails>();
        }

        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<LoanDetails> LoanDetails { get; set; }
    }
}
