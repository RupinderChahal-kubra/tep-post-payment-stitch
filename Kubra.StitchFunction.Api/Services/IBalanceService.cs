using Kubra.Common.Stitch.Models;

namespace Kubra.StitchFunction.Api.Services
{
    /// <summary>
    /// Class containing functionality for interacting between Stitch and Client API
    /// </summary>
    public interface IBalanceService
    {
        /// <summary>
        /// Get the balance from a client hosted service
        /// </summary>
        /// <param name="accountNumber">Account number for the account to look up the balance for.</param>
        /// <returns>Returns a response object contraining a status code from the client web service request as well as the balance object.</returns>
        public Task<StitchBalanceResponse> GetBalance(string accountNumber);
    }
}
