using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Utility.Extensions.Middlewares.NumberChecker
{
    public class NumberCheckerMiddleware
    {
        private readonly RequestDelegate next;

        public NumberCheckerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke (HttpContext context)
        {
            var value = context.Request.Query["value"].ToString();
            if (int.TryParse(value, out int intValue))
                await context.Response.WriteAsync($"you entered a number: {intValue}");
            else
            {
                context.Items["value"] = value;
                await next(context);
            }
        }
    }

    public static class NumberCheckerMiddlewareextension
    {
        public static IApplicationBuilder UserNumberChecker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NumberCheckerMiddleware>();
        }
    }



}
