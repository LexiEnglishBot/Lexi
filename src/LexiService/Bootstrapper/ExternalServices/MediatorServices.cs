using ApplicationService.Service.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper.ExternalServices;

public static class MediatorServices
{
    public static IServiceCollection RegisterMediatorServices(this IServiceCollection services)
    {
        return services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(UpdateRequest).Assembly);
            configuration.Lifetime = ServiceLifetime.Transient;
            configuration.RegistrationTimeout = 0;
        });
    }
}