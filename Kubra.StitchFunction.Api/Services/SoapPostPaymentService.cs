using Kubra.Common.Helpers;
using Kubra.Common.Stitch.Models;
using MockClientSOAPService;

namespace Kubra.StitchFunction.Api.Services
{
    /// <inheritdoc />
    public class SoapPostPaymentService : IPostPaymentService
    {
        private readonly ISoapService _soapService;

        /// <summary>
        /// Constructor for ISoapService dependency injection
        /// </summary>
        /// <param name="soapService"></param>
        public SoapPostPaymentService(ISoapService soapService)
        {
            _soapService = soapService ?? throw new ArgumentNullException(nameof(soapService));
        }
        /// <inheritdoc />

        public async Task<bool> PostPayment(MessageValue postPaymentRequest)
        {
            using var activity = ActivitySourceHelper.ApplicationActivitySource.StartActivity(this);
            var postPaymentResponse = await _soapService.PostPaymentAsync(new PostPaymentRequest
            {
                Body = new PostPaymentRequestBody
                {
                    request = new PaymentPostRequest
                    {
                        PaymentId = postPaymentRequest.PaymentId
                    }
                }
            });

            if (postPaymentResponse?.Body?.PostPaymentResult is not null)
                return true;
            else
                throw new ArgumentNullException();
        }
    }
}
