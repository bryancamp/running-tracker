namespace RunningTracker.Running.Shoes
{
    public class Usage
    {
        public Usage(
            decimal numberOfMiles,
            int numberOfDays)
        {
            if (numberOfMiles < 0)
                throw new ShoeException("Number of miles used must be positive.");
            if (numberOfDays < 0)
                throw new ShoeException("Number of days used must be positive.");

            NumberOfMiles = numberOfMiles;
            NumberOfDays = numberOfDays;
        }

        public decimal NumberOfMiles { get; }

        // For example, if the shoes were used
        // Monday 12/1, Wednesday 12/3, Friday 12/5,
        // then NumberOfDays = 3.
        public int NumberOfDays { get; }
    }
}