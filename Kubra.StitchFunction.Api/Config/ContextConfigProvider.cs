using Kubra.Common.Stitch.Services;
using System.Text.Json;

namespace Kubra.StitchFunction.Api.Config
{
    /// <inheritdoc/>
    public class ContextConfigProvider : IClientConfigProvider
    {
        private readonly IStitchSecretsService _stitchSecretsService;

        /// <summary>
        /// Constructor to inject ISidecarService
        /// </summary>
        /// <param name="stitchSecretsService"></param>
        public ContextConfigProvider(IStitchSecretsService stitchSecretsService)
        {
            _stitchSecretsService = stitchSecretsService ?? throw new ArgumentNullException(nameof(stitchSecretsService));
        }

        /// <inheritdoc/>
        public async Task<IClientConfig> GetConfig()
        {
            var configJson = await _stitchSecretsService.GetContext();
            return JsonSerializer.Deserialize<ClientConfig>(configJson);
        }
    }
}
