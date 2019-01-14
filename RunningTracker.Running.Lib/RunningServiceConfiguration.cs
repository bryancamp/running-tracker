using Microsoft.Extensions.DependencyInjection;

namespace RunningTracker.Running
{
    public static class RunningServiceConfiguration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<IProvideRuns, CsvBackedRunProvder>();
            return services;
        }
    }    
}