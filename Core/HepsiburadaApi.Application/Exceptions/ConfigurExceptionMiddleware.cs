using Microsoft.AspNetCore.Builder;

namespace HepsiburadaApi.Application.Exceptions
{
    public static class ConfigurExceptionMiddleware
    {
        public static void ConfigurExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
