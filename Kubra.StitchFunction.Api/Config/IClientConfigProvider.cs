namespace Kubra.StitchFunction.Api.Config
{
    /// <summary>
    /// Class used to call the sidecar service in common lib.
    /// </summary>
    public interface IClientConfigProvider
    {
        /// <summary>
        /// Retrieving the context from the sidecar service and deserializing it to a config class.
        /// </summary>
        /// <returns></returns>
        public Task<IClientConfig> GetConfig();
    }
}
