using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrintLayer.Data;
using PrintLayer.Models;
using PrintLayer.Repositories;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services;
using PrintLayer.Services.Interfaces;

namespace PrintLayer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connection));

            //TODO: add services
            services.AddControllersWithViews();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>();


            services.AddScoped<DbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(ICommonService<>), typeof(CommonService<>));
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IVotePrintService, VotePrintService>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            //TODO
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
    }
}
