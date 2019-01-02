using System;
using RunningTracker.RunningShoes;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            RunningTime t = new RunningTime(1, RunningTimeUnit.Hours);
            RunningDistance d = new RunningDistance(7, RunningDistanceUnit.Miles);
            Shoe s = new Shoe(Brand.Brooks, "x10", 10.5, System.DateTime.Today);
            Precipitation p = new Precipitation(PrecipitationType.Snow, PrecipitationUnit.Inches, 1);
        }
    }
}