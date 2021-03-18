using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApplication.Data;
using LoanApplication.Dto;
using LoanApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }


        [HttpGet]
        [Route("get-all-loans")]
        public async Task<IActionResult> getAllLoans()
        {
            var response = await _loanService.GetAllLoanInfos();
            if (response.Count == 0)
            {
                return NoContent();
            }
            return Ok(response);
        }


        [HttpPost]
        [Route("create-loan-request")]
        public async Task<IActionResult> createLoanRequest([FromBody] CustomerLoanDto model)
        {
            var response =await _loanService.AddLoan(model);

            return Ok(response);
        }
    }
}