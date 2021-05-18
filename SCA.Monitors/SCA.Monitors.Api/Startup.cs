using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCA.Monitors.Application.Interfaces;
using SCA.Monitors.Application.Services;
using SCA.Monitors.Data.Factory;
using SCA.Monitors.Data.Options;
using SCA.Monitors.Data.Repository;
using SCA.Monitors.Domain.Interfaces.Factory;
using SCA.Monitors.Domain.Interfaces.Repository;

namespace SCA.Monitors.Api
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
                .AddScoped<IMonitorAppService, MonitorAppService>()
                .AddScoped<IDbProviderFactory, DbProviderFactory>()
                .AddScoped<IMonitorRepository, MonitorRepository>()
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monitors API V1");
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
