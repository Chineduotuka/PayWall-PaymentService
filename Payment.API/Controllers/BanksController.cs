using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Core.Interfaces;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {

        private readonly IBankService _bankService;
        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet("get-all-banks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> GetAllBanks()
        {
            var result = await _bankService.GetAllBanksAsync();
            return StatusCode(result.StatusCode, result);
        }
    }
}
