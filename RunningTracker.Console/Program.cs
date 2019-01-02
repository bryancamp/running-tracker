using System;
using RunningTracker.RunningShoes;
using RunningTracker.WeatherConditions;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            Shoe s = new Shoe(
                Brand.Brooks, 
                "asdf", 
                1.1, 
                System.DateTime.Now);

            Precipitation p = new Precipitation(
                PrecipitationType.Snow,
                PrecipitationUnit.Inches,
                1);
        }
    }
}