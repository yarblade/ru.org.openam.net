using System;
using System.Net;
using System.Runtime.Serialization;

namespace OpenAM.Core.Exceptions
{
    public class HttpClientException : Exception
    {
        public HttpClientException()
        {
        }

        public HttpClientException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpClientException(string message, HttpStatusCode statusCode, string response)
            : base(message)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public HttpClientException(string message, HttpStatusCode statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpClientException(string message, HttpStatusCode statusCode, string response, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response;
        }

        protected HttpClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}.{1}Response: {2}", base.ToString(), Environment.NewLine, Response);
        }
    }
}