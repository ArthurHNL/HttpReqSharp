using HttpReqSharp.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HttpReqSharp.Test
{
    /// <summary>
    /// Tests for HttpReqSharp.
    /// A huge thanks to https://postman-echo.com/ for making these tests possible.
    /// </summary>
    [TestClass]
    [SuppressMessage("ReSharper", "ConvertToConstant.Local")]
    public class RequestHandlerTest
    {
        #region Argument tests
        [TestMethod]
        public void RequestHandler_RequestUrlNull_ShouldThrowException()
        {
            var job = new HttpRequestHandler().SendHttpRequestAsync(null, null, null, HttpRequestType.GET);
            Assert.ThrowsException<AggregateException>(() => job.Wait());
            Assert.IsInstanceOfType(job.Exception.InnerException, typeof(ArgumentException));
        }

        [TestMethod]
        public void RequestHandler_RequestUrlWhitespace_ShouldThrowException()
        {
            var job = new HttpRequestHandler().SendHttpRequestAsync("", null, null, HttpRequestType.GET);
            Assert.ThrowsException<AggregateException>(() => job.Wait());
            Assert.IsInstanceOfType(job.Exception.InnerException, typeof(ArgumentException));
        }
        #endregion

        #region HTTP GET Tests
        [TestMethod]
        public void RequestHandler_GetRequest_ShouldReturnValidResponse()
        {
            // Setup
            var handler = new HttpRequestHandler();
            var partOfResponse = "\"args\":{\"foo1\":\"bar1\",\"foo2\":\"bar2\"}";
            var expectedResponseCode = 200;

            var baseUrl = "https://postman-echo.com/get";
            var requestParameters = new List<IHttpRequestParameter>()
            {
                new HttpRequestParameter("foo1", "bar1"),
                new HttpRequestParameter("foo2", "bar2")
            };

            // Act
            var job = handler.SendHttpRequestAsync(baseUrl, requestParameters, null, HttpRequestType.GET);
            job.Wait();
            var response = job.Result;

            // Assert
            Assert.IsTrue(response.WasSuccessful, "The GET request was not successful.");
            Assert.IsTrue(response.ResponseBody.Contains(partOfResponse), "The GET request did not return the expected response.");
            Assert.AreEqual(expectedResponseCode, response.ResponseCode);
        }
        #endregion

        #region HTTP POST Tests
        [TestMethod]
        public void RequestHandler_PostRequest_ShouldReturnValidResponse()
        {
            // Setup
            var handler = new HttpRequestHandler();
            var partOfResponse = "this is a body";
            var requestBody = partOfResponse;
            var expectedResponseCode = 200;

            var baseUrl = "https://postman-echo.com/post";

            // Act
            var job = handler.SendHttpRequestAsync(baseUrl, null, requestBody, HttpRequestType.POST);
            job.Wait();
            var response = job.Result;

            // Assert
            Assert.IsTrue(response.WasSuccessful, "The POST request was not successful.");
            Assert.IsTrue(response.ResponseBody.Contains(partOfResponse), "The POST request did not return the expected response.");
            Assert.AreEqual(expectedResponseCode, response.ResponseCode);
        }
        #endregion
    }
}
