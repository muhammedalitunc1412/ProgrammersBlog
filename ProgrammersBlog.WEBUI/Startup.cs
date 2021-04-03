using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using ProgrammersBlog.WEBUI.AutoMapper.Profiles;
using ProgrammersBlog.WEBUI.Helpers;
using ProgrammersBlog.WEBUI.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.WEBUI
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
            services.AddAutoMapper(typeof(CategoryProfile),typeof(ArticleProfile),typeof(UserProfile));
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> {

                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());  //success deðerini falan 0,1,2 diye göstericek ama bu kodu yazarsak eðer"(JsonNamingPolicy.CamelCase)" success deðerini 0 olarak deilde string bi ifade olarak alabiliriz
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddSession();
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("LocalDB")); //Service katmanýnda var LoadMyService þeysisi
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options => {

                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder {
                   
                    //Alttakiler full güvenlik önlemi
                    Name = "ProgrammersBlog",
                    HttpOnly=true,
                    SameSite=SameSiteMode.Strict,
                    SecurePolicy=CookieSecurePolicy.Always,
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                      name: "Admin",
                      areaName: "Admin",
                      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
