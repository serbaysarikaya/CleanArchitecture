namespace CleanArchitecture.WebApi.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder MiddlewareExtensions(this IApplicationBuilder app)
        {
             app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
