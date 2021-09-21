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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AirNice.Utility.Extensions.Middlewares.NumberChecker;
using Microsoft.AspNet.OData.Extensions;
using AirNice.Utility.CoreHelpers;
using Microsoft.AspNetCore.Http;
using AirNice.Utility;
using AirNice.Services.IRepository;
using AirNice.Services.Repository;

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
 
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetings>(appSettingsSection);
            services.AddMvc();

            var appSettings = appSettingsSection.Get<AppSetings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            

            // Adding Authentication  
            services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
              .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidAudience = appSettings.ValidAudience,
                        ValidIssuer = appSettings.ValidIssuer,
                    };
                });
         
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               options.SignIn.RequireConfirmedEmail = true;
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = false;
               options.Password.RequiredLength = 6;
               options.Password.RequiredUniqueChars = 1;
               // Lockout settings.
               options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
               options.Lockout.MaxFailedAccessAttempts = 3;
               options.Lockout.AllowedForNewUsers = true;

               // User settings.
               //options.User.AllowedUserNameCharacters =
               //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
               options.User.RequireUniqueEmail = true;

           }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });


            #region Old Swagger



            //services.AddSwaggerGen(options =>
            //{

            //    options.SwaggerDoc("AirNiceAPI",
            //        new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = "AirNice API",
            //            Version = "1.0",
            //            Description = "Airline ticketing application",
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
            //    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then",
            //        Name = "Authorization",
            //        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            //        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });
            //    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header
            //            },
            //            new List<string>()
            //        }
            //    }

            //        );
            //    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //});

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
            #endregion

            services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressConsumesConstraintForFormFileParameters = true;
        options.SuppressInferBindingSourcesForParameters = true;
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressMapClientErrors = true;
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
            "https://httpstatuses.com/404";
    }).AddNewtonsoftJson();
            //services.AddControllers().AddNewtonsoftJson();
            services.AddOData();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirNiceAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			if (env.IsDevelopment())
			{

				app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking Enquiry"));
            }
            app.UseRouting();
  
            app.UseAuthentication();
            app.UseAuthorization();
     
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
             
            });
        }
    }
}
