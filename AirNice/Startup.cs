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
using System.Reflection;
using System.IO;
using AirNice.Services.WebServices.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            services.AddCors();
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(CoreMapper));
            services.AddAutoMapper(typeof(CoreWebMapper));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }
                ).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            ////IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

            //services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            //var IdentityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               options.SignIn.RequireConfirmedEmail = true;
                //Password settings
                //options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
                //options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
                //options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
                //options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
                //options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
                //options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

                //Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
                //options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
                //options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

                //User settings
                //options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

                //email confirmation require

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("AirNiceAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "AirNice API",
                        Version = "1.0",
                        Description = "Airline ticketing applicatyion",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "ozougwuIfeanyi@gmail.com",
                            Name = "Ozougwu Ifeanyi",
                            Url = new Uri("http://ifeanyiozougwu.ml/")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "AirNice License",
                            Url = new Uri("http://ifeanyiozougwu.ml/")
                        },
                    });
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                options.IncludeXmlComments(cmlCommentsFullPath);
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                }

                    );
            });

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("AirNiceAPIPassenger",
            //        new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = "AirNice API (Passenger)",
            //            Version = "1.0",
            //            Description = "Airline ticketing applicatyion",
            //            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //            {
            //                Email = "ozougwuIfeanyi@gmail.com",
            //                Name = "Ozougwu Ifeanyi",
            //                Url = new Uri("http://ifeanyiozougwu.ml/")
            //            },
            //            License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //            {
            //                Name = "AirNice License",
            //                Url = new Uri("http://ifeanyiozougwu.ml/")
            //            },
            //        });
            //    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
            //    options.IncludeXmlComments(cmlCommentsFullPath);
            //});


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
            app.UseCors(options => options
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
       );

            app.UseAuthentication();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/AirNiceAPI/swagger.json", " Booking Enquiry");
                //c.SwaggerEndpoint("/swagger/AirNiceAPIPassenger/swagger.json", "Passenger");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
