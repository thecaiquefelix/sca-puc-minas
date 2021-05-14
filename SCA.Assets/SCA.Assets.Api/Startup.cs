using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCA.Assets.Application.Interfaces;
using SCA.Assets.Application.Services;
using SCA.Assets.Data.Factory;
using SCA.Assets.Data.Options;
using SCA.Assets.Data.Repository;
using SCA.Assets.Domain.Interfaces.Factory;
using SCA.Assets.Domain.Interfaces.Repository;

namespace SCA.Assets.Api
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
            services.Configure<DbOptions>(Configuration.GetSection("ConnectionStrings"));

            services
                .AddScoped<IAssetAppService, AssetAppService>()
                .AddScoped<IMaintenanceAppService, MaintenanceAppService>()
                .AddScoped<IDbProviderFactory, DbProviderFactory>()
                .AddScoped<IAssetRepository, AssetRepository>()
                .AddScoped<IMaintenanceRepository, MaintenanceRepository>()
                .AddScoped<IConfigure, Data.Options.Config>();

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assets API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
