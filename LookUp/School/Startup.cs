using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using School.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Data.Entity;
using School.Model;
using School.DB;
using Microsoft.Extensions.Logging;
using School.ViewModel;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Authentication.Cookies;
using System.Net;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace School
{
    public class Startup
    {

        public static IConfigurationRoot AppConfiguration;
        public Startup(IApplicationEnvironment env)
        {
            var builder = new ConfigurationBuilder()                
                .SetBasePath(env.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                ;

            AppConfiguration= builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFramework().AddSqlite().AddDbContext<WorldContext>();
            services.AddTransient<SeedDataService>();
            services.AddScoped<IWorldRepository, WorldRepository>();
           
            using (var db = new WorldContext())
            {
                db.Database.EnsureCreated();
            }

            services.AddMvc(config=>
            {
                ////Redirects all requests to Https version
                //config.Filters.Add(new RequireHttpsAttribute());                
            }).AddJsonOptions(opt=>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddIdentity<WorldUser, IdentityRole>(config =>
             {
                 config.User.RequireUniqueEmail = true;
                 config.Password.RequiredLength = 1;
                 config.Password.RequireLowercase = false;
                 config.Password.RequireNonLetterOrDigit = false;
                 config.Password.RequireDigit = false;
                 config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                 //Not to get Login Page for API calls
                 config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                 {
                     OnRedirectToLogin = context =>
                       {
                           if (context.Request.Path.StartsWithSegments("/api")
                           && context.Response.StatusCode==(int)HttpStatusCode.OK                           
                           )
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                           }
                           else {
                               context.Response.Redirect(context.RedirectUri);
                           }
                           return Task.FromResult(0);
                       }
                 };
             }).AddEntityFrameworkStores<WorldContext>();
            
            //services.ConfigureCookieAuthentication(config =>
            //{
            //    config.LoginPath = "/Auth/Login";
            //});
#if DEBUG
            services.AddScoped<IMailService, MockMailService>();
#else
            services.AddScoped<IMailService, MockMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, SeedDataService seederService,ILoggerFactory loggerFactory)
        {
            //app.UseIISPlatformHandler();            
            //app.UseDefaultFiles();
            loggerFactory.AddDebug((str,level)=>
            {
                return (level == LogLevel.Critical) || (level == LogLevel.Error);
            });

            app.UseStaticFiles();

            //Order Matters !!!
            app.UseIdentity();

            AutoMapper.Mapper.Initialize((config) =>
            {
                config.CreateMap<Trip, TripViewModel>().ReverseMap();
                config.CreateMap<Stop, StopViewModel>().ReverseMap();
            });
            app.UseMvc(config=>
            {
                var defaults = new { controller = "App", action = "Index" };
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" });
            });

           
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello World!:{context.Request.Path}");               
            //});

            await seederService.EnsureSeedDataAsync();

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
