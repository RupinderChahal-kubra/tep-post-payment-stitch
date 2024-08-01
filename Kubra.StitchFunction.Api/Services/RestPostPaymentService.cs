using System.Net;
using Kubra.Common.Helpers;
using Kubra.Common.Stitch.Models;
using Kubra.StitchFunction.Api.Config;
namespace Kubra.StitchFunction.Api.Services
{
    /// <inheritdoc />
    public class RestPostPaymentService : IPostPaymentService
    {
        readonly IHttpClientFactory _httpClientFactory;
        private readonly IClientConfigProvider _configProvider;

        /// <summary>
        /// Constructor for DI.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="configProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RestPostPaymentService(IHttpClientFactory httpClientFactory, IClientConfigProvider configProvider)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configProvider = configProvider ?? throw new ArgumentNullException(nameof(configProvider));
        }
        /// <inheritdoc />
        public async Task<bool> PostPayment(MessageValue postPaymentRequest)
        {
            using var activity = ActivitySourceHelper.ApplicationActivitySource.StartActivity(this);
            var clientConfig = _configProvider.GetConfig();

            using var client = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, $"{clientConfig.Result.WebServiceUrl}");
            request.Content = JsonContent.Create(postPaymentRequest);
            using var clientResponse = await client.SendAsync(request);

            if (clientResponse.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException("Unexpected response from client");

            return true;
        }
    }
}
