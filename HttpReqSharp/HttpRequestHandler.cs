using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpReqSharp.Interface;
using HttpReqSharp.RequestSenders;

namespace HttpReqSharp
{
    /// <inheritdoc />
    public class HttpRequestHandler : IHttpRequestHandler
    {
        /// <inheritdoc />
        public async Task<IHttpResponse> SendHttpRequestAsync(string requestUrl, IEnumerable<IHttpRequestParameter> requestParameters, string requestBody,
            HttpRequestType requestType)
        {
            if (string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Request url may not be null or whitespace!");
            }

            using (var sender = RequestSenderFactory.ManufactureRequestSender(requestType))
            {
                if (string.IsNullOrWhiteSpace(requestBody) && sender.RequestHasBody)
                {
                    throw new ArgumentException("Request body may not be null or whitespace!");
                }

                return await sender.SendRequestAsync(requestUrl, requestParameters, requestBody);
            }
        }
    }
}
