using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Password.Domain.Handlers;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Password.Api
{
    [ExcludeFromCodeCoverage]
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
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMediatR(typeof(PasswordCheckHandler).Assembly);

            services.AddSwaggerGen(setup =>
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var version = string.Concat("v", assemblyName.Version);
                setup.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = assemblyName.Name,
                    Version = version
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var version = string.Concat("v", assemblyName.Version);
                setup.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
            });
        }
    }
}
