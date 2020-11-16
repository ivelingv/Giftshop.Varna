using Giftshop.Application.Configurations;
using Giftshop.Application.Contracts;
using Giftshop.Application.Extensions;
using Giftshop.Application.Infrastructure;
using Giftshop.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace Giftshop.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSecurityServices(Configuration)
                .AddScoped<JwtCookieAuthenticationMiddleware>()
                .AddScoped<ICurrentUserTokenService, CurrentUserTokenService>()
                .AddScoped<ICurrentUserService, CurrentUserService>();

            services.Configure<HttpSettings>(Configuration.GetSection(nameof(HttpSettings)));
            services.AddHttpContextAccessor();

            services.AddRefitClient<ITokenService>()
                .WithConfiguration();

            services.AddRefitClient<IUsersService>()
                .WithConfiguration();

            services.AddRefitClient<IAddressesService>()
                .WithConfiguration();

            services.AddRefitClient<ICategoriesService>()
                .WithConfiguration();

            services.AddRefitClient<IProductsService>()
                .WithConfiguration();

            services.AddRefitClient<IShoppingCartProductsService>()
                .WithConfiguration();

            services.AddRefitClient<IShoppingCartsService>()
                .WithConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
        }
    }
}
