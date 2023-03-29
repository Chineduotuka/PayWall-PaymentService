using Microsoft.AspNetCore.Mvc;
using Payment.Core.DTOs.BeneficiaryDto;
using Payment.Core.DTOs.PaystackDtos.BankDtos;
using Payment.Core.Interfaces;
using System.Net;
using System.Net.Mime;

namespace Payment.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        /// <summary>
        /// add beneficiary
        /// </summary>
        /// <param name="beneficiaryRequestDto"></param>
        /// <param name="walletId">Data transfer object containing the request parameters</param>
        /// <returns></returns>
        [HttpPost("add-beneficiary/{walletId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBeneficiary([FromBody]BeneficiaryRequestDto beneficiaryRequestDto, [FromRoute]string walletId)
        {
            var result = await _bankAccountService.AddBeneficiaryAsync(beneficiaryRequestDto, walletId);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Returns List of Beneficiaries in Pages.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="walletId"></param>

        /// <returns></returns>
        [HttpGet("beneficiary-list/{walletId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBeneficiariesAsync(int pageNumber, int pageSize, string walletId)
        {
            var response = await _bankAccountService.GetAllBeneficiariesAsync(pageNumber, pageSize, walletId);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// delete beneficiary
        /// </summary>
        /// <param name="AccountNumber"></param>
        /// <returns></returns>
        [HttpDelete("delete-beneficiary/{walletId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletBeneficiary(string AccountNumber, string walletId)
        {
            var response = await _bankAccountService.DeleteBeneficiary(AccountNumber, walletId);
            return StatusCode((int)HttpStatusCode.OK, response);
        }

        /// <summary>
        /// verify Account Number
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("verify-account-number")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VerifyAccountNumber(VerifyAccountRequestDto request)
        {
            var response = await _bankAccountService.VerifyAccountNumber(request);
            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }  
}
