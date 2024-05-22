using Microsoft.Extensions.DependencyInjection;

namespace Stuff.Core;

public static class ContainerTools
{
    public static IServiceProvider CreateContainer()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddSingleton<Spaceship>()
            .AddSingleton<Pilot>()
            .AddSingleton<Weapon>()
            .AddSingleton<Projectile>();

        return serviceCollection.BuildServiceProvider();
    }
}