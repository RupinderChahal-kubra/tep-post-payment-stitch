using System.Net;
using Kubra.StitchFunction.Api.Config;
using System.Text.Json;
using Kubra.Common;
using Kubra.Common.Stitch.Models;
using Kubra.Common.Helpers;

namespace Kubra.StitchFunction.Api.Services
{
    /// <inheritdoc />
    public class RestBalanceService : IBalanceService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IClientConfigProvider _configProvider;
        private readonly ILogger<RestBalanceService> _logger = Log.CreateLogger<RestBalanceService>();
        /// <summary>
        /// Constructor for DI.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="configProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RestBalanceService(IHttpClientFactory httpClientFactory, IClientConfigProvider configProvider)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configProvider = configProvider ?? throw new ArgumentNullException(nameof(configProvider));
        }

        /// <inheritdoc />
        public async Task<StitchBalanceResponse> GetBalance(string accountNumber)
        {
            using var activity = ActivitySourceHelper.ApplicationActivitySource.StartActivity(this);
            var clientConfig = _configProvider.GetConfig();

            using var client = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{clientConfig.Result.WebServiceUrl}/{accountNumber}");
            using var clientResponse = await client.SendAsync(request);

            switch(clientResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    var content = await clientResponse.Content.ReadAsStringAsync();
                    try
                    {
                        return JsonSerializer.Deserialize<StitchBalanceResponse>(
                            content,
                            new JsonSerializerOptions
                            {
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                            });
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, $"Error deserializing client response. Request: {request.RequestUri}");
                        throw; 
                    }
                case HttpStatusCode.NotFound: 
                case HttpStatusCode.NoContent:
                    return null;
                default:
                    throw new HttpRequestException("Unexpected response from client");
            }
        }
    }
}
