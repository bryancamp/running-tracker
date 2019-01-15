using System;

namespace RunningTracker.Running.Shoes
{
    public class Transaction
    {
        public Transaction(
            decimal price,
            System.DateTime date,
            string store)
        {
            if (price < 0)
                throw new ArgumentException("Price must be greater than 0.");

            Price = price;
            Date = date;
            Store = store;
        }

        public decimal Price { get; }
        public DateTime Date { get; }
        public string Store { get; }
    }
}