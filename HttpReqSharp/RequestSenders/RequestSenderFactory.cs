using System;
using HttpReqSharp.Interface;
using HttpReqSharp.RequestSenders.Interface;

namespace HttpReqSharp.RequestSenders
{
    /// <summary>
    /// A factory for request senders.
    /// </summary>
    public abstract class RequestSenderFactory
    {
        /// <summary>
        /// Creates and returns a <see cref="IRequestSender"/> that can send out a specified <see cref="HttpRequestType"/>.
        /// </summary>
        /// <param name="requestType">The request type a sender is needed for.</param>
        /// <returns>A new sender.</returns>
        public static IRequestSender ManufactureRequestSender(HttpRequestType requestType)
        {
            switch (requestType)
            {
                case HttpRequestType.GET:
                    return new GetSender();
                case HttpRequestType.POST:
                    return new PostSender();
                default:
                    throw new NotImplementedException("There is no known sender implemented for the specified request type.");
            }
        }
    }
}
