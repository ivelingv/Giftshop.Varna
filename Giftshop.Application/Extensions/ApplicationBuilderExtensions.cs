using Giftshop.Application.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseStandardServices(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<JwtCookieAuthenticationMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=LoginCustomer}/{id?}");
            });
        
            return app;
        }
    }
}
