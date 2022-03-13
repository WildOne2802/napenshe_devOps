namespace DevOpsOshnokov.Extensions;

public static class ServiceActivator
{
    private static IServiceProvider _serviceProvider;

    public static void Configure(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static IServiceScope GetScope(IServiceProvider serviceProvider = null)
    {
        var provider = serviceProvider ?? _serviceProvider;
        return (provider ?? throw new InvalidOperationException("Service Provider is not initialized"))
            .GetRequiredService<IServiceScopeFactory>().CreateScope();
    }
}