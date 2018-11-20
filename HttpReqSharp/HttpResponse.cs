using System;
using System.Collections.Generic;
using System.Text;
using HttpReqSharp.Interface;

namespace HttpReqSharp
{
    /// <inheritdoc />
    public class HttpResponse : IHttpResponse
    {
        /// <inheritdoc />
        public bool WasSuccessful { get; }

        /// <inheritdoc />
        public int? ResponseCode { get; }

        /// <inheritdoc />
        public string ResponseBody { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="wasSuccessful">Whether or not the request was successful.
        /// For more information please refer to the documentation of <see cref="WasSuccessful"/>.</param>
        /// <param name="responseCode">The request response code.
        /// For more information please refer to the documentation of <see cref="ResponseCode"/>.</param>
        /// <param name="responseBody">The body of the response.
        /// For more information please refer to the documentation of <see cref="ResponseBody"/>.</param>
        public HttpResponse(bool wasSuccessful, int? responseCode, string responseBody)
        {
            WasSuccessful = wasSuccessful;
            ResponseCode = responseCode;
            ResponseBody = responseBody;
        }

        /// <summary>
        /// Basically a constructor that returns an <c>HttpResponse</c> object that represents an internal exception.
        /// </summary>
        public static HttpResponse ExceptionResponse => new HttpResponse(false, null, null);
    }
}
