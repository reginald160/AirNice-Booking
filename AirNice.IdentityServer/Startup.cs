using AirNice.Data;
using AirNice.IdentityServer.Models;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace AirNice.IdentityServer
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
            services.AddMvc();
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();







            services.AddIdentityServer()
                .AddDeveloperSigningCredential().                
                AddClientStore<InMemoryClientStore>()
                .AddResourceStore<InMemoryResourcesStore>()
                //.AddInMemoryClients(Config.GetClients())
                // this adds the config data from DB (clients, resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sql =>
                            sql.MigrationsAssembly(migrationsAssembly));
                })

                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                            sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });
            //.AddInMemoryIdentityResources(Config.GetIdentityResources())
            //.AddInMemoryApiResources(Config.GetApiResources())


            services.AddAuthentication();


            //     services.AddIdentityServer()
            //.AddInMemoryCaching()
            //.AddClientStore<InMemoryClientStore>()
            //.AddResourceStore<InMemoryResourcesStore>();
            //     services.AddAuthentication(options =>
            //     {
            //         options.DefaultScheme = "Cookies";
            //         options.DefaultChallengeScheme = "oidc";
            //     })
            //         .AddCookie("Cookies")
            //         .AddOpenIdConnect("oidc", options =>
            //         {
            //             options.SignInScheme = "Cookies";

            //             options.Authority = "http://localhost:5000";
            //             options.RequireHttpsMetadata = false;

            //             options.ClientId = "mvc";
            //             options.SaveTokens = true;
            //         });
            //services.AddIdentityServer()
            //  .AddDeveloperSigningCredential();
            //.AddInMemoryApiScopes(Configuration.GetSection("IdentityServer:ApiScopes"))
            //.AddInMemoryClients(Config.GetClients());

            //     var builder = services.AddIdentityServer();
            //     services.AddIdentityServer()
            //.AddDeveloperSigningCredential()
            // .AddInMemoryApiScopes(Configuration.GetSection("IdentityServer:ApiScopes"))
            //       .AddInMemoryClients(Config.Clients);

            //This is for dev only scenarios when you don’t have a certificate to use.


            services.AddControllers();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5000";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
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
            app.UseIdentityServer();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
