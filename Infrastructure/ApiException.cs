using System;
using System.Net;

namespace WeatherApi.Exceptions {

    public class ApiException : Exception
    {
        public int StatusCode { get; }

        public ApiException(string message, HttpStatusCode statusCode): base(message) {
            StatusCode = (int)statusCode;
        }
    }
}
