using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestNware.Domain.DomainNotification;
using TestNware.Infra.Data;

namespace TestNware.Infra.IoC
{
    public static class RegisterDependencies
    {
        public static void RegisterInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddCqrs();
            services.AddDbContext<NWareContext>(conn => conn.UseNpgsql(config.GetConnectionString("NpgsqlConnection")));
            services.AddScoped<INotificationContext, NotificationContext>();
        }
    }
}
