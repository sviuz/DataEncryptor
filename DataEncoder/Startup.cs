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
            services.AddControllers();

            var mappingConfig = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new BLL.Mappers.Mapper());
            });

            var connectionString = Configuration
                .GetConnectionString("DefaultConnection");//Getting Connection string
            services.AddDbContext<DataContext>(options
                => options.UseMySql(connectionString));

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

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
