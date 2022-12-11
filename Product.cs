using System.Diagnostics.Metrics;

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

        private static double _taxPercentage = 0.2;
        public static double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tax percentage cannot be a negative value.");
                }

                _taxPercentage = value;
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

        public double CalculatePriceWithTax()
        {
            double taxAmount = _taxPercentage * _price;
            double PriceWithTax = _price + taxAmount;
            return PriceWithTax;
        }

        public string PriceReport()
        {
            double priceWithTax = RoundToTwoDecimal(CalculatePriceWithTax());
            return $"${Price} before tax and ${priceWithTax} after ${_taxPercentage * 100} % tax.";
        }

    }
}
