using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunningTracker.RunningShoes;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;
using RunningTracker.Running.Performance;
using RunningTracker.RunningShoes.Decisions;
using Microsoft.Extensions.DependencyInjection;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceController = new ServiceCollection()
                .AddSingleton<IAppService, RunningTrackerService>();            
            RunningServiceConfiguration.Register(serviceController);
            RunningShoeServiceConfiguration.Register(serviceController);
            RunningPerformanceServiceConfiguration.Register(serviceController);
            
            var serviceProvider = serviceController.BuildServiceProvider();
            var appService = serviceProvider.GetService<IAppService>();
            appService.RunAsync().Wait();
        }
    }
}