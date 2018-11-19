using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpReqSharp.Interface
{
    /// <summary>
    /// Interface specifying an HTTP request handler that is able to make HTTP requests and asynchronously return the results.
    /// </summary>
    public interface IHttpRequestHandler
    {
        /// <summary>
        /// Send out an HTTP request and asynchronously return the response.
        /// </summary>
        /// <param name="requestUrl">The URL to send the request to.
        /// Example: <c>https://example.com/api</c>
        /// May not be <c>null</c>.</param>
        /// <param name="requestParameters">The parameters for the request.
        /// May be <c>null</c>.</param>
        /// <param name="requestBody">
        /// The body of the request.
        /// May be <c>null</c>, when the request type specified in <paramref name="requestType"/> does not have a body.
        /// When the request type specified in <paramref name="requestType"/> does not have a body, this parameter is ignored.</param>
        /// <param name="requestType">The HTTP request type.</param>
        /// <returns></returns>
        Task<IHttpResponse> SendHttpRequestAsync(
            string requestUrl,
            IEnumerable<IHttpRequestParameter> requestParameters,
            string requestBody,
            HttpRequestType requestType);
    }
}