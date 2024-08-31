using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace Bootstrapper.ExternalServices;

public static class LogServices
{
    public static ConfigureHostBuilder ConfigureSerilog(this ConfigureHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.WithThreadId()
            .Enrich.WithThreadName().Enrich.WithProperty("ThreadName", "__")
            .Enrich.WithProcessId().Enrich.WithProcessName()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithAssemblyName()
            .Enrich.WithAssemblyVersion()
            .Enrich.WithMemoryUsage()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();

        host.UseSerilog();

        return host;
    }

    public static IServiceCollection RegisterLogService(this IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog(dispose: true);
        });

        return services;
    }
}