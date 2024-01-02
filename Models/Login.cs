using System;
using System.Collections.Generic;

namespace MachineTest6._1.Models
{
    public partial class Login
    {
        public Login()
        {
            CustomerRegistration = new HashSet<CustomerRegistration>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CustomerRegistration> CustomerRegistration { get; set; }
    }
}
