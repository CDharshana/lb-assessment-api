using LoanApplication.Data;
using LoanApplication.Dto;
using LoanApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Services
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService( ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<List<CustomerLoanDto>> GetAllLoanInfos()
        {
            var loanDtoList = new List<CustomerLoanDto>();
            
            var loanList =  _context.LoanInfos.Include(a => a.Customer).ToList();
            foreach (var loan in loanList)
            {
                var loanDto = new CustomerLoanDto();
                loanDto.Id = loan.Id;
                loanDto.FullName = loan.Customer.FullName;
                loanDto.NameWithInitial = loan.Customer.NameWithInitials;
                loanDto.Nic = loan.Customer.NIC;
                loanDto.Age = loan.Customer.Age;
                loanDto.Address = loan.Customer.Address;
                loanDto.Amount = loan.Amount;
                loanDto.InterestRate = loan.InterestRate;
                loanDto.LoanTerm = loan.LornTerm;
                loanDto.Installment = loan.Installment;

                loanDtoList.Add(loanDto);
            }

            return loanDtoList;
        }
        public async Task<Response>  AddLoan(CustomerLoanDto loanDto)
        {
            Customer customer = new Customer();
            var existingCustomer = _context.Customers.Where(a=>a.NIC == loanDto.Nic).FirstOrDefault();
            if (existingCustomer == null)
            {
               
                customer.Age = loanDto.Age;
                customer.Address = loanDto.Address;
                customer.FullName = loanDto.FullName;
                customer.NameWithInitials = loanDto.NameWithInitial;
                customer.NIC = loanDto.Nic;
                await _context.Customers.AddAsync(customer);
            }
            else
            {
                customer = existingCustomer;
            }
            LoanInfo loanInfo = new LoanInfo();
            loanInfo.CustomerId = customer.Id;
            loanInfo.Amount = loanDto.Amount;
            loanInfo.InterestRate = loanDto.InterestRate;
            loanInfo.LornTerm = loanDto.LoanTerm;
            loanInfo.Installment = loanDto.Installment;
            
            await _context.LoanInfos.AddAsync(loanInfo);
            await _context.SaveChangesAsync();
            return new Response { Status = "Success", Message = "User created successfully!" };
        }


    }
}
