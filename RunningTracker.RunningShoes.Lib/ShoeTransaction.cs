using System;

namespace RunningTracker.RunningShoes
{
    public class ShoeTransaction
    {
        public ShoeTransaction(
            Shoe shoe,
            decimal price,
            System.DateTime date,
            string store)
        {
            if (shoe == null)
                throw new ArgumentNullException(nameof(shoe));
            if (price < 0)
                throw new ArgumentException("Price must be greater than 0.");
            Shoe = shoe;
            Price = price;
            Date = date;
            Store = store;
        }

        public Shoe Shoe { get; }
        public decimal Price { get; }
        public System.DateTime Date { get; }
        public string Store { get; }
    }
}