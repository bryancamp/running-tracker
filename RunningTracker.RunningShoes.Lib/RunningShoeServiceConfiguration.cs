using Microsoft.Extensions.DependencyInjection;

namespace RunningTracker.RunningShoes
{
    public static class RunningShoeServiceConfiguration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<IProvideRunningShoes, HardcodedRunningShoeProvider>();
            return services;
        }        
    }
}