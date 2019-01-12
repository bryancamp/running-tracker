using System;
using System.Collections.Generic;
using System.Linq;
using RunningTracker.RunningShoes;
using RunningTracker.RunningShoes.Providers;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;
using RunningTracker.Running.Performance;
using RunningTracker.RunningShoes.Decisions;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // All runs, inside and outside.
            IProvideRuns runProvider = new CsvBackedRunProvder();
            var allRuns = runProvider.GetAllRuns();
            var allOutsideRuns = runProvider.GetRuns(Location.Outside);
            var allInsideRuns = runProvider.GetRuns(Location.Treadmill);

            // Do I generally run faster inside or outside?
            // Take into account performance degredation as mileage increases.
            ICompareRunningSpeeds speedComparer = new WeightedAverageRunningSpeedComparer();
            var insideOutsideReport = speedComparer.Compare(allInsideRuns, allOutsideRuns);

            // Do I generally run faster with Brooks or Nike shoes?
            var allRunsWithBrooksShoes = allRuns.Where(x => x.Shoe.Brand == Brand.Brooks);
            var allRunsWithNikeShoes = allRuns.Where(x => x.Shoe.Brand == Brand.Nike);
            var brooksNikeReport = speedComparer.Compare(allRunsWithBrooksShoes, allRunsWithNikeShoes);

            // Is it winter?  If so, optimize for the treadmill.
            var allRunsWithBrooksShoesOnTheTreadmill = allRunsWithBrooksShoes.Where(
                x => x.Location == Location.Treadmill);
            var allRunsWithNikeShoesOnTheTreadmill = allRunsWithNikeShoes.Where(
                x => x.Location == Location.Treadmill);
            var brooksNikeTreadmillReport = speedComparer.Compare(
                allRunsWithBrooksShoesOnTheTreadmill, 
                allRunsWithNikeShoesOnTheTreadmill);

            // I like to run outside in the snow.  
            // Based on past experience, What is my best option?
            var allRunsInTheSnowWithBrooksShoes = allRunsWithBrooksShoes.Where(
                x => x.Precipitation.PrecipitationType == PrecipitationType.Snow);
            var allRunsInTheSnowWithNikeShoes = allRunsWithNikeShoes.Where(
                x => x.Precipitation.PrecipitationType == PrecipitationType.Snow);
            var brooksNikeSnowReport = speedComparer.Compare(
                allRunsInTheSnowWithBrooksShoes,
                allRunsInTheSnowWithNikeShoes);

            // Which shoes perform the best in "heavy" snow?
            var allRunsInTheHeavySnowWithBrooksShoes = allRunsInTheSnowWithBrooksShoes.Where(
                x => x.Precipitation.Unit == PrecipitationUnit.Inches && x.Precipitation.Amount > 2);
            var allRunsInTheHeavySnowWithNikeShoes = allRunsInTheSnowWithNikeShoes.Where(
                x => x.Precipitation.Unit == PrecipitationUnit.Inches && x.Precipitation.Amount > 2);        
            var brooksNikeHeavySnowReport = speedComparer.Compare(
                allRunsInTheHeavySnowWithBrooksShoes,
                allRunsInTheHeavySnowWithNikeShoes);

            // The average price of all Brooks model x10 shoes that I have owned.
            IProvideRunningShoes runningShoeProvider = new HardcodedRunningShoeProvider();
            var allBrooksShoes = runningShoeProvider.GetAllShoes().Where(x => x.Brand == Brand.Brooks);
            var allBrooksX10Shoes = allBrooksShoes.Where(x => x.Model == "x10");
            var averageX10Price = allBrooksX10Shoes.Select(x => x.Transaction.Price).Sum();

            // How much has the price of Brooks model x10 gone up or down?
            // Note: this can throw NullReferenceException.
            var brooksX10OrderHistory = allBrooksX10Shoes.OrderBy(x => x.Transaction.Date);
            var priceChange = brooksX10OrderHistory.Last().Transaction.Price - brooksX10OrderHistory.First().Transaction.Price;

            // Which Brooks shoe did I get the most mileage out of?
            var shoeWithTheMostMiles = allBrooksShoes.OrderByDescending(x => x.Usage.NumberOfMiles).First();

            // What was the average amount of miles I got out of the x10 model?
            var averageMiles = allBrooksX10Shoes.Average(x => x.Usage.NumberOfMiles);
        }
    }
}