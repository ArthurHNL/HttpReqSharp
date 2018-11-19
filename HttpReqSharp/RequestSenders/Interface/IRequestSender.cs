using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpReqSharp.Interface;

namespace HttpReqSharp.RequestSenders.Interface
{
    /// <summary>
    /// An HTTP request sender.
    /// </summary>
    public interface IRequestSender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestParameters"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<IHttpResponse> SendRequestAsync(
            string requestUrl,
            IEnumerable<IHttpRequestParameter> requestParameters,
            string requestBody);
    }
}
