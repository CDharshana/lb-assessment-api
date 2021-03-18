using LoanApplication.Data;
using LoanApplication.Dto;
using LoanApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Services
{
    public interface ILoanService
    {
        Task<Response> AddLoan(CustomerLoanDto loanDto);
        Task<List<CustomerLoanDto>> GetAllLoanInfos();
    }
}
