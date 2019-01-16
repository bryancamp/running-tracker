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
        double CalculateAverage(IEnumerable<Run> runs);
    }

    public class RunningSpeedCalculator : ICalculateRunningSpeed
    {
        public double CalculateAverage(IEnumerable<Run> runs)
        { 
            return runs.Select(x => x.Distance.Value * x.Duration.Value).Sum() / runs.Count();
        }
    }
}