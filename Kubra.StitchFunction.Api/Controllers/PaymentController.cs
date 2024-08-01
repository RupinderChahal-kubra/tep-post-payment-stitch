using Kubra.Common.Stitch.Models;
using Kubra.Common.WebApi;
using Kubra.Common.WebApi.Errors;
using Kubra.StitchFunction.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kubra.StitchFunction.Api.Controllers
{
    /// <summary>
    /// PostPayment Controller
    /// </summary>
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorsCollectionDto), StatusCodes.Status503ServiceUnavailable)]
    [Produces("application/json")]
    [ApiController]
    [Route("/")]
    public class PaymentController : ApiControllerBase
    {
        private readonly IPostPaymentService _postPaymentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentController" /> class.
        /// </summary>
        /// <param name="postPaymentService"></param>
        public PaymentController(IPostPaymentService postPaymentService)
        {
            _postPaymentService = postPaymentService ?? throw new ArgumentNullException(nameof(postPaymentService));
        }

        /// <summary>
        /// Post payment to client web service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> PostPayment([FromBody]PaymentPostingRequest request)
        {
            var paymentPostedResponseRest = await _postPaymentService.PostPayment(request.MessageValue);

            if (paymentPostedResponseRest)
                return Ok("Payment Posted");
            else
                return StatusCode(500);
        }
    }
}
