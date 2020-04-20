using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryApp.booklibrarydatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            /*string conString = Configuration["ConfigurationStrings:DefaultConnection"];
            services.AddDbContext<BookLibraryContext>(options => options.UseMySQL(conString));*/
            // services.AddDbContext<BookLibraryContext>(options => options.UseMySQL("Server=localhost;Database=booklibraryDatabase"));
            services.AddDbContextPool<BookLibraryContext>(options => options
                .UseMySql("Server=localhost;Database=booklibrarydatabase;User=root;Password=LOTOS123l;", options => options
                    .ServerVersion(new Version(8, 0, 19), ServerType.MySql)));
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePages();
                app.UseHsts();
            }  
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
