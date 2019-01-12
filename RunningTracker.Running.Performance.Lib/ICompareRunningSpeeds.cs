using System;
using System.Collections.Generic;

namespace RunningTracker.Running.Performance
{
    public class RunningSpeedComparison
    {

    }

    public interface ICompareRunningSpeeds
    {
        RunningSpeedComparison Compare(IEnumerable<Run> run1, IEnumerable<Run> run2);     
    }

    public class WeightedAverageRunningSpeedComparer : ICompareRunningSpeeds
    {
        public RunningSpeedComparison Compare(IEnumerable<Run> run1, IEnumerable<Run> run2)
        {
            throw new NotImplementedException();
        }
    }

}