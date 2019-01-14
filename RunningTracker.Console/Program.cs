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
            // Register all components and build our dependency tree.
            var serviceController = new ServiceCollection()
                .AddSingleton<IAppService, RunningTrackerService>();            
            RunningServiceConfiguration.Register(serviceController);
            RunningShoeServiceConfiguration.Register(serviceController);
            RunningPerformanceServiceConfiguration.Register(serviceController);

            // Start the app after we've registered all of our dependencies.            
            var serviceProvider = serviceController.BuildServiceProvider();
            var appService = serviceProvider.GetService<IAppService>();
            var task = appService.GetStartupTask();
            task.Start();
            task.Wait();
        }
    }
}