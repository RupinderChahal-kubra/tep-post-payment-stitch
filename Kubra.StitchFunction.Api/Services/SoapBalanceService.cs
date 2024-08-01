using Kubra.Common.Helpers;
using Kubra.Common.Stitch.Models;
using MockClientSOAPService;
using BalanceRequest = MockClientSOAPService.BalanceRequest;

namespace Kubra.StitchFunction.Api.Services
{
    /// <inheritdoc />
    public class SoapBalanceService : IBalanceService
    {
        private readonly ISoapService _soapService;
        /// <summary>
        /// Constructor for ISoapService dependency injection
        /// </summary>
        /// <param name="soapService"></param>
        public SoapBalanceService(ISoapService soapService)
        {
            _soapService = soapService ?? throw new ArgumentNullException(nameof(soapService));
        }
        /// <inheritdoc />
        public async Task<StitchBalanceResponse> GetBalance(string accountNumber)
        {
            using var activity = ActivitySourceHelper.ApplicationActivitySource.StartActivity(this);
            var response = new StitchBalanceResponse();
            var balanceResponse = await _soapService.BalanceAsync(new BalanceRequest()
            {
                Body = new BalanceRequestBody
                {
                    accountNumber = Convert.ToInt32(accountNumber)
                }
            });

            //assign whatever values are coming from the api response to the response object that can map to StitchBalanceResponse
            //AmountDue, DueDate and LastUpdatedAtSource are minimum required. 
            //LastUpdatedAtSource can be current datetime if not provided(default value)
            if (balanceResponse?.Body?.BalanceResult is not null)
            {
                response.CurrentAmountDue = balanceResponse.Body.BalanceResult.AmountDue;
                response.DueDate = balanceResponse.Body.BalanceResult.DueDate;

                return response;
            }
            else
                throw new ArgumentNullException();
        }
    }
}