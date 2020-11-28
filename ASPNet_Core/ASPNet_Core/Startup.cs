using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ASPNet_Core.Models;
namespace ASPNet_Core
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            //login
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDBContext>();

            services.AddScoped<IProductRepository, ProductRepositoryDatabase>();
            services.AddScoped<ICategoryRepository,CategoryRepositoryDatabase>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            //Shopping Cart Session

            services.AddScoped<ShoppingCart>(ShoppingCart.GetCart);//sp=> ShoppingCart.GetCart(sp);
            services.AddHttpContextAccessor();
            services.AddSession();


            services.AddControllersWithViews();
            //login
            services.AddRazorPages();
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
            //before using Session
            app.UseSession();
            app.UseRouting();
            //to enable asp.net core identity middleware
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //login
                endpoints.MapRazorPages();
            });
        }
    }
}
