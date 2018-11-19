namespace HttpReqSharp.Interface
{
    /// <summary>
    /// An HTTP response.
    /// </summary>
    public interface IHttpResponse
    {
        /// <summary>
        /// Whether or not the request was successful or not.
        /// </summary>
        /// <para>
        /// A request is successful when:
        /// <ul>
        /// <li>
        /// The status code is between 200 (inclusive) and 300 (exclusive).
        /// </li>
        /// <li>
        /// There was no internal exception when sending out the request and receiving the response.
        /// </li>
        /// </ul>
        /// </para>
        bool WasSuccessful { get; }

        /// <summary>
        /// The HTTP response code. Note that this may be <c>null</c> when <see cref="WasSuccessful"/> is false,
        /// but it is guaranteed to have a value when <see cref="WasSuccessful"/> is true.
        /// </summary>
        int? ResponseCode { get; }

        /// <summary>
        /// The body of the response.
        /// </summary>
        string ResponseBody { get; }
    }
}