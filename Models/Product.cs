using System.Diagnostics;

namespace Price_Calculator_Kata.Models
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

    }
}
