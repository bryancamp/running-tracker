using System;
using System.Collections.Generic;

namespace RunningTracker.Running.Performance
{
    public class RunningSpeedComparison
    {
        public RunningSpeedComparison(IEnumerable<Run> fastest)
        {
            Fastest = fastest;
        }

        public IEnumerable<Run> Fastest { get; }
    }

    public interface ICompareRunningSpeeds
    {
        RunningSpeedComparison Compare(IEnumerable<Run> run1, IEnumerable<Run> run2);     
    }

    public class WeightedAverageRunningSpeedComparer : ICompareRunningSpeeds
    {
        public RunningSpeedComparison Compare(IEnumerable<Run> run1, IEnumerable<Run> run2)
        {
            return new RunningSpeedComparison(run1);
        }
    }

}