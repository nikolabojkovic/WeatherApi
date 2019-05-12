using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WeatherApi.Exceptions;

namespace WeatherApi.Filters
{
    public class ExceptionToJsonFilter : ExceptionFilterAttribute
    {
        private int _statusCode;
        
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException) 
                _statusCode = (context.Exception as ApiException).StatusCode;
            else 
                _statusCode = (int) HttpStatusCode.InternalServerError;
                
             var jsonResult = new JsonResult(Value(context))
                {
                    StatusCode = _statusCode
                };
                context.Result = jsonResult;
        }

        private object Value(ExceptionContext context)
        {
            return new
            {
                message = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            };
        }
    }
}