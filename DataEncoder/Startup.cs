using BLL.Interfaces;
using BLL.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using BLL.Mappers;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DataEncoder
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddAutoMapper(typeof(ModelMapper));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            

            services.AddDbContext<DataContext>(options => 
            {
                options
                .UseMySql(Configuration
                .GetConnectionString("DefaultConnection")
                );
            });

            services.AddDbContext<UserContext>(options=>
            {
                options
                .UseMySql(Configuration
                .GetConnectionString("UserConnection"));
            });


            //services.AddIdentity<IdentityUser, IdentityRole>()//??переопределить IdentityUser и IdentityRole
                //.AddEntityFrameworkStores<AuthenticationContext>();


            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IRepository<DataModel>, ModelRepository>();

            services.AddControllersWithViews();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
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
