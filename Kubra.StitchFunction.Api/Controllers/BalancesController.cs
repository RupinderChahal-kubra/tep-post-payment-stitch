using Kubra.Common.Stitch.Models;
using Kubra.Common.WebApi;
using Kubra.Common.WebApi.Errors;
using Kubra.StitchFunction.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kubra.StitchFunction.Api.Controllers
{
    /// <summary>
    /// Balances controller
    /// </summary>
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status503ServiceUnavailable)]
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class BalancesController : ApiControllerBase
    {
        private readonly IBalanceService _balanceService;

        /// <summary>
        /// Initialized a new instances of the <see cref="BalancesController" /> class.
        /// </summary>
        /// <param name="balanceService"></param>
        public BalancesController(IBalanceService balanceService)
        {
            _balanceService = balanceService ?? throw new ArgumentNullException(nameof(balanceService));
        }

        /// <summary>
        /// Get request to client web service for balance based on account number.
        /// </summary>
        /// <param name="balanceRequest"></param>
        /// <returns></returns>
        //This "accoundId" is important as the name is used to map to balanceRequest.AccountNumber.
        [HttpGet("{accountId}")]
        [ProducesResponseType(typeof(StitchBalanceResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<StitchBalanceResponse>> GetBalance(BalanceRequest balanceRequest)
        {
            var balance = await _balanceService.GetBalance(balanceRequest.AccountNumber);

            if (balance == null)
                return NoContent();

            return Ok(balance);
        }
    }
}
