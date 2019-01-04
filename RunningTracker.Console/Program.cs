using System;
using System.Collections.Generic;
using RunningTracker.RunningShoes;
using RunningTracker.RunningShoes.Providers;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            // Create a test running shoe.
            IProvideRunningShoes provider = new CsvBackedRunningShoeProvider();
            IEnumerator<Shoe> enumerator = provider.GetAllShoes().GetEnumerator();
            enumerator.MoveNext();
            Shoe runningShoe = enumerator.Current;

            // Create a test run.
            Time runningTime = new Time(1.5, TimeUnit.Hours);
            Distance runningDistance = new Distance(11, DistanceUnit.Miles);
            Precipitation precipitation = new Precipitation(PrecipitationType.Rain, PrecipitationUnit.Inches, 0.75);
            Run run = new Run(runningTime, runningDistance, Location.Outside, runningShoe, precipitation);

            // TODO: How do we link a shoe to a run?
        }
    }
}