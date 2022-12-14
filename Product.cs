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

        public static PriceCalculator priceCalculator = new PriceCalculator();

        public Product() { }

        public Product(string name, int UPC, double price)
        {
            Name = name;
            this.UPC = UPC;
            Price = price;
        }

        

        public string PriceReport()
        {
            double taxAmount = priceCalculator.CalculateTax(Price);
            double discountAmount = priceCalculator.CalculateDiscount(Price); ;

            double priceAfter = priceCalculator.CalculateTotalPrice(Price);

            string discountPercentageInReport = "";
            string discountAmountInReport = "";
            if (priceCalculator.DiscountPercentage != 0)
            {
                discountAmountInReport = $" Discount amount = ${discountAmount},";
                discountPercentageInReport = $"discount={priceCalculator.DiscountPercentage * 100}%,";
            }

            return $"Tax={priceCalculator.TaxPercentage*100}%," +
                   discountPercentageInReport +
                   $"Tax amount = ${taxAmount}," +
                   discountAmountInReport +
                   $" Price before = ${Price}," +
                   $" price after = ${priceAfter}";
        }

    }
}
