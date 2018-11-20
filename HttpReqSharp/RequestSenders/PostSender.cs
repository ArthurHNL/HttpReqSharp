using HttpReqSharp.Interface;
using HttpReqSharp.RequestSenders.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static HttpReqSharp.HttpResponse;
using static HttpReqSharp.RequestSenders.RequestHelper;

namespace HttpReqSharp.RequestSenders
{
    /// <inheritdoc />
    /// <summary>
    /// This request sender implements HTTP POST.
    /// </summary>
    public class PostSender : IRequestSender
    {
        private readonly HttpClient client;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public PostSender()
        {
            client = new HttpClient();
        }
        
        /// <inheritdoc />
        public async Task<IHttpResponse> SendRequestAsync(string requestUrl, IEnumerable<IHttpRequestParameter> requestParameters, string requestBody)
        {
            try
            {
                return await ConvertToResponseObject(
                    await client.PostAsync(
                        CreateUri(
                            requestUrl,
                            requestParameters),
                        new StringContent(requestBody)));
            }
            catch (HttpRequestException)
            {
                return ExceptionResponse;
            }
        }

        /// <inheritdoc />
        public bool RequestHasBody => true;

        /// <inheritdoc />
        public void Dispose() => client.Dispose();
    }
}
