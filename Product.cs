using System.Diagnostics;

namespace Price_Calculator_Kata
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative value.");
                }

                _price = Math.Round(value, 2);
            }
        }

        public Product() { }

        public Product(string name, int UPC, double price)
        {
            Name = name;
            this.UPC = UPC;
            Price = price;
        }

    }
}
