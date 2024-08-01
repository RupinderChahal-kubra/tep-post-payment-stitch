using Kubra.Common.Stitch.Models;
namespace Kubra.StitchFunction.Api.Services
{
    /// <summary>
    /// Class containing functionality for interacting between Stitch and Client API
    /// </summary>
    public interface IPostPaymentService
    {
        /// <summary>
        /// Post payment data to client REST service
        /// </summary>
        /// <param name="postPaymentRequest"></param>
        /// <returns></returns>
        public Task<bool> PostPayment(MessageValue postPaymentRequest);
    }
}
