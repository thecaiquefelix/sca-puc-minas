using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCA.Notifications.Application.Interfaces;
using SCA.Notifications.Application.Services;
using SCA.Notifications.Data.Factory;
using SCA.Notifications.Data.Options;
using SCA.Notifications.Data.Repository;
using SCA.Notifications.Domain.Interfaces.Factory;
using SCA.Notifications.Domain.Interfaces.Repository;

namespace SCA.Notifications
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
                .AddScoped<INotificationAppService, NotificationAppService>()
                .AddScoped<IContactAppService, ContactAppService>()
                .AddScoped<IDbProviderFactory, DbProviderFactory>()
                .AddScoped<INotificationRepository, NotificationRepository>()
                .AddScoped<IContactRepository, ContactRepository>()
                .AddScoped<IConfigure, Data.Options.Config>();

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notifications API V1");
            });

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
                );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
