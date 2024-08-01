namespace Kubra.StitchFunction.Api.Config
{
    /// <summary>
    /// Config class for accessing Client Web Service Url setting from sidecar response.
    /// </summary>
    public interface IClientConfig
    {
        /// <summary>
        /// Url value returned from sidecar.
        /// </summary>
        public string WebServiceUrl { get; set; }   
    }
}
