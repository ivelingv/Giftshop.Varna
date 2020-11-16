using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Repositories;
using Giftshop.Varna.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Giftshop.Varna
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
            services.AddStandardServices();
            services.AddDatabaseContext<DatabaseContext>(Configuration);
            services.AddSecurityServices(Configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddSwagger();
            services.AddHttpContextAccessor();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStandardServices();
            app.UseSwaggerEndpoints();
        }   
    }
}
