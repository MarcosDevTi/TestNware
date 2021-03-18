using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace TestNware.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Test API N'ware",
                    Description = "Test API",
                    Contact = new OpenApiContact() { Name = "Marcos de Souza", Email = "marcos.dev.ti@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Test API N'ware");
            });
        }
    }
}
