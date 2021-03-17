using AirNice.Data;
using AirNice.Models.Helper;
using AirNice.Models.Models;
using AirNice.Services.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AirNice.Services.Mapper;

namespace AirNice
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
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(CoreMapper));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            ////IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

            //services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            //var IdentityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
            //{
            //    // Password settings
            //    options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
            //    options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
            //    options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
            //    options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
            //    options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
            //    options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
            //    options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
            //    options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

            //    // User settings
            //    options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

            //    // email confirmation require
            //    options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
            //})
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("AirNiceAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "AirNice API",
                        Version = "1.0"
                    });
            });
          
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/AirNiceAPI/swagger.json", "Foreign Exchange Service");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
