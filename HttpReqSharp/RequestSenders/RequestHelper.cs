using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpReqSharp.Interface;

namespace HttpReqSharp.RequestSenders
{
    public abstract class RequestHelper
    {
        /// <summary>
        /// Construct an HTTP Uri from a base url, and parameters.
        /// </summary>
        /// <param name="requestUrl">The base url. May not be <c>null</c>.</param>
        /// <param name="parameters">The parameters. May be <c>null</c>.</param>
        /// <returns>The generated Uri.</returns>
        public static Uri CreateUri(
            string requestUrl,
            IEnumerable<IHttpRequestParameter> parameters)
        {
            var urlBuilder = new StringBuilder(requestUrl ?? throw new ArgumentNullException());

            if (parameters == null) return new Uri(urlBuilder.ToString());

            urlBuilder.Append('?');

            foreach (var par in parameters)
            {
                urlBuilder.Append(par.ParameterName);
                urlBuilder.Append('=');
                urlBuilder.Append(par.ParameterValue);
                urlBuilder.Append('&');
            }
                
            // Remove last '&'.
            urlBuilder.Length--;

            return new Uri(urlBuilder.ToString());
        }

        /// <summary>
        /// Converts a <see cref="HttpResponseMessage"/> into a <see cref="IHttpResponse"/>.
        /// </summary>
        /// <param name="responseMessage">The response to convert.</param>
        /// <returns>The converted response.</returns>
        public static async Task<IHttpResponse> ConvertToResponseObject(HttpResponseMessage responseMessage) => new HttpResponse(
            responseMessage.IsSuccessStatusCode,
            (int)responseMessage.StatusCode,
            await responseMessage.Content.ReadAsStringAsync());
    }
}
