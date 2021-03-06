using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Data
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string NameWithInitials { get; set; }

        public int Age { get; set; }

        public string NIC { get; set; }

        public string Address { get; set; }
        public virtual ICollection<LoanInfo> LoanInfoList { get; set; }
    }
}
