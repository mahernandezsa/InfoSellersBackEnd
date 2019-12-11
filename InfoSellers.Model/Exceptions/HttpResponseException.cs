using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Exceptions
{
     public class HttpResponseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseException"/> class.
        /// </summary>
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpResponseException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpResponseException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpResponseException(int statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public HttpResponseException(int statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }
    }
}
