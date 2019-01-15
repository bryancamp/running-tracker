using Microsoft.Extensions.DependencyInjection;
using RunningTracker.Running.Shoes;

namespace RunningTracker.Running
{
    public static class RunningServiceConfiguration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<IProvideRuns, CsvBackedRunProvder>();
            services.AddSingleton<IProvideRunningShoes, HardcodedRunningShoeProvider>();
            return services;
        }
    }    
}