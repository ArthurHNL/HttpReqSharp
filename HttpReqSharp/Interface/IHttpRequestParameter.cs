namespace HttpReqSharp.Interface
{
    public interface IHttpRequestParameter
    {
        /// <summary>
        /// The name of the HTTP Request parameter.
        /// For example, the name of the only parameter in the following request URL:
        /// <c>https://example.com/someapi?foo=bar</c>,
        /// is equal to <c>foo</c>.
        /// May not be <c>null</c>, and may not be whitespace.
        /// </summary>
        string ParameterName { get; }

        /// <summary>
        /// The value of the HTTP Request parameter.
        /// For example, the value of the only parameter in the following request URL:
        /// <c>https://example.com/someapi?foo=bar</c>,
        /// is equal to <c>bar</c>.
        /// May not be <c>null</c>, and may not be whitespace.
        /// </summary>
        string ParameterValue { get; }
    }
}
