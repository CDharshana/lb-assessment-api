using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Data
{
    public class LoanInfo 
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public double Amount { get; set; }

        public float InterestRate { get; set; }

        public int LornTerm { get; set; }

        public double Installment { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
