using System;
using System.Linq;
using System.Collections.Generic;
using RunningTracker.Running;

namespace RunningTracker.Running.Performance
{
    public enum RunningSpeedUnit
    {
        MilesPerHour,
        KilometersPerHour
    }

    public interface ICalculateRunningSpeed
    {
        decimal CalculateAverage(IEnumerable<Run> runs);
    }

    public class RunningSpeedCalculator : ICalculateRunningSpeed
    {
        public decimal CalculateAverage(IEnumerable<Run> runs)
        { 
            return Convert.ToDecimal(runs.Select(x => x.Distance.Value * (decimal) x.Duration.TotalSeconds).Sum() / runs.Count());
        }
    }
}