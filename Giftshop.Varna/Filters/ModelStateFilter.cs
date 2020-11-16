using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Giftshop.Varna.Filters
{
    public class ModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
            ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new JsonResult(new
                {
                    Date = DateTime.Now,
                    Message = "Invalid input parameters",
                    AdditionalInformation = context.ModelState
                        .Values
                        .SelectMany(v => v.Errors.Select(e => e.ErrorMessage).ToArray())
                        .ToArray()
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };

                return;
            }

            await next();
        }
    }
}
