using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDIAPI.Configuration;
using TestDIAPI.Middleware;
using TestDIAPI.Services;

namespace TestDIAPI
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
            services.Configure<GuidTokenConfiguration>(Configuration.GetSection("GuidToken"));

            //services.AddTransient<GuidService>();
            //services.AddSingleton<GuidService>();
            //services.AddScoped<GuidService>();

            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<IPaymentService, OnlinePaymentService>();
            services.RemoveAll<IPaymentService>();
            services.AddGuidServices()
               .AddPayments();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            //app.UseAuthorization();
            app.UseMiddleware<CustomMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
