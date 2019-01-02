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