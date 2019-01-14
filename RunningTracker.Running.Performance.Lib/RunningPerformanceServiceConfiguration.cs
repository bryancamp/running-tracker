using Microsoft.Extensions.DependencyInjection;

namespace RunningTracker.Running.Performance
{
    public static class RunningPerformanceServiceConfiguration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<ICalculateRunningSpeed, RunningSpeedCalculator>();
            services.AddSingleton<ICompareRunningSpeeds, WeightedAverageRunningSpeedComparer>();
            return services;
        }
    }    
}