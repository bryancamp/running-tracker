using System;

namespace RunningTracker.Running.Shoes
{    
    public class ShoeException : System.Exception
    {
        public ShoeException(string message)
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
            Transaction transaction,
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
        public Transaction Transaction { get; }
        public Usage Usage { get; }
    }
}