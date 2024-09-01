using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ORM.DbContexts;

namespace Bootstrapper.ExternalServices;

public static class DbContextServices
{
    public static void RegisterDbContextServices(this IServiceCollection services, IConfiguration configuration)
    {
        var dbDataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("PostgresConnectionString")).Build();

        services.AddDbContext<LexiDbContext>(options =>
        {
            options.UseNpgsql(dbDataSource).UseCamelCaseNamingConvention();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }, ServiceLifetime.Transient);
    }
}