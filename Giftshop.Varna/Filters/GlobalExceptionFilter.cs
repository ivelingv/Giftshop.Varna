using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Giftshop.Varna.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new
            {
                Date = DateTime.Now,
                Message = context.Exception.Message,
                TraceId = context.HttpContext.TraceIdentifier,
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
