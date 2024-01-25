using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Optimizely.LanguageWire.DeepL;

public static class DeepLServiceCollectionExtensions
{
    public static IServiceCollection AddDeepLLanguageService(this IServiceCollection services) =>
        AddDeepLLanguageService(services, _ => { });

    public static IServiceCollection AddDeepLLanguageService(this IServiceCollection services, Action<DeepLOptions> setupAction)
    {
        services.AddOptions<DeepLOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                setupAction(options);
                configuration.GetSection("DeepL").Bind(options);
            });

        services
            .TryAddSingleton<IDeepLService, DeepLService>();

        return services;
    }
}