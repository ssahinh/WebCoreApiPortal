using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebCoreApiPortal.Utils
{
    public class TokenFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string Token = context.HttpContext.Request.Headers["Authorization"];
            Console.Write($"Token Değeri : {Token}");
        }
    }
}
