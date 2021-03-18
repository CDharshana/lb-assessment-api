using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Dto
{
    public class CustomerLoanDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string NameWithInitial { get; set; }

        public int Age { get; set; }

        public string Nic { get; set; }

        public string Address { get; set; }

        public double Amount { get; set; }

        public float InterestRate { get; set; }

        public int LoanTerm { get; set; }

        public double Installment { get; set; }
    }
}
