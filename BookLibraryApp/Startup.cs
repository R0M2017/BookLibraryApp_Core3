using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BookLibraryApp
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/Account/Login";
                });
            services.AddTransient<IRepository, BookRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddDbContext<BookLibraryContext>(options => options
                .UseMySql("Server=MYSQL5016.site4now.net;Database=db_a63190_romanrs;Uid=a63190_romanrs;Pwd=LOTOS123l!"/*"server=localhost;port=3306;user=root;password=LOTOS123l;database=booklibrarydatabase;"*/, 
                mySqlOptions => mySqlOptions
                    .ServerVersion("8.0.19-mysql")));
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error/Index");
                app.UseStatusCodePages();
                app.UseHsts();
            }  
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Strict });
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
