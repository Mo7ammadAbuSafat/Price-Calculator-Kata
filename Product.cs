namespace Price_Calculator_Kata
{
    public class Product
    {
        public string? Name { get; set; }
        public int UBC { get; set; }

        private double _price;
        public double Price
        {
            get => RoundToTwoDecimal(_price);
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative value.");
                }

                _price = value;
            }
        }

        public Product() { }

        public Product(string? name, int UBC, double price)
        {
            Name = name;
            this.UBC = UBC;
            Price = price;
        }

        public static double RoundToTwoDecimal(double value)
        {
            return Math.Round(value, 2);
        }

    }
}
