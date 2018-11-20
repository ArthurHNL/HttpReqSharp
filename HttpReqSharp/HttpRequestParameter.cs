using System;
using HttpReqSharp.Interface;

namespace HttpReqSharp
{
    /// <inheritdoc />
    public class HttpRequestParameter : IHttpRequestParameter
    {
        /// <inheritdoc />
        public string ParameterName { get; }

        /// <inheritdoc />
        public string ParameterValue { get; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="parameterName">
        /// Value for <see cref="ParameterName"/>.
        /// May not be <c>null</c>.
        /// For more information, please refer to the related property's documentation.</param>
        /// <param name="parameterValue">
        /// Value for <see cref="ParameterName"/>.
        /// May not be <c>null</c>.
        /// For more information, please refer to the related property's documentation.</param>
        public HttpRequestParameter(string parameterName, string parameterValue)
        {
            ParameterName = parameterName ?? throw new ArgumentNullException();
            ParameterValue = parameterValue ?? throw new ArgumentNullException();
        }
    }
}