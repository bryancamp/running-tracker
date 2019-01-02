using System;

namespace RunningTracker.RunningShoes
{
    public struct Usage
    {
        public Usage(
            double numberOfMiles,
            int numberOfDays)
        {
            if (numberOfMiles < 0)
                throw new RunningShoeException("Number of miles used must be positive.");
            if (numberOfDays < 0)
                throw new RunningShoeException("Number of days used must be positive.");

            NumberOfMiles = numberOfMiles;
            NumberOfDays = numberOfDays;
        }

        public double NumberOfMiles { get; }

        // For example, if the shoes were used
        // Monday 12/1, Wednesday 12/3, Friday 12/5,
        // then NumberOfDays = 3.
        public int NumberOfDays { get; }
    }
}