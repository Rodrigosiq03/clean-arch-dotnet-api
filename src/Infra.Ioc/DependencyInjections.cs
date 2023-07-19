using Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Ioc;

public static class DependencyInjections
{
    public static IServiceCollection AddInfraTest(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("TestConnection");
        services.AddDbContext<ApplicationDbContext>(opts =>
        {
            opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });

        return services;
    }
}