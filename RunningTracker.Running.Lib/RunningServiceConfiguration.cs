using Microsoft.Extensions.DependencyInjection;
using RunningTracker.Running.Shoes;
using RunningTracker.Running.Providers;

namespace RunningTracker.Running
{
    public static class RunningServiceConfiguration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<IProvideRuns, CsvBackedRunProvder>();
            services.AddSingleton<IProvideRawInputRecords, ProprietaryCsvInputRecordProvider>();
            services.AddSingleton<ISerializeRawInputRecords, RawInputRecordSerializer>();
            services.AddSingleton<IProvideRunningShoes, HardcodedRunningShoeProvider>();

            return services;
        }
    }    
}