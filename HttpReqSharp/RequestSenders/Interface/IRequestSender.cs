using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpReqSharp.Interface;

namespace HttpReqSharp.RequestSenders.Interface
{
    /// <summary>
    /// A request sender that can send out a specific type of HTTP request (eg. HTTP GET).
    /// </summary>
    public interface IRequestSender : IDisposable
    {
        /// <summary>
        /// Send out the specified and asynchronously return the response.
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestParameters"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<IHttpResponse> SendRequestAsync(
            string requestUrl,
            IEnumerable<IHttpRequestParameter> requestParameters,
            string requestBody);

        /// <summary>
        /// Whether or not the request needs a body to be valid.
        /// </summary>
        bool RequestHasBody { get; }
    }
}
