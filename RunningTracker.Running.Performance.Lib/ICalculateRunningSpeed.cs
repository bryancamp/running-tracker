using System;
using System.Collections.Generic;
using RunningTracker.Running;

namespace RunningTracker.Running.Performance
{
    public interface ICalculateRunningSpeed
    {
        decimal CalculateAverage(IEnumerable<Run> runs);
    }

    public class RunningSpeedCalculator : ICalculateRunningSpeed
    {
        public decimal CalculateAverage(IEnumerable<Run> runs)
        {
            throw new NotImplementedException();
        }
    }
}