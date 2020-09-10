using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Services;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataEncryptor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddDbContext<AuthenticationDbContextContext>(optionsAction =>
            {
                optionsAction.UseMySql(Configuration.GetConnectionString("AuthenticationDbContextConnection"));//Добавить строку подкоючения1

                //try
                //{
                //    optionsAction.UseMySql(Configuration.GetConnectionString("AuthenticationDbContextContextConnection"));//Добавить строку подкоючения1
                //}
                //finally
                //{
                //    optionsAction.UseMySql(Configuration.GetConnectionString(""));//Добавить строку подкоючения2, если не сработала строка подкоючения1
                //}
            }
            );

            services.AddIdentityCore<IdentityUserDTO>()
                .AddEntityFrameworkStores<AuthenticationDbContextContext>();


            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IModelRepository<DataModel>, ModelRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
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