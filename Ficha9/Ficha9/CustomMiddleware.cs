using System.Diagnostics;

namespace Ficha9
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;

        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            context.Request
            

            // Call the next delegate/middleware in the pipeline.
            Debug.WriteLine("BEFORE: " + context.Request.Path + ", " + context.Request.Method + ", " +  DateTime.Now);
            await next(context);
            Debug.WriteLine("AFTER CM");
        }


    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(
       this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
