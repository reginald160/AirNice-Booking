
using AirNice.Utility.Extensions.HostedServices;
using AirNiceWebMVC.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC
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

            services.AddHttpClient();
            services.AddControllersWithViews();/*AddRazorRuntimeCompilation();*/
            services.AddSingleton<IHostedService, CoreHostService>();
            AddRefitHttpClient(services);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void AddRefitHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IBookingServices>(a));

            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IPassengerServices>(a));

            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IBookingEnquiryServices>(a));
            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IPermissionServices>(a));

            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IUserServices>(a));

            services.AddHttpClient("Api", options =>
            {
                options.BaseAddress = new Uri(Configuration["BaseUrl"]);
            }).AddTypedClient(a => RestService.For<IFlightServices>(a));


        }
    }
}
