using System;

namespace RunningTracker.RunningShoes
{
    public class RunningShoeException : System.Exception
    {
        public RunningShoeException(string message)
            : base(message)
            {

            }
    }



    public class Shoe
    {
        public Shoe(
            Brand brand,
            string model,
            double size,
            DateTime releaseDate,
            ShoeTransaction transaction,
            Usage usage)      
        {
            if (size < 0)
                throw new ArgumentException("Shoe size must be positive.");

            Brand = brand;
            Model = model;
            Size = size;
            ReleaseDate = releaseDate;
            Transaction = transaction;
            Usage = usage;
        }


        public Brand Brand { get; }
        public string Model { get; }
        public double Size { get; }
        public DateTime ReleaseDate { get; }
        public ShoeTransaction Transaction { get; }
        public Usage Usage { get; }
    }
}