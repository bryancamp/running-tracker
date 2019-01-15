using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunningTracker.Running;
using RunningTracker.Running.Shoes;
using RunningTracker.WeatherConditions;
using RunningTracker.Running.Performance;
using Microsoft.Extensions.DependencyInjection;

namespace RunningTracker.Console
{
    //////////////////////////////////////////////////////////////////////////
    //
    // This console app exercises all of the basic functionality in the repo.
    //
    /////////////////////////////////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            // Register all components and build our dependency tree.
            var serviceController = new ServiceCollection()
                .AddSingleton<IAppService, RunningTrackerService>();            
            RunningServiceConfiguration.Register(serviceController);
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