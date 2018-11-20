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
    /// This request sender implements HTTP GET.
    /// </summary>
    public class GetSender : IRequestSender
    {
        private readonly HttpClient client;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public GetSender()
        {
            client = new HttpClient();
        }

        /// <inheritdoc />
        public async Task<IHttpResponse> SendRequestAsync(string requestUrl, IEnumerable<IHttpRequestParameter> requestParameters, string requestBody)
        {
            try
            {
                return await ConvertToResponseObject(
                    await client.GetAsync(
                        CreateUri(
                            requestUrl,
                            requestParameters)));
            }
            catch (HttpRequestException)
            {
                return ExceptionResponse;
            }
        }

        /// <inheritdoc />
        public bool RequestHasBody => false;

        /// <inheritdoc />
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
