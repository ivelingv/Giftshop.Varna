using Giftshop.Varna.Database.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giftshop.Varna.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigrations(this IApplicationBuilder builder)
        {
            builder.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<DbContext>()
                .Database
                .Migrate();

            return builder;
        }

        public static IApplicationBuilder UseStandardServices(this IApplicationBuilder builder)
        {
            builder.UseRouting();
            builder.UseAuthorization();
            builder.UseAuthentication();
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return builder.UseDatabaseMigrations();
        }

        public static IApplicationBuilder UseSwaggerEndpoints(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(opt =>
            {
                opt.RoutePrefix = string.Empty;
                opt.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Giftshop.Api");
            });

            return builder;
        }
    }
}
