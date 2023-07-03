namespace BoxesProject
{
    public class Box
    {
        public double X { get; }
        public double Y { get; }
        public DateTime PurchaseDate { get; } // Date when the box was purchased

        private int quantity; // Private field to store the actual value of quantity.

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > MaxQuantity)
                {
                    // In case the value is bigger than possible MaxQuantity,
                    // set the quantity to MaxQuantity instead.
                    quantity = MaxQuantity;
                }
                else
                {
                    quantity = value; // Set the quantity to the provided value.
                }
            }
        }

        public int MinQuantity { get; }

        public int MaxQuantity { get; }

        public Box(double x, double y, int quantity, int minQuantity, int maxQuantity)
        {
            X = x;
            Y = y;

            // Use the property setter for Quantity to enforce validation.
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;

            Quantity = quantity;

            PurchaseDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Quantity: {Quantity}, Min: {MinQuantity}, Max: {MaxQuantity}";
        }
    }
}
