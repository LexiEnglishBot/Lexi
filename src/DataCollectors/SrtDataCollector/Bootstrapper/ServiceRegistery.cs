using SrtDataCollector.ServiceImplementations;

namespace SrtDataCollector.Bootstrapper
{
    public static class ServiceRegistery
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<SrtFileReader>();
            services.AddScoped<SrtManager>();
            services.AddScoped<SrtScraper>();
            return services;
        }
    }
}
